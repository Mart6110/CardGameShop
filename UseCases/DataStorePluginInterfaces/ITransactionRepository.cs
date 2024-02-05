using CoreBusiness; // Import statement for the CoreBusiness namespace

namespace UseCases.DataStorePluginInterfaces // Namespace declaration
{
    // Interface defining the contract for a transaction repository
    public interface ITransactionRepository
    {
        IEnumerable<Transaction> GetByDayAndCashier(string cashierName, DateTime date); // Method to retrieve transactions by cashier name and date
        IEnumerable<Transaction> Search(string cashierName, DateTime startDate, DateTime dateTime); // Method to search for transactions within a specified date range and by cashier name
        void Add(string cashierName, int productId, string productName, double price, int beforeQty, int soldQty); // Method to add a new transaction
    }
}
