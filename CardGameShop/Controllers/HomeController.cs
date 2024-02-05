using Microsoft.AspNetCore.Mvc; // Import statements for namespaces
using System.Diagnostics;

namespace CardGameShop.Controllers // Namespace declaration
{
    // Controller class for handling home-related actions
    public class HomeController : Controller
    {
        // Action method to display the home page
        public IActionResult Index()
        {
            return View(); // Return the default view for the home page
        }
    }
}
