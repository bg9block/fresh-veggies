using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using ShoppingCart.API.Validation;
using ShoppingCart.Models;
using ShoppingCart.Models.Enums;
using ShoppingCart.Services.Interfaces;

namespace ShoppingCart.API.Models
{
    public class OrderModel: IValidatableObject
    {
        [Required]
        [EnsureMinimumElements(1, "Order should have at least one product")]
        public IEnumerable<OrderProductModel> Products { get; set; }
        
        [Required]
        public IEnumerable<Guid> VoucherIds { get; set; }
        
        public IEnumerable<Voucher> Vouchers { get; set; }

        //if DataAnnotations validation passes, this is executed
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var validationResults = new List<ValidationResult>();
            var memberNames = new string[] {validationContext.MemberName};
            
            var order = (OrderModel) validationContext.ObjectInstance;

            var vouchers = new List<Voucher>();
            
            if (order.VoucherIds != null && order.VoucherIds.Any())
            {
                var voucherService = (IVoucherService) validationContext.GetService(typeof(IVoucherService));
                var actualVouchers = voucherService
                        .GetAll(v => order.VoucherIds.Contains(v.Id))
                        .ToList();
                
                var invalidVoucherIds = order.VoucherIds.Except(actualVouchers.Select(v => v.Id)).ToList();
                if (invalidVoucherIds.Any())
                {
                    validationResults.Add(new ValidationResult(
                        $"Invalid VoucherIds: {invalidVoucherIds.Aggregate("", (reducer, next) => next.ToString() + ", " + reducer)}", new List<string>(){"OrderModel.VoucherIds"}));
                }
                else
                {
                    vouchers = actualVouchers;
                }
            }
            
            if (order.Products != null && order.Products.Any())
            {
                var productService = (IProductService) validationContext.GetService(typeof(IProductService));
                var actualProductIds = productService
                        .GetAll(p => order.Products.Any(op => op.ProductId.Equals(p.Id)))
                        .Select(p => p.Id)
                        .ToList();

                var invalidProductIds = order.Products.AsQueryable().Select(op => op.ProductId).Except(actualProductIds).ToList();
                if (invalidProductIds.Any())
                {
                    validationResults.Add(new ValidationResult($"Invalid Product Ids: {invalidProductIds.Aggregate("", (reducer, next) => next.ToString() + ", " + reducer)}", new List<string>(){"OrderModel.Products"}));
                }
                
                //Check basket contains
                if (vouchers.Any())
                {
                    var offerVoucher = vouchers.FirstOrDefault(v => v.Type.Equals(VoucherType.Offer));
                }
            }

            return validationResults;
        }
    }
}