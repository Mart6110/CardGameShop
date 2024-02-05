using CoreBusiness; // Import statements for namespaces

namespace CardGameShop.ViewModels // Namespace declaration
{
    // View model class for representing product data
    public class ProductViewModel
    {
        // Property to store a collection of categories, initialized as an empty list
        public IEnumerable<Category> Categories { get; set; } = new List<Category>();

        // Property to store a product, initialized as a new instance
        public Product Product { get; set; } = new Product();
    }
}
