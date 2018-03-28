using Microsoft.EntityFrameworkCore;
using ShoppingCart.Common;
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
        
#if DEBUG
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (Env.IsRunningFromXUnit)
            {
                optionsBuilder.UseSqlite(Env.TestDbConnection);
            }
        }
#endif
   
        
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Voucher> Vouchers { get; set; }
        public virtual DbSet<Product> Products { get; set; }

    }
}