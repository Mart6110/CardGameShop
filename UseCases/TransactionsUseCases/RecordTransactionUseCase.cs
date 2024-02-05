using UseCases.DataStorePluginInterfaces; // Import statement for the UseCases.DataStorePluginInterfaces namespace

namespace UseCases // Namespace declaration
{
    // Class implementing the use case of recording a transaction
    public class RecordTransactionUseCase : IRecordTransactionUseCase
    {
        private readonly ITransactionRepository transactionRepository; // Private field to hold the transaction repository
        private readonly IProductRepository productRepository; // Private field to hold the product repository

        // Constructor for the RecordTransactionUseCase class
        public RecordTransactionUseCase(
            ITransactionRepository transactionRepository,
            IProductRepository productRepository)
        {
            this.transactionRepository = transactionRepository; // Assign the injected transaction repository
            this.productRepository = productRepository; // Assign the injected product repository
        }

        // Method to execute the use case of recording a transaction
        public void Execute(string cashierName, int productId, int qty)
        {
            var product = productRepository.GetProductById(productId); // Retrieve the product by its ID from the product repository
            if (product != null) // Check if the product exists
            {
                // Add the transaction to the transaction repository
                transactionRepository.Add(
                    cashierName,
                    productId,
                    product.Name,
                    product.Price ?? 0, // Use the product's price if available, otherwise default to 0
                    product.Quantity ?? 0, // Use the product's quantity if available, otherwise default to 0
                    qty);
            }
        }
    }
}
