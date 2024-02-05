using System.ComponentModel.DataAnnotations; // Import statements for namespaces
using UseCases;

namespace CardGameShop.ViewModels.Validations // Namespace declaration
{
    // Custom validation attribute class for ensuring proper quantity when selling products
    public class SalesViewModel_EnsureProperQuantity : ValidationAttribute
    {
        // Method to validate the quantity to sell
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var salesViewModel = validationContext.ObjectInstance as SalesViewModel; // Get the sales view model

            if (salesViewModel != null) // Check if the view model is not null
            {
                if (salesViewModel.QuantityToSell <= 0) // Check if the quantity to sell is less than or equal to zero
                {
                    return new ValidationResult("The quantity to sell has to be greater than zero."); // Return an error message
                }
                else
                {
                    var getProductByIdUseCase = validationContext.GetService(typeof(IViewSelectedProductUseCase)) as IViewSelectedProductUseCase; // Get the use case for viewing a selected product

                    if (getProductByIdUseCase != null) // Check if the use case is not null
                    {
                        var product = getProductByIdUseCase.Execute(salesViewModel.SelectedProductId); // Get the selected product
                        if (product != null) // Check if the product exists
                        {
                            if (product.Quantity < salesViewModel.QuantityToSell) // Check if the quantity to sell exceeds the available quantity of the product
                                return new ValidationResult($"{product.Name} only has {product.Quantity} left. It is not enough."); // Return an error message
                        }
                        else
                        {
                            return new ValidationResult("The selected product doesn't exist."); // Return an error message
                        }
                    }
                }
            }

            return ValidationResult.Success; // Return success if validation passes
        }
    }
}
