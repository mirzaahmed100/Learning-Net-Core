using Ecommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Infrastructure
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Product> Product { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Manufacturer> Manufacturer { get; set; }
        public DbSet<Category> Category { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Fluent Api Relationship
            modelBuilder.Entity<Product>()
           .HasOne(p => p.ProductInventory)
           .WithOne(pi => pi.Product)
           .HasForeignKey<ProductInventory>(pi => pi.ProductId);

            base.OnModelCreating(modelBuilder);  
        }
    }
}
