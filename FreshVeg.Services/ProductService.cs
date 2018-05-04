using FreshVeg.Data.Interfaces;
using FreshVeg.Models;
using FreshVeg.Services.Interfaces;

namespace FreshVeg.Services
{
    public class ProductService: ServiceBase<Product>, IProductService
    {
        public ProductService(IProductRepository productRepository): base(productRepository)
        {
        }
        
    }
}