using CoreBusiness;
using UseCases.DataStorePluginInterfaces; // Import statement for the UseCases.DataStorePluginInterfaces namespace

namespace UseCases // Namespace declaration
{
    // Class implementing the use case of editing a product
    public class EditProductUseCase : IEditProductUseCase
    {
        private readonly IProductRepository productRepository; // Private field to hold the product repository

        // Constructor for the EditProductUseCase class
        public EditProductUseCase(IProductRepository productRepository)
        {
            this.productRepository = productRepository; // Assign the injected product repository
        }

        // Method to execute the use case of editing a product
        public void Execute(int productId, Product product)
        {
            productRepository.UpdateProduct(productId, product); // Call the UpdateProduct method of the product repository
        }
    }
}
