using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseManagementSystem.Task4_BusinessAndSecurity.Validation;

public interface IValidator<T>
{
    ValidationResult Validate(T entity);
}
