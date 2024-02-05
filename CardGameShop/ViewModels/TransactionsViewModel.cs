using System.ComponentModel.DataAnnotations; // Import statements for namespaces
using CoreBusiness;

namespace CardGameShop.ViewModels // Namespace declaration
{
    // View model class for representing transaction data
    public class TransactionsViewModel
    {
        // Property to store the cashier's name, with display name
        [Display(Name = "Cashier Name")]
        public string? CashierName { get; set; }

        // Property to store the start date of transactions, with display name and default value set to today
        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; } = DateTime.Today;

        // Property to store the end date of transactions, with display name and default value set to today
        [Display(Name = "End Date")]
        public DateTime EndDate { get; set; } = DateTime.Today;

        // Property to store a collection of transactions, initialized as an empty list
        public IEnumerable<Transaction> Transactions { get; set; } = new List<Transaction>();
    }
}
