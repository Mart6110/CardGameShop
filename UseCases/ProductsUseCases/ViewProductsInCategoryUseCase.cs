using CoreBusiness;
using UseCases.DataStorePluginInterfaces; // Import statement for the UseCases.DataStorePluginInterfaces namespace

namespace UseCases.ProductsUseCases // Namespace declaration
{
    // Class implementing the use case of viewing products in a category
    public class ViewProductsInCategoryUseCase : IViewProductsInCategoryUseCase
    {
        private readonly IProductRepository productRepository; // Private field to hold the product repository

        // Constructor for the ViewProductsInCategoryUseCase class
        public ViewProductsInCategoryUseCase(IProductRepository productRepository)
        {
            this.productRepository = productRepository; // Assign the injected product repository
        }

        // Method to execute the use case of viewing products in a category
        public IEnumerable<Product> Execute(int categoryId)
        {
            return productRepository.GetProductsByCategoryId(categoryId); // Retrieve products by category ID from the product repository
        }
    }
}
