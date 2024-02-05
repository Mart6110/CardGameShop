using Microsoft.AspNetCore.Mvc; // Import statements for namespaces
using UseCases.CategoriesUseCases;
using CoreBusiness;
using Microsoft.AspNetCore.Authorization;

namespace CardGameShop.Controllers // Namespace declaration
{
    // Controller class for managing categories, requiring authorization based on the "Inventory" policy
    [Authorize(Policy = "Inventory")]
    public class CategoriesController : Controller
    {
        // Dependency injection of use case interfaces
        private readonly IViewCategoriesUseCase viewCategoriesUseCase;
        private readonly IViewSelectedCategoryUseCase viewSelectedCategoryUseCase;
        private readonly IEditCategoryUseCase editCategoryUseCase;
        private readonly IAddCategoryUseCase addCategoryUseCase;
        private readonly IDeleteCategoryUseCase deleteCategoryUseCase;

        // Constructor to inject use case interfaces
        public CategoriesController(
            IViewCategoriesUseCase viewCategoriesUseCase,
            IViewSelectedCategoryUseCase viewSelectedCategoryUseCase,
            IEditCategoryUseCase editCategoryUseCase,
            IAddCategoryUseCase addCategoryUseCase,
            IDeleteCategoryUseCase deleteCategoryUseCase)
        {
            this.viewCategoriesUseCase = viewCategoriesUseCase;
            this.viewSelectedCategoryUseCase = viewSelectedCategoryUseCase;
            this.editCategoryUseCase = editCategoryUseCase;
            this.addCategoryUseCase = addCategoryUseCase;
            this.deleteCategoryUseCase = deleteCategoryUseCase;
        }

        // Action method to display a list of categories
        public IActionResult Index()
        {
            var categories = viewCategoriesUseCase.Execute();
            return View(categories);
        }

        // Action method to display the form for editing a category
        public IActionResult Edit(int? id)
        {
            ViewBag.Action = "edit";

            var category = viewSelectedCategoryUseCase.Execute(id.HasValue ? id.Value : 0);

            return View(category);
        }

        // Action method to handle the form submission for editing a category
        [HttpPost]
        public IActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                editCategoryUseCase.Execute(category.CategoryId, category);
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Action = "edit";
            return View(category);
        }

        // Action method to display the form for adding a new category
        public IActionResult Add()
        {
            ViewBag.Action = "add";

            return View();
        }

        // Action method to handle the form submission for adding a new category
        [HttpPost]
        public IActionResult Add(Category category)
        {
            if (ModelState.IsValid)
            {
                addCategoryUseCase.Execute(category);
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Action = "add";
            return View(category);
        }

        // Action method to delete a category
        public IActionResult Delete(int categoryId)
        {
            deleteCategoryUseCase.Execute(categoryId);
            return RedirectToAction(nameof(Index));
        }

    }
}
