using UseCases.DataStorePluginInterfaces; // Import statements for namespaces

namespace UseCases.CategoriesUseCases // Namespace declaration
{
    // Class implementing the use case to delete a category
    public class DeleteCategoryUseCase : IDeleteCategoryUseCase
    {
        private readonly ICategoryRepository categoryRepository; // Field to store the category repository

        // Constructor to initialize the DeleteCategoryUseCase with a category repository
        public DeleteCategoryUseCase(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        // Method to execute the use case by deleting a category
        public void Execute(int categoryId)
        {
            categoryRepository.DeleteCategory(categoryId); // Call the DeleteCategory method of the category repository
        }
    }
}
