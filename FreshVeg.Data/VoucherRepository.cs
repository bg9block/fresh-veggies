using FreshVeg.Data.Context;
using FreshVeg.Data.Interfaces;
using FreshVeg.Models;

namespace FreshVeg.Data
{
    public class VoucherRepository: GenericRepository<VoucherContext, Voucher>, IVoucherRepository
    {
        public VoucherRepository(VoucherContext context) : base(context)
        {
        }
    }
}
