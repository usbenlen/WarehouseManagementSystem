using System.Data;
using WarehouseManagementSystem.Task1_DataModel.Products;
using WarehouseManagementSystem.Task3_WarehouseLogic;
using WarehouseManagementSystem.Task4_BusinessAndSecurity.Validation;
using WarehouseManagementSystem.Task4_BusinessAndSecurity.Logging;

namespace WarehouseManagementSystem.Task2_UserManagement;

public class WarehouseService
{
    private readonly Warehouse _warehouse;
    private readonly IValidator<Product> _productsValidator;
    private readonly IValidator<User> _usersValidator;
    private readonly ILogger _logger;
    
    public WarehouseService(Warehouse warehouse
    , IValidator<Product> productsValidator
    , IValidator<User> usersValidator
    , ILogger logger)
    {
        _warehouse = warehouse;
        _productsValidator = productsValidator;
        _usersValidator = usersValidator;
        _logger = logger;
    }
    public void AddProduct(User user, Product product)
    {
        var userValidationResult = _usersValidator.Validate(user);
        if (!userValidationResult.IsValid)
        {
            Console.WriteLine("This user is blocked");
            _logger.Warn($"Blocked User:{user.UserName} tried add product. {DateTime.Now}");
            
            return;
        }
        var productValidationResult = _productsValidator.Validate(product);
        if (!productValidationResult.IsValid)
        {
            Console.WriteLine("Invalid product");
            _logger.Error($"Trying to add invalid product. {DateTime.Now}");
            return;
        }
        if (!AccessControl.CanAddProduct(user))
        {
            Console.WriteLine("This user is not allowed to add product");
            _logger.Warn($"User: {user.UserName} is not allowed to add product. {DateTime.Now}");
            return;
        }
        _warehouse.AddProduct(product);
        _logger.Info($"User: {user.UserName} Successfully added \"{product.name}\". {DateTime.Now}");
    }

    public void RemoveProduct(User user, Product product)
    {
        var userValidationResult = _usersValidator.Validate(user);
        if (!userValidationResult.IsValid)
        {
            Console.WriteLine("This user is blocked");
            _logger.Warn($"Blocked User:{user.UserName} tried remove product. {DateTime.Now}");
            return;
        }
        if (!AccessControl.CanAddProduct(user))
        {
            Console.WriteLine("This user is not allowed to remove product");
            _logger.Warn($"User: {user.UserName} is not allowed to remove product. {DateTime.Now}");
            return;
        }
        _warehouse.RemoveProduct(product.id);
        _logger.Info($"User: {user.UserName} Successfully removed \"{product.name}\". {DateTime.Now}");
    }

    public void BlockUser(User user, User user2)
    {
        var userValidationResult = _usersValidator.Validate(user);
        if (!userValidationResult.IsValid)
        {
            Console.WriteLine("This user is blocked");
            _logger.Warn($"Blocked User:{user.UserName} tried to block user. {DateTime.Now}");
            return;
        }
        if(user == user2) {return;}

        if (!AccessControl.CanManageUsers(user))
        {
            Console.WriteLine("This user is not allowed to manage users");
            _logger.Warn($"User: {user.UserName} is not allowed to block users. {DateTime.Now}");
            return;
        }
        user2.Block();
        _logger.Info($"User: {user.UserName} Successfully banned {user2.UserName}. {DateTime.Now}");
    }

    public void UnblockUser(User user, User user2)
    {
        var userValidationResult = _usersValidator.Validate(user);
        if (!userValidationResult.IsValid)
        {
            Console.WriteLine("This user is blocked");
            _logger.Warn($"Blocked User:{user.UserName} tried to unblock user. {DateTime.Now}");
            return;
        }
        if(user == user2) {return;}

        if (!AccessControl.CanManageUsers(user))
        {
            Console.WriteLine("This user is not allowed to unblock user");
            _logger.Warn($"User: {user.UserName} is not allowed to unblock users. {DateTime.Now}");
            return;
        }
        user2.Unblock();
        _logger.Info($"User: {user.UserName} Successfully unbanned {user2.UserName}. {DateTime.Now}");
    }

    public void UpdateProduct(User user, Guid id, int choice, double? price, int? quantity)
    {
        if (!_usersValidator.Validate(user).IsValid)
        {
            Console.WriteLine("This user is blocked");
            _logger.Warn($"Blocked User:{user.UserName} tried to update product. {DateTime.Now}");
            return;
        }

        if (!AccessControl.CanAddProduct(user))
        {
            Console.WriteLine("This user is not allowed to add product");
            _logger.Warn($"User: {user.UserName} is not allowed to update product. {DateTime.Now}");
            return;
        }
        switch (choice)
        {
            case 1:
            {
                if (price == null)
                {
                    Console.WriteLine("Price is required");
                    _logger.Error($"Failed to update product price. {DateTime.Now}");
                    return;
                }
                _warehouse.ChangeProductPrice(id , price.Value);
                _logger.Info($"User: {user.UserName} Successfully updated price of product {id}. {DateTime.Now}");
                break;
            }
            case 2:
            {
                if (quantity == null)
                {
                    Console.WriteLine("Quantity is required");
                    _logger.Error($"Failed to update product quantity. {DateTime.Now}");
                    return;
                }
                _warehouse.ChangeProductQuantity(id, quantity.Value);
                _logger.Info($"User: {user.UserName} Successfully updated quantity of product {id}. {DateTime.Now}");
                break;
            }
            default:
                Console.WriteLine("Invalid operation");
                _logger.Error($"Failed to update product. {DateTime.Now}");
                break;
        }
    }
}