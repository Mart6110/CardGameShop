using CardGameShop.ViewModels; // Import statements for namespaces
using Microsoft.AspNetCore.Mvc;
using CoreBusiness;
using UseCases.CategoriesUseCases;
using UseCases;
using Microsoft.AspNetCore.Authorization;
using UseCases.ProductsUseCases;

namespace CardGameShop.Controllers // Namespace declaration
{
    // Controller class for managing sales, requiring authorization based on the "Cashiers" policy
    [Authorize(Policy = "Cashiers")]
    public class SalesController : Controller
    {
        // Dependency injection of use case interfaces
        private readonly IViewCategoriesUseCase viewCategoriesUseCase;
        private readonly IViewSelectedProductUseCase viewSelectedProductUseCase;
        private readonly ISellProductUseCase sellProductUseCase;
        private readonly IViewProductsInCategoryUseCase viewProductsInCategoryUseCase;

        // Constructor to inject use case interfaces
        public SalesController(IViewCategoriesUseCase viewCategoriesUseCase,
            IViewSelectedProductUseCase viewSelectedProductUseCase,
            ISellProductUseCase sellProductUseCase,
            IViewProductsInCategoryUseCase viewProductsInCategoryUseCase)
        {
            this.viewCategoriesUseCase = viewCategoriesUseCase;
            this.viewSelectedProductUseCase = viewSelectedProductUseCase;
            this.sellProductUseCase = sellProductUseCase;
            this.viewProductsInCategoryUseCase = viewProductsInCategoryUseCase;
        }

        // Action method to display the sales page
        public IActionResult Index()
        {
            var salesViewModel = new SalesViewModel
            {
                Categories = viewCategoriesUseCase.Execute()
            };
            return View(salesViewModel); // Return the sales view with the view model containing categories
        }

        // Action method to load the partial view for selling a product
        public IActionResult SellProductPartial(int productId)
        {
            var product = viewSelectedProductUseCase.Execute(productId);
            return PartialView("_SellProduct", product); // Return the partial view for selling a product with the product data
        }

        // Action method to handle selling a product
        public IActionResult Sell(SalesViewModel salesViewModel)
        {
            if (ModelState.IsValid)
            {
                // Sell the product
                sellProductUseCase.Execute(
                    "cashier1",
                    salesViewModel.SelectedProductId,
                    salesViewModel.QuantityToSell);
            }

            var product = viewSelectedProductUseCase.Execute(salesViewModel.SelectedProductId);
            salesViewModel.SelectedCategoryId = (product?.CategoryId == null) ? 0 : product.CategoryId.Value;
            salesViewModel.Categories = viewCategoriesUseCase.Execute();

            return View("Index", salesViewModel); // Return to the sales page with updated data
        }

        // Action method to load the partial view for displaying products by category
        public IActionResult ProductsByCategoryPartial(int categoryId)
        {
            var products = viewProductsInCategoryUseCase.Execute(categoryId);

            return PartialView("_Products", products); // Return the partial view for displaying products by category with the products data
        }
    }
}
