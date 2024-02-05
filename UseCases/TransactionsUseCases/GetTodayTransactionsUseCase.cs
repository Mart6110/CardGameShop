using UseCases.DataStorePluginInterfaces; // Import statement for the UseCases.DataStorePluginInterfaces namespace

namespace UseCases // Namespace declaration
{
    // Class implementing the use case of retrieving today's transactions
    public class GetTodayTransactionsUseCase : IGetTodayTransactionsUseCase
    {
        private readonly ITransactionRepository transactionRepository; // Private field to hold the transaction repository

        // Constructor for the GetTodayTransactionsUseCase class
        public GetTodayTransactionsUseCase(ITransactionRepository transactionRepository)
        {
            this.transactionRepository = transactionRepository; // Assign the injected transaction repository
        }

        // Method to execute the use case of retrieving today's transactions
        public IEnumerable<Transaction> Execute(string cashierName)
        {
            return transactionRepository.GetByDayAndCashier(cashierName, DateTime.Now); // Retrieve today's transactions from the transaction repository
        }
    }
}
