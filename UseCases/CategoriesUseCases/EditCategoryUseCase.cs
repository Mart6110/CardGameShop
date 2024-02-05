using CoreBusiness; // Import statements for namespaces
using UseCases.DataStorePluginInterfaces;

namespace UseCases.CategoriesUseCases // Namespace declaration
{
    // Class implementing the use case to edit a category
    public class EditCategoryUseCase : IEditCategoryUseCase
    {
        private readonly ICategoryRepository categoryRepository; // Field to store the category repository

        // Constructor to initialize the EditCategoryUseCase with a category repository
        public EditCategoryUseCase(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        // Method to execute the use case by updating a category
        public void Execute(int categoryId, Category category)
        {
            categoryRepository.UpdateCategory(categoryId, category); // Call the UpdateCategory method of the category repository
        }
    }
}
