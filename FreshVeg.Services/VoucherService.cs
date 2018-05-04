using System;
using System.Linq;
using ShoppingCart.Data;
using ShoppingCart.Data.Interfaces;
using ShoppingCart.Models;
using ShoppingCart.Services.Interfaces;

namespace ShoppingCart.Services
{
    public class VoucherService: ServiceBase<Voucher>, IVoucherService
    {
        public VoucherService(IVoucherRepository voucherRepository) : base(voucherRepository)
        {
        }
    }
}