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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
              new Product
              {
                  Id = 1,
                  Name = "Laptop",

                  Description = "Dell Laptop.",
                  Price = 10000
              },
                new Product
                {
                    Id = 2,
                    Name = "Mobile",

                    Description = "Samsung Mobile.",
                    Price = 10000
                },

                  new Product
                  {
                      Id = 3,
                      Name = "Tablet",

                      Description = "Iphone Tab.",
                      Price = 10000
                  }

        );
        }
    }
}
