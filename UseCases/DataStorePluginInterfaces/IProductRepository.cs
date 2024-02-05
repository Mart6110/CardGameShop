using CoreBusiness; // Import statement for the CoreBusiness namespace

namespace UseCases.DataStorePluginInterfaces // Namespace declaration
{
    // Interface defining the contract for a product repository
    public interface IProductRepository
    {
        IEnumerable<Product> GetProducts(bool loadCategory = false); // Method to retrieve all products, optionally loading category information
        void AddProduct(Product product); // Method to add a new product
        void UpdateProduct(int productId, Product product); // Method to update a product
        Product? GetProductById(int productId, bool loadCategory = false); // Method to retrieve a product by ID, optionally loading category information
        void DeleteProduct(int productId); // Method to delete a product by ID
        IEnumerable<Product> GetProductsByCategoryId(int categoryId); // Method to retrieve all products belonging to a specific category
    }
}
