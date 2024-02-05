using CoreBusiness;
using UseCases.DataStorePluginInterfaces; // Import statement for the UseCases.DataStorePluginInterfaces namespace

namespace UseCases // Namespace declaration
{
    // Class implementing the use case of viewing products
    public class ViewProductsUseCase : IViewProductsUseCase
    {
        private readonly IProductRepository productRepository; // Private field to hold the product repository

        // Constructor for the ViewProductsUseCase class
        public ViewProductsUseCase(IProductRepository productRepository)
        {
            this.productRepository = productRepository; // Assign the injected product repository
        }

        // Method to execute the use case of viewing products
        public IEnumerable<Product> Execute(bool loadCategory = false)
        {
            return productRepository.GetProducts(loadCategory); // Retrieve products from the product repository
        }
    }
}
