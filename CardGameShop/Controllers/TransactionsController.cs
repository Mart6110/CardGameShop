using CardGameShop.ViewModels; // Import statements for namespaces
using Microsoft.AspNetCore.Mvc;
using CoreBusiness;
using UseCases;
using Microsoft.AspNetCore.Authorization;

namespace CardGameShop.Controllers // Namespace declaration
{
    // Controller class for managing transactions, requiring authorization
    [Authorize]
    public class TransactionsController : Controller
    {
        // Dependency injection of use case interfaces
        private readonly ISearchTransactionsUseCase searchTransactionsUseCase;

        // Constructor to inject use case interface
        public TransactionsController(ISearchTransactionsUseCase searchTransactionsUseCase)
        {
            this.searchTransactionsUseCase = searchTransactionsUseCase;
        }

        // Action method to display the transactions page
        public IActionResult Index()
        {
            TransactionsViewModel transactionsViewModel = new TransactionsViewModel();
            return View(transactionsViewModel); // Return the transactions view with an empty view model
        }

        // Action method to handle searching for transactions
        public IActionResult Search(TransactionsViewModel transactionsViewModel)
        {
            var transactions = searchTransactionsUseCase.Execute(
                transactionsViewModel.CashierName ?? string.Empty, // If cashier name is null, use empty string
                transactionsViewModel.StartDate,
                transactionsViewModel.EndDate);

            transactionsViewModel.Transactions = transactions; // Set the transactions in the view model

            return View("Index", transactionsViewModel); // Return to the transactions page with updated data
        }
    }
}
