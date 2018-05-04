using System.Collections.Generic;
using ShoppingCart.Models.Enums;

namespace ShoppingCart.Models
{
    public class Product: BaseEntity
    {
        public string Name { get; set; }
        
        public decimal Price { get; set; }
        
        public ProductCategory Category { get; set; }
        
        public virtual ICollection<OrderProduct> Orders { get; set; }
    }
}