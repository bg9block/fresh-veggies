using System;
using System.Collections.Generic;
using System.Linq;
using ShoppingCart.Data;
using ShoppingCart.Data.Interfaces;
using ShoppingCart.Models;
using ShoppingCart.Models.Enums;
using ShoppingCart.Services.Interfaces;

namespace ShoppingCart.Services
{
    public class OrderService: ServiceBase<Order>, IOrderService
    {
        private readonly IProductService _productService;

        private readonly IVoucherService _voucherService;
        
        public OrderService(IOrderRepository orderRepository, IProductService productService, IVoucherService voucherService) : base(orderRepository)
        {
            _productService = productService;
            _voucherService = voucherService;
        }

        public double GetTotalPriceFor(Order order)
        {
            var products = _productService.GetAll(pr => order.OrderProducts.Any(op => op.ProductId.Equals(pr.Id))).ToList();
            
            var total = order.VoucherIds.Any() ? CalculateWithVouchers(order, products) : CalculateWithoutVouchers(products);

            return Math.Round(total, 2);
        }
        
        private double CalculateWithVouchers(Order order, IEnumerable<Product> products)
        {
            var total = CalculateWithoutVouchers(products);

            
            var vouchers = _voucherService.GetAll(v => order.VoucherIds.Contains(v.Id)).ToList();
            var giftVouchers = vouchers.Where(v => v.Type.Equals(VoucherType.Gift)).ToList();
            var offerVoucher = vouchers.FirstOrDefault(v => v.Type.Equals(VoucherType.Offer));

            if (offerVoucher != null && total > offerVoucher.Threshhold)
            {
                total = ApplyVoucher(offerVoucher, total);
            }
            
            if (total > 0)
            {
                foreach (var voucher in giftVouchers)
                {
                    total = ApplyVoucher(voucher, total);
                    if (total < 0)
                        break;
                } 
            }
            
            return total;
        }

        private double CalculateWithoutVouchers(IEnumerable<Product> products)
        {
            return products.Aggregate(0.00, (sum, next) => (double) sum + next.Price);
        }

        private double ApplyVoucher(Voucher voucher, double total)
        {
            return voucher.DiscountAmount > total || voucher.DiscountPercentage > 100? 
                0:
                (total - voucher.DiscountAmount) * (100 - voucher.DiscountPercentage) / 100;
        }
    }
}