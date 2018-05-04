using System;
using FreshVeg.Models.Enums;

namespace FreshVeg.Models
{
    public class Voucher: BaseEntity
    {
        public Guid UserId { get; set; }
        
        public VoucherType Type { get; set; }
        
        public ProductCategory? OfferProductCategory { get; set; }
        
        public string Name { get; set; }
        
        public int DiscountPercentage { get; set; }
        
        public int DiscountAmount { get; set; }
        
        public int? Threshhold { get; set; }
    }
}