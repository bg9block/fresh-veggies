using System;
using System.ComponentModel.DataAnnotations;

namespace ShoppingCart.API.Models
{
    public class OrderProductModel
    {
        [Required]
        public Guid ProductId { get; set; }
        
        [Range(1, Int32.MaxValue, ErrorMessage = "Amount cannot be less or equal zero.")]
        public int Amount { get; set; }
    }
}