using System.ComponentModel.DataAnnotations; // Import statements for namespaces

namespace CoreBusiness // Namespace declaration
{
    // Class representing a category
    public class Category
    {
        // Property to store the category ID
        public int CategoryId { get; set; }

        // Property to store the name of the category, with required validation
        [Required(ErrorMessage = "The Name field is required.")]
        public string Name { get; set; } = string.Empty;

        // Property to store the description of the category
        public string? Description { get; set; } = string.Empty;

        // Navigation property for Entity Framework Core to represent the relationship between categories and products
        public List<Product>? Products { get; set; }
    }
}
