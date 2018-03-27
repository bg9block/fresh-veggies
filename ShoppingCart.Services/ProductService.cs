using ShoppingCart.Data;
using ShoppingCart.Data.Interfaces;
using ShoppingCart.Models;
using ShoppingCart.Services.Interfaces;

namespace ShoppingCart.Services
{
    public class ProductService: ServiceBase<Product>, IProductService
    {
        public ProductService(IProductRepository productRepository): base(productRepository)
        {
        }
        
    }
}