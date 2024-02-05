using CoreBusiness; // Import statements for namespaces
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces;

namespace Plugins.DataStore.SQL // Namespace declaration
{
    // Implementation of the ICategoryRepository interface for SQL data storage
    public class CategorySQLRepository : ICategoryRepository
    {
        private readonly MarketContext db; // Private field to hold the database context

        // Constructor to initialize the repository with a database context
        public CategorySQLRepository(MarketContext db)
        {
            this.db = db; // Assigning the provided database context to the private field
        }

        // Method to add a new category to the database
        public void AddCategory(Category category)
        {
            db.Categories.Add(category); // Adding the category to the database context
            db.SaveChanges(); // Saving changes to the database
        }

        // Method to delete a category from the database by its ID
        public void DeleteCategory(int categoryId)
        {
            var category = db.Categories.Find(categoryId); // Finding the category by its ID
            if (category == null) return; // If the category doesn't exist, return without performing further actions

            db.Categories.Remove(category); // Removing the category from the database context
            db.SaveChanges(); // Saving changes to the database
        }

        // Method to retrieve all categories from the database
        public IEnumerable<Category> GetCategories()
        {
            return db.Categories.ToList(); // Returning a list of all categories from the database
        }

        // Method to retrieve a category by its ID from the database
        public Category? GetCategoryById(int categoryId)
        {
            return db.Categories.Find(categoryId); // Returning the category found by its ID, if it exists
        }

        // Method to update a category in the database by its ID
        public void UpdateCategory(int categoryId, Category category)
        {
            if (categoryId != category.CategoryId) return; // If the provided category ID does not match the ID of the category to be updated, return without performing further actions

            var cat = db.Categories.Find(categoryId); // Finding the category to be updated by its ID
            if (cat == null) return; // If the category doesn't exist, return without performing further actions

            cat.Name = category.Name; // Updating the name of the category
            cat.Description = category.Description; // Updating the description of the category
            db.SaveChanges(); // Saving changes to the database
        }
    }
}
