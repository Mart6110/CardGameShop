using System.ComponentModel.DataAnnotations; // Import statements for namespaces
using CoreBusiness;
using CardGameShop.ViewModels.Validations;

namespace CardGameShop.ViewModels // Namespace declaration
{
    // View model class for representing sales data
    public class SalesViewModel
    {
        // Property to store the ID of the selected category
        public int SelectedCategoryId { get; set; }

        // Property to store a collection of categories, initialized as an empty list
        public IEnumerable<Category> Categories { get; set; } = new List<Category>();

        // Property to store the ID of the selected product
        public int SelectedProductId { get; set; }

        // Property to store the quantity to sell, with display name and validation attributes
        [Display(Name = "Quantity")]
        [Range(1, int.MaxValue)] // Ensure the quantity is within the specified range
        [SalesViewModel_EnsureProperQuantity] // Custom validation attribute to ensure proper quantity
        public int QuantityToSell { get; set; }
    }
}
