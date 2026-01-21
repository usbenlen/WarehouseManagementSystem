using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using WarehouseManagementSystem.Task1_DataModel.Products;

namespace WarehouseManagementSystem.Task4_BusinessAndSecurity.Validation;

public class ProductValidator : IValidator<Product>
{
    public ValidationResult Validate(Product product)
    {
        var result = new ValidationResult();
        if (string.IsNullOrWhiteSpace(product.name))
        {
            result.Errors.Add("Product name is required");
        }

        if (product.quantity < 0)
        {
            result.Errors.Add("Quantity can't be negative");
        }

        if (product.weight < 0)
        {
            result.Errors.Add("Weight can't be negative");
        }

        if (product.basePrice < 0)
        {
            result.Errors.Add("Base Price can't be negative");
        }
        return result;
    }
}
