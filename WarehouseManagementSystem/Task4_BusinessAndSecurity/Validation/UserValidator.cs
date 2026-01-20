using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using WarehouseManagementSystem.Task2_UserManagement;

namespace WarehouseManagementSystem.Task4_BusinessAndSecurity.Validation;

public class UserValidator : IValidator<User>
{
    public ValidationResult Validate(User user)
    {
        var result = new ValidationResult();

        if (string.IsNullOrWhiteSpace(user.UserName))
        {
            result.Errors.Add("User name is required");
        }

        if (user.IsBlocked)
        {
            result.Errors.Add("User is blocked");
        }
        return result;
    }
}
