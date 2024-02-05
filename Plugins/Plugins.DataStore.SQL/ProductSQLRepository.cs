using CoreBusiness; // Import statements for namespaces
using Microsoft.EntityFrameworkCore; // Import statement for Entity Framework Core
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces;

namespace Plugins.DataStore.SQL // Namespace declaration
{
    // Implementation of the IProductRepository interface for SQL data storage
    public class ProductSQLRepository : IProductRepository
    {
        private readonly MarketContext db; // Private field to hold the database context

        // Constructor to initialize the repository with a database context
        public ProductSQLRepository(MarketContext db)
        {
            this.db = db; // Assigning the provided database context to the private field
        }

        // Method to add a new product to the database
        public void AddProduct(Product product)
        {
            db.Products.Add(product); // Adding the product to the database context
            db.SaveChanges(); // Saving changes to the database
        }

        // Method to delete a product from the database by its ID
        public void DeleteProduct(int productId)
        {
            var product = db.Products.Find(productId); // Finding the product by its ID
            if (product == null) return; // If the product doesn't exist, return without performing further actions

            db.Products.Remove(product); // Removing the product from the database context
            db.SaveChanges(); // Saving changes to the database
        }

        // Method to retrieve a product by its ID from the database
        public Product? GetProductById(int productId, bool loadCategory = false)
        {
            if (loadCategory)
                return db.Products
                    .Include(x => x.Category) // Including the category navigation property if requested
                    .FirstOrDefault(x => x.ProductId == productId); // Finding the product by its ID and returning it
            else
                return db.Products
                    .FirstOrDefault(x => x.ProductId == productId); // Finding the product by its ID and returning it
        }

        // Method to retrieve all products from the database
        public IEnumerable<Product> GetProducts(bool loadCategory = false)
        {
            if (loadCategory)
                return db.Products.Include(x => x.Category).OrderBy(x => x.CategoryId).ToList(); // Including the category navigation property if requested and ordering the products by category ID
            else
                return db.Products.OrderBy(x => x.CategoryId).ToList(); // Ordering the products by category ID
        }

        // Method to retrieve all products belonging to a specific category from the database
        public IEnumerable<Product> GetProductsByCategoryId(int categoryId)
        {
            return db.Products.Where(x => x.CategoryId == categoryId).ToList(); // Filtering products by category ID and returning them
        }

        // Method to update a product in the database by its ID
        public void UpdateProduct(int productId, Product product)
        {
            if (productId != product.ProductId) return; // If the provided product ID does not match the ID of the product to be updated, return without performing further actions

            var prod = db.Products.Find(productId); // Finding the product to be updated by its ID
            if (prod == null) return; // If the product doesn't exist, return without performing further actions

            // Updating product properties
            prod.CategoryId = product.CategoryId;
            prod.Name = product.Name;
            prod.Price = product.Price;
            prod.Quantity = product.Quantity;

            db.SaveChanges(); // Saving changes to the database
        }
    }
}
