using UseCases.DataStorePluginInterfaces; // Import statement for the UseCases.DataStorePluginInterfaces namespace

namespace UseCases // Namespace declaration
{
    // Class implementing the use case of selling a product
    public class SellProductUseCase : ISellProductUseCase
    {
        private readonly IProductRepository productRepository; // Private field to hold the product repository
        private readonly IRecordTransactionUseCase recordTransactionUseCase; // Private field to hold the record transaction use case

        // Constructor for the SellProductUseCase class
        public SellProductUseCase(
            IProductRepository productRepository,
            IRecordTransactionUseCase recordTransactionUseCase)
        {
            this.productRepository = productRepository; // Assign the injected product repository
            this.recordTransactionUseCase = recordTransactionUseCase; // Assign the injected record transaction use case
        }

        // Method to execute the use case of selling a product
        public void Execute(string cashierName, int productId, int qtyToSell)
        {
            var product = productRepository.GetProductById(productId); // Retrieve the product by its ID from the product repository
            if (product == null) return; // If the product is not found, exit the method

            recordTransactionUseCase.Execute(cashierName, productId, qtyToSell); // Record the transaction using the record transaction use case
            product.Quantity -= qtyToSell; // Update the product quantity by subtracting the quantity sold
            productRepository.UpdateProduct(productId, product); // Update the product in the product repository
        }
    }
}
