using CoreBusiness; // Import statements for namespaces
using UseCases.DataStorePluginInterfaces;

namespace UseCases.CategoriesUseCases // Namespace declaration
{
    // Class implementing the use case to view a selected category
    public class ViewSelectedCategoryUseCase : IViewSelectedCategoryUseCase
    {
        private readonly ICategoryRepository categoryRepository; // Field to store the category repository

        // Constructor to initialize the ViewSelectedCategoryUseCase with a category repository
        public ViewSelectedCategoryUseCase(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        // Method to execute the use case by retrieving the category with the specified ID
        public Category? Execute(int categoryId)
        {
            return categoryRepository.GetCategoryById(categoryId); // Call the GetCategoryById method of the category repository
        }
    }
}
