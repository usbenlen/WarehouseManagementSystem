using WarehouseManagementSystem.Task1_DataModel.Products;

namespace WarehouseManagementSystem.Task4_BusinessAndSecurity.Validation;

public class ProductValidator : IValidator<Product>
{
    public ValidationResult Validate(Product product)
    {
        var result = new ValidationResult();
        if (string.IsNullOrWhiteSpace(product.Name))
        {
            result.Errors.Add("Product name is required");
        }

        if (product.Quantity < 0)
        {
            result.Errors.Add("Quantity can't be negative");
        }

        if (product.Weight < 0)
        {
            result.Errors.Add("Weight can't be negative");
        }

        if (product.BasePrice < 0)
        {
            result.Errors.Add("Base Price can't be negative");
        }
        return result;
    }
}
