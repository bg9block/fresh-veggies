
using System.Data.Entity;
using ShoppingCart.Data.Context;
using ShoppingCart.Data.Interfaces;
using ShoppingCart.Models;

namespace ShoppingCart.Data
{
    public class VoucherRepository: GenericRepository<VoucherContext, Voucher>, IVoucherRepository
    {
        public VoucherRepository(VoucherContext context) : base(context)
        {
        }
    }
}
