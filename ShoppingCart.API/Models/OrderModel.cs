using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using ShoppingCart.API.Validation;
using ShoppingCart.Models;
using ShoppingCart.Services.Interfaces;

namespace ShoppingCart.API.Models
{
    public class OrderModel: IValidatableObject
    {
        [Required]
        [EnsureMinimumElements(1, "Products_Are_Empty")]
        public IEnumerable<OrderProductModel> Products { get; set; }
        
        [Required]
        public IEnumerable<Guid> VoucherIds { get; set; }


        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var validationResults = new List<ValidationResult>();
            
            var order = (OrderModel) validationContext.ObjectInstance;

            if (order.VoucherIds != null && order.VoucherIds.Any())
            {
                var voucherService = (IVoucherService) validationContext.GetService(typeof(IVoucherService));
                var actualVouchersIds =
                    voucherService
                        .GetAll(v => order.VoucherIds.Contains(v.Id))
                        .Select(v => v.Id)
                        .ToList();
                
                
                var invalidVoucherIds = (IList<Guid>) order.VoucherIds.Except(actualVouchersIds);
                if (invalidVoucherIds.Any())
                {
                    validationResults.Add(new ValidationResult("Invalid_Voucher_Id", invalidVoucherIds.Select(guid => guid.ToString())));
                }
            }

            if (order.Products != null)
            {
                if (order.Products.Any())
                {
                    var productService = (IProductService) validationContext.GetService(typeof(IProductService));
                    var actualProductIds =
                        productService
                            .GetAll(p => order.Products.Any(op => op.ProductId.Equals(p.Id)))
                            .Select(p => p.Id)
                            .ToList();

                    var invalidProductIds = order.Products.AsQueryable().Select(op => op.ProductId).Except(actualProductIds).ToList();
                    if (invalidProductIds.Any())
                    {
                        validationResults.Add(new ValidationResult("Invalid_Product_Id",
                            invalidProductIds.Select(guid => guid.ToString())));
                    }
                }
                else
                {
                    validationResults.Add(new ValidationResult("Products_Are_Empty"));
                }
            }

            return validationResults;
        }
    }
}