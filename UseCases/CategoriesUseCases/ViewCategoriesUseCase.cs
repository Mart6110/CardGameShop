using CoreBusiness; // Import statements for namespaces
using UseCases.DataStorePluginInterfaces;

namespace UseCases.CategoriesUseCases // Namespace declaration
{
    // Class implementing the use case to view categories
    public class ViewCategoriesUseCase : IViewCategoriesUseCase
    {
        private readonly ICategoryRepository categoryRepository; // Field to store the category repository

        // Constructor to initialize the ViewCategoriesUseCase with a category repository
        public ViewCategoriesUseCase(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        // Method to execute the use case by retrieving categories
        public IEnumerable<Category> Execute()
        {
            return categoryRepository.GetCategories(); // Call the GetCategories method of the category repository
        }
    }
}
