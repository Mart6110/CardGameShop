using UseCases.DataStorePluginInterfaces; // Import statement for the UseCases.DataStorePluginInterfaces namespace

namespace UseCases // Namespace declaration
{
    // Class implementing the use case of deleting a product
    public class DeleteProductUseCase : IDeleteProductUseCase
    {
        private readonly IProductRepository productRepository; // Private field to hold the product repository

        // Constructor for the DeleteProductUseCase class
        public DeleteProductUseCase(IProductRepository productRepository)
        {
            this.productRepository = productRepository; // Assign the injected product repository
        }

        // Method to execute the use case of deleting a product
        public void Execute(int productId)
        {
            productRepository.DeleteProduct(productId); // Call the DeleteProduct method of the product repository
        }
    }
}
