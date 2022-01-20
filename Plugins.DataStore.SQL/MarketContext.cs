using CoreBussines;
using Microsoft.EntityFrameworkCore;

namespace Plugins.DataStore.SQL
{
    public class MarketContext: DbContext
    {
        public MarketContext(DbContextOptions options):base(options)
        {

        }

        public DbSet<Category> categories { get; set; }
        public DbSet<Product> products { get; set; }
        public DbSet<Transaction> transactions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .HasMany(c => c.Products)
                .WithOne(p => p.Category)
                .HasForeignKey(p => p.CategoryId);

            //seed data
            modelBuilder.Entity<Category>().HasData(
                new Category() { CategoryId = 1, Name = "Beverage", Description = "Beverage" },
                new Category() { CategoryId = 2, Name = "Bakery", Description = "Bakery" },
                new Category() { CategoryId = 3, Name = "Meat", Description = "Meat" }
                );

            modelBuilder.Entity<Product>().HasData(
                new Product() { ProductId = 1, CategoryId = 1, Name = "Iced Tea", Price = 2.99, Quantity = 300 },
                new Product() { ProductId = 2, CategoryId = 1, Name = "Ginger Ale", Price = 5.99, Quantity = 100 },
                new Product() { ProductId = 3, CategoryId = 1, Name = "Canada Dry", Price = 4.99, Quantity = 200 },
                new Product() { ProductId = 4, CategoryId = 2, Name = "Whole Wheat Bread", Price = 1.99, Quantity = 20 },
                new Product() { ProductId = 5, CategoryId = 2, Name = "White Bread", Price = 0.99, Quantity = 1000 },
                new Product() { ProductId = 6, CategoryId = 3, Name = "Roat Beef", Price = 7.99, Quantity = 300 }

                );
        }
    }
}