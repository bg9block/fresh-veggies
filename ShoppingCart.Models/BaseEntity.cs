using System;

namespace ShoppingCart.Models
{
    public abstract class BaseEntity
    {
        public Guid Id { get; set; }
    }
}