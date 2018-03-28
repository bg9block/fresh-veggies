using ShoppingCart.Models.Enums;

namespace ShoppingCart.Models
{
    public class Product: BaseEntity
    {
        public string Name { get; set; }
        
        public double Price { get; set; }
        
        public ProductCategory Category { get; set; }
    }
}