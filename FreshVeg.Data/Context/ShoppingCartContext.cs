using FreshVeg.Common;
using FreshVeg.Models;
using Microsoft.EntityFrameworkCore;

namespace FreshVeg.Data.Context
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
        public virtual DbSet<OrderProduct> OrderProduct { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderProduct>()
                .HasKey(op => new { op.OrderId, op.ProductId });

            modelBuilder.Entity<OrderProduct>()
                .HasOne(op => op.Product)
                .WithMany(b => b.Orders)
                .HasForeignKey(bc => bc.ProductId);

            modelBuilder.Entity<OrderProduct>()
                .HasOne(bc => bc.Order)
                .WithMany(c => c.Products)
                .HasForeignKey(bc => bc.OrderId);
            
        }

    }
}