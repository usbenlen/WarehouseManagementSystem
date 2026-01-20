using WarehouseManagementSystem.Task1_DataModel.Products;
using WarehouseManagementSystem.Task3_WarehouseLogic;
using WarehouseManagementSystem.Task4_BusinessAndSecurity.Validation;

namespace WarehouseManagementSystem.Task2_UserManagement;

public class WarehouseService
{
    private readonly Warehouse _warehouse;
    private readonly IValidator<Product> _productsValidator;
    private readonly IValidator<User> _usersValidator;
    
    public WarehouseService(Warehouse warehouse
    , IValidator<Product> productsValidator
    , IValidator<User> usersValidator)
    {
        _warehouse = warehouse;
        _productsValidator = productsValidator;
        _usersValidator = usersValidator;
    }
    public void AddProduct(User user, Product product)
    {
        var userValidationResult = _usersValidator.Validate(user);
        if (!userValidationResult.IsValid)
        {
            Console.WriteLine("This user is blocked");
            return;
        }
        var productValidationResult = _productsValidator.Validate(product);
        if (!productValidationResult.IsValid)
        {
            Console.WriteLine("Invalid product");
            return;
        }
        if (!AccessControl.CanAddProduct(user))
        {
            Console.WriteLine("This user is not allowed to add product");
            return;
        }
        _warehouse.AddProduct(product);
    }

    public void RemoveProduct(User user, Product product)
    {
        var userValidationResult = _usersValidator.Validate(user);
        if (!userValidationResult.IsValid)
        {
            Console.WriteLine("This user is blocked");
            return;
        }
        if (!AccessControl.CanAddProduct(user))
        {
            Console.WriteLine("This user is not allowed to remove product");
            return;
        }
        _warehouse.RemoveProduct(product.id);
    }

    public void BlockUser(User user, User user2)
    {
        var userValidationResult = _usersValidator.Validate(user);
        if (!userValidationResult.IsValid)
        {
            Console.WriteLine("This user is blocked");
            return;
        }
        if(user == user2) {return;}

        if (!AccessControl.CanManageUsers(user))
        {
            Console.WriteLine("This user is not allowed to manage users");
            return;
        }
        user2.Block();
    }

    public void UnblockUser(User user, User user2)
    {
        var userValidationResult = _usersValidator.Validate(user);
        if (!userValidationResult.IsValid)
        {
            Console.WriteLine("This user is blocked");
            return;
        }
        if(user == user2) {return;}

        if (!AccessControl.CanManageUsers(user))
        {
            Console.WriteLine("This user is not allowed to unblock user");
            return;
        }
        user2.Unblock();
    }

    public void UpdateProduct(User user, Guid id, int choice, double? price, int? quantity)
    {
        if (!_usersValidator.Validate(user).IsValid)
        {
            Console.WriteLine("This user is blocked");
            return;
        }

        if (!AccessControl.CanAddProduct(user))
        {
            Console.WriteLine("This user is not allowed to add product");
            return;
        }
        switch (choice)
        {
            case 1:
            {
                if (price == null)
                {
                    Console.WriteLine("Price is required");
                    return;
                }
                _warehouse.ChangeProductPrice(id , price.Value);
                break;
            }
            case 2:
            {
                if (quantity == null)
                {
                    Console.WriteLine("Quantity is required");
                    return;
                }
                _warehouse.ChangeProductQuantity(id, quantity.Value);
                break;
            }
            default:
                Console.WriteLine("Invalid operation");
                break;
        }
    }
}