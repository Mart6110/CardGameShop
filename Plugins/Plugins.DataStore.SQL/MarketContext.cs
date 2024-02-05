using CoreBusiness; // Import statements for namespaces
using Microsoft.EntityFrameworkCore; // Import statement for Entity Framework Core

namespace Plugins.DataStore.SQL // Namespace declaration
{
    // DbContext class representing the database context for the application
    public class MarketContext : DbContext
    {
        // Constructor to initialize the MarketContext with DbContextOptions
        public MarketContext(DbContextOptions<MarketContext> options) : base(options)
        {
        }

        // DbSet properties representing database tables
        public DbSet<Category> Categories { get; set; } // DbSet for Category entities
        public DbSet<Product> Products { get; set; } // DbSet for Product entities
        public DbSet<Transaction> Transactions { get; set; } // DbSet for Transaction entities

        // Method to configure the model that was discovered by convention from the entity types exposed in DbSet properties
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuring the relationship between Category and Product entities
            modelBuilder.Entity<Category>()
                .HasMany(c => c.Products)
                .WithOne(p => p.Category)
                .HasForeignKey(p => p.CategoryId);

            // Seeding initial data for Categories and Products
            modelBuilder.Entity<Category>().HasData(
                    new Category { CategoryId = 1, Name = "Fantasy", Description = "Magic & Swords" },
                    new Category { CategoryId = 2, Name = "Sci-fi", Description = "Space" }
                );

            modelBuilder.Entity<Product>().HasData(
                    new Product { ProductId = 1, CategoryId = 1, Name = "Arcane Chronicles", Quantity = 100, Price = 150 },
                    new Product { ProductId = 2, CategoryId = 1, Name = "Ethereal Saga", Quantity = 200, Price = 150 },
                    new Product { ProductId = 3, CategoryId = 2, Name = "Galactic Conquest: Interstellar Rivalry", Quantity = 300, Price = 100 },
                    new Product { ProductId = 4, CategoryId = 2, Name = "Cyber Nexus: Future Warfare", Quantity = 300, Price = 100 }
                );
        }
    }
}
