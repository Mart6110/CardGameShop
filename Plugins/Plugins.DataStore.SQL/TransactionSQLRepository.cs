using CoreBusiness; // Import statements for namespaces
using Microsoft.EntityFrameworkCore; // Import statement for Entity Framework Core
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces;

namespace Plugins.DataStore.SQL // Namespace declaration
{
    // Implementation of the ITransactionRepository interface for SQL data storage
    public class TransactionSQLRepository : ITransactionRepository
    {
        private readonly MarketContext db; // Private field to hold the database context

        // Constructor to initialize the repository with a database context
        public TransactionSQLRepository(MarketContext db)
        {
            this.db = db; // Assigning the provided database context to the private field
        }

        // Method to add a transaction record to the database
        public void Add(string cashierName, int productId, string productName, double price, int beforeQty, int soldQty)
        {
            // Creating a new transaction object with provided data
            var transaction = new Transaction
            {
                ProductId = productId,
                ProductName = productName,
                TimeStamp = DateTime.Now,
                Price = price,
                BeforeQty = beforeQty,
                SoldQty = soldQty,
                CashierName = cashierName
            };

            db.Transactions.Add(transaction); // Adding the transaction to the database context
            db.SaveChanges(); // Saving changes to the database
        }

        // Method to retrieve transactions by cashier name and date
        public IEnumerable<Transaction> GetByDayAndCashier(string cashierName, DateTime date)
        {
            if (string.IsNullOrWhiteSpace(cashierName)) // If the cashier name is null, empty, or whitespace
            {
                return db.Transactions.Where(x => x.TimeStamp.Date == date.Date); // Return transactions for the specified date
            }
            else // If the cashier name is provided
            {
                return db.Transactions.Where(x =>
                    EF.Functions.Like(x.CashierName, $"%{cashierName}%") && // Filter transactions by cashier name using EF.Functions.Like
                    x.TimeStamp.Date == date.Date); // Filter transactions by date
            }
        }

        // Method to search transactions by cashier name and date range
        public IEnumerable<Transaction> Search(string cashierName, DateTime startDate, DateTime endDate)
        {
            if (string.IsNullOrWhiteSpace(cashierName)) // If the cashier name is null, empty, or whitespace
            {
                return db.Transactions.Where(x =>
                    x.TimeStamp.Date >= startDate.Date && // Filter transactions by start date
                    x.TimeStamp.Date <= endDate.Date); // Filter transactions by end date
            }
            else // If the cashier name is provided
            {
                return db.Transactions.Where(x =>
                    EF.Functions.Like(x.CashierName, $"%{cashierName}%") && // Filter transactions by cashier name using EF.Functions.Like
                    x.TimeStamp.Date >= startDate.Date && // Filter transactions by start date
                    x.TimeStamp.Date <= endDate.Date); // Filter transactions by end date
            }
        }
    }
}
