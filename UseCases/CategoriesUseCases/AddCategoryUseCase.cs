using CoreBusiness; // Import statements for namespaces
using UseCases.DataStorePluginInterfaces;

namespace UseCases.CategoriesUseCases // Namespace declaration
{
    // Class implementing the use case to add a category
    public class AddCategoryUseCase : IAddCategoryUseCase
    {
        private readonly ICategoryRepository categoryRepository; // Field to store the category repository

        // Constructor to initialize the AddCategoryUseCase with a category repository
        public AddCategoryUseCase(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        // Method to execute the use case by adding a category
        public void Execute(Category category)
        {
            categoryRepository.AddCategory(category); // Call the AddCategory method of the category repository
        }
    }
}
