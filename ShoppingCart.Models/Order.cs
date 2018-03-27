using System;
using System.Collections.Generic;

namespace ShoppingCart.Models
{
    public class Order: BaseEntity
    {
        public Guid UserId { get; set; }
        
        public virtual IEnumerable<OrderProduct> OrderProducts { get; set; }
        
        public IEnumerable<Guid> VoucherIds { get; set; }
    }
}