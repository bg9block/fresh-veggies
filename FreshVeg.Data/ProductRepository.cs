﻿
using ShoppingCart.Data.Context;
using ShoppingCart.Data.Interfaces;
using ShoppingCart.Models;

namespace ShoppingCart.Data
{
    public class ProductRepository: GenericRepository<ProductContext, Product>, IProductRepository
    {
        public ProductRepository(ProductContext context) : base(context)
        {
        }
    }
}
