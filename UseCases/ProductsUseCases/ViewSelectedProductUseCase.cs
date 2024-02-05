using CoreBusiness;
using UseCases.DataStorePluginInterfaces; // Import statement for the UseCases.DataStorePluginInterfaces namespace

namespace UseCases // Namespace declaration
{
    // Class implementing the use case of viewing a selected product
    public class ViewSelectedProductUseCase : IViewSelectedProductUseCase
    {
        private readonly IProductRepository productRepository; // Private field to hold the product repository

        // Constructor for the ViewSelectedProductUseCase class
        public ViewSelectedProductUseCase(IProductRepository productRepository)
        {
            this.productRepository = productRepository; // Assign the injected product repository
        }

        // Method to execute the use case of viewing a selected product
        public Product? Execute(int productId)
        {
            return productRepository.GetProductById(productId); // Retrieve the selected product from the product repository
        }
    }
}
