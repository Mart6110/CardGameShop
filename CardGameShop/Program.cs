using Microsoft.EntityFrameworkCore; // Import statements for namespaces
using Plugins.DataStore.InMemory;
using Plugins.DataStore.SQL;
using System.Net.Mime;
using System.Text;
using UseCases;
using UseCases.CategoriesUseCases;
using UseCases.DataStorePluginInterfaces;
using UseCases.ProductsUseCases;
using Microsoft.AspNetCore.Identity;
using CardGameShop.Data;

namespace CardGameShop // Namespace declaration
{
    // Main program class
    public class Program
    {
        // Main method
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args); // Create a new instance of the web application builder

            // Add database context for account management
            builder.Services.AddDbContext<AccountContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("MarketManagement")); // Use SQL Server as the database provider
            });

            // Add database context for market data
            builder.Services.AddDbContext<MarketContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("MarketManagement")); // Use SQL Server as the database provider
            });

            // Add default identity for authentication and authorization
            builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<AccountContext>(); // Use Entity Framework Core for user storage

            builder.Services.AddRazorPages(); // Add Razor Pages support

            // Add controllers with views
            builder.Services.AddControllersWithViews();

            // Add authorization policies
            builder.Services.AddAuthorization(options =>
            {
                options.AddPolicy("Inventory", p => p.RequireClaim("Position", "Inventory")); // Policy requiring the "Inventory" claim
                options.AddPolicy("Cashiers", p => p.RequireClaim("Position", "Cashier")); // Policy requiring the "Cashier" claim
            });

            // Add repositories based on environment
            if (builder.Environment.IsEnvironment("QA"))
            {
                builder.Services.AddSingleton<ICategoryRepository, CategoriesInMemoryRepository>(); // Use in-memory repository for QA environment
                builder.Services.AddSingleton<IProductRepository, ProductsInMemoryRepository>(); // Use in-memory repository for QA environment
                builder.Services.AddSingleton<ITransactionRepository, TransactionsInMemoryRepository>(); // Use in-memory repository for QA environment
            }
            else
            {
                builder.Services.AddTransient<ICategoryRepository, CategorySQLRepository>(); // Use SQL repository for other environments
                builder.Services.AddTransient<IProductRepository, ProductSQLRepository>(); // Use SQL repository for other environments
                builder.Services.AddTransient<ITransactionRepository, TransactionSQLRepository>(); // Use SQL repository for other environments
            }

            // Add use cases
            builder.Services.AddTransient<IViewCategoriesUseCase, ViewCategoriesUseCase>(); // View categories use case
            builder.Services.AddTransient<IViewSelectedCategoryUseCase, ViewSelectedCategoryUseCase>(); // View selected category use case
            builder.Services.AddTransient<IEditCategoryUseCase, EditCategoryUseCase>(); // Edit category use case
            builder.Services.AddTransient<IAddCategoryUseCase, AddCategoryUseCase>(); // Add category use case
            builder.Services.AddTransient<IDeleteCategoryUseCase, DeleteCategoryUseCase>(); // Delete category use case

            builder.Services.AddTransient<IViewProductsUseCase, ViewProductsUseCase>(); // View products use case
            builder.Services.AddTransient<IAddProductUseCase, AddProductUseCase>(); // Add product use case
            builder.Services.AddTransient<IEditProductUseCase, EditProductUseCase>(); // Edit product use case
            builder.Services.AddTransient<IViewProductsInCategoryUseCase, ViewProductsInCategoryUseCase>(); // View products in category use case
            builder.Services.AddTransient<IDeleteProductUseCase, DeleteProductUseCase>(); // Delete product use case
            builder.Services.AddTransient<IViewSelectedProductUseCase, ViewSelectedProductUseCase>(); // View selected product use case
            builder.Services.AddTransient<ISellProductUseCase, SellProductUseCase>(); // Sell product use case

            builder.Services.AddTransient<IRecordTransactionUseCase, RecordTransactionUseCase>(); // Record transaction use case
            builder.Services.AddTransient<IGetTodayTransactionsUseCase, GetTodayTransactionsUseCase>(); // Get today's transactions use case
            builder.Services.AddTransient<ISearchTransactionsUseCase, SearchTransactionsUseCase>(); // Search transactions use case

            var app = builder.Build(); // Build the web application

            // Configure the HTTP request pipeline
            if (!app.Environment.IsDevelopment()) // If not in development environment
            {
                app.UseExceptionHandler("/Home/Error"); // Use error handling for exceptions
                app.UseHsts(); // Use HTTP strict transport security
            }

            app.UseHttpsRedirection(); // Redirect HTTP requests to HTTPS
            app.UseStaticFiles(); // Serve static files

            app.UseRouting(); // Use routing

            app.UseAuthentication(); // Use authentication
            app.UseAuthorization(); // Use authorization

            app.MapRazorPages(); // Map Razor Pages
            app.MapControllerRoute( // Map controller route
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}"); // Default route

            app.Run(); // Run the application
        }
    }
}
