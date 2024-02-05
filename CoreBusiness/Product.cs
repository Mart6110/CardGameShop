using System.ComponentModel.DataAnnotations; // Import statements for namespaces

namespace CoreBusiness // Namespace declaration
{
    // Class representing a product
    public class Product
    {
        // Property to store the product ID
        public int ProductId { get; set; }

        // Property to store the category ID, with required validation and display name
        [Required(ErrorMessage = "The Category field is required.")]
        [Display(Name = "Category")]
        public int? CategoryId { get; set; }

        // Property to store the name of the product, with required validation
        [Required(ErrorMessage = "The Name field is required.")]
        public string Name { get; set; } = string.Empty;

        // Property to store the quantity of the product, with required validation
        [Required(ErrorMessage = "The Quantity field is required.")]
        public int? Quantity { get; set; }

        // Property to store the price of the product, with required validation and range constraint
        [Required(ErrorMessage = "The Price field is required.")]
        [Range(0, int.MaxValue, ErrorMessage = "The Price must be a non-negative value.")]
        public double? Price { get; set; }

        // Navigation property for Entity Framework Core to represent the relationship between products and categories
        public Category? Category { get; set; }
    }
}
