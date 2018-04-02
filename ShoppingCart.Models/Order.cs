using System;
using System.Collections.Generic;

namespace ShoppingCart.Models
{
    public class Order: BaseEntity
    {
        public Guid UserId { get; set; }
        
        public virtual IEnumerable<OrderProduct> Products { get; set; }

        public virtual IEnumerable<Voucher> Vouchers{ get; set; }
    }
}