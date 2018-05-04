using FreshVeg.Data.Context;
using FreshVeg.Data.Interfaces;
using FreshVeg.Models;

namespace FreshVeg.Data
{
    public class ProductRepository: GenericRepository<ProductContext, Product>, IProductRepository
    {
        public ProductRepository(ProductContext context) : base(context)
        {
        }
    }
}
