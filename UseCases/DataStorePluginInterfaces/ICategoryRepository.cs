using CoreBusiness; // Import statement for the CoreBusiness namespace

namespace UseCases.DataStorePluginInterfaces // Namespace declaration
{
    // Interface defining the contract for a category repository
    public interface ICategoryRepository
    {
        void AddCategory(Category category); // Method to add a new category
        void DeleteCategory(int categoryId); // Method to delete a category by ID
        IEnumerable<Category> GetCategories(); // Method to retrieve all categories
        Category? GetCategoryById(int categoryId); // Method to retrieve a category by ID
        void UpdateCategory(int categoryId, Category category); // Method to update a category
    }
}
