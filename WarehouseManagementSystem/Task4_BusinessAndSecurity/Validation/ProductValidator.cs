using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using WarehouseManagementSystem.Task1_DataModel.Products;

namespace WarehouseManagementSystem.Task4_BusinessAndSecurity.Validation;

public class ProductValidator : IValidator<Product>
{
    public ValidationResult Validate(Product entity)
    {
        var result = new ValidationResult();
        if (string.IsNullOrWhiteSpace(entity.name))
        {
            result.Errors.Add("Product name is required");
        }

        if (entity.quantity < 0)
        {
            result.Errors.Add("Quantity can't be negative");
        }

        if (entity.weight < 0)
        {
            result.Errors.Add("Weight can't be negative");
        }
        return result;
    }
}
