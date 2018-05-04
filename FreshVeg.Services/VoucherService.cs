using FreshVeg.Data.Interfaces;
using FreshVeg.Models;
using FreshVeg.Services.Interfaces;

namespace FreshVeg.Services
{
    public class VoucherService: ServiceBase<Voucher>, IVoucherService
    {
        public VoucherService(IVoucherRepository voucherRepository) : base(voucherRepository)
        {
        }
    }
}