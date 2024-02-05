using CoreBusiness;
using System;
using System.Collections.Generic;
using UseCases.DataStorePluginInterfaces;

namespace UseCases
{
    /// <summary>
    /// Use case for searching transactions within a specified date range and cashier name.
    /// </summary>
    public class SearchTransactionsUseCase : ISearchTransactionsUseCase
    {
        private readonly ITransactionRepository transactionRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="SearchTransactionsUseCase"/> class.
        /// </summary>
        /// <param name="transactionRepository">The transaction repository dependency.</param>
        public SearchTransactionsUseCase(ITransactionRepository transactionRepository)
        {
            this.transactionRepository = transactionRepository ?? throw new ArgumentNullException(nameof(transactionRepository));
        }

        /// <summary>
        /// Executes the search for transactions.
        /// </summary>
        /// <param name="cashierName">The name of the cashier.</param>
        /// <param name="startDate">The start date of the search range.</param>
        /// <param name="endDate">The end date of the search range.</param>
        /// <returns>The list of transactions found within the specified range and cashier name.</returns>
        public IEnumerable<Transaction> Execute(string cashierName, DateTime startDate, DateTime endDate)
        {
            if (string.IsNullOrEmpty(cashierName))
            {
                throw new ArgumentException("Cashier name cannot be null or empty.", nameof(cashierName));
            }

            if (startDate > endDate)
            {
                throw new ArgumentException("Start date must be before end date.");
            }

            return transactionRepository.Search(cashierName, startDate, endDate);
        }
    }
}
