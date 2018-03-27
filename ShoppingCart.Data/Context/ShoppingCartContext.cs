using Microsoft.EntityFrameworkCore;
using ShoppingCart.Models;

namespace ShoppingCart.Data.Context
{
    public class ShoppingCartContext: DbContext
    {
        public ShoppingCartContext()
        {
            
        }
        
        public ShoppingCartContext(DbContextOptions<ShoppingCartContext> options)
            : base(options)
        { }
            
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Voucher> Vouchers { get; set; }
        public virtual DbSet<Product> Products { get; set; }

    }
}