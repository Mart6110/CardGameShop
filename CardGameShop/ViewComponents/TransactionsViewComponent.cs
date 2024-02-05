using Microsoft.AspNetCore.Mvc; // Import statements for namespaces
using UseCases;

namespace CardGameShop.ViewComponents // Namespace declaration
{
    // View component class for displaying transactions
    [ViewComponent]
    public class TransactionsViewComponent : ViewComponent
    {
        // Dependency injection of use case interface
        private readonly IGetTodayTransactionsUseCase getTodayTransactionsUseCase;

        // Constructor to inject use case interface
        public TransactionsViewComponent(IGetTodayTransactionsUseCase getTodayTransactionsUseCase)
        {
            this.getTodayTransactionsUseCase = getTodayTransactionsUseCase;
        }

        // Method to invoke the view component and return the result
        public IViewComponentResult Invoke(string userName)
        {
            var transactions = getTodayTransactionsUseCase.Execute(userName); // Get today's transactions for the specified user

            return View(transactions); // Return the view component with transactions data
        }
    }
}
