using CoreBusiness; // Import statement for the CoreBusiness namespace
using UseCases.DataStorePluginInterfaces; // Import statement for the UseCases.DataStorePluginInterfaces namespace

namespace UseCases // Namespace declaration
{
    // Class implementing the use case of adding a product
    public class AddProductUseCase : IAddProductUseCase
    {
        private readonly IProductRepository productRepository; // Private field to hold the product repository

        // Constructor for the AddProductUseCase class
        public AddProductUseCase(IProductRepository productRepository)
        {
            this.productRepository = productRepository; // Assign the injected product repository
        }

        // Method to execute the use case of adding a product
        public void Execute(Product product)
        {
            productRepository.AddProduct(product); // Call the AddProduct method of the product repository
        }
    }
}
