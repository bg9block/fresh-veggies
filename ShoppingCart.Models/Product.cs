﻿namespace ShoppingCart.Models
{
    public class Product: BaseEntity
    {
        public string Name { get; set; }
        
        public int Price { get; set; }
    }
}