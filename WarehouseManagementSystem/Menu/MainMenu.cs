using System.Globalization;
using WarehouseManagementSystem.Shared.Enums;
using WarehouseManagementSystem.Task1_DataModel.Products;
using WarehouseManagementSystem.Task2_UserManagement;
using WarehouseManagementSystem.Task4_BusinessAndSecurity.Logging;

namespace WarehouseManagementSystem.Menu;

public class MainMenu
{
    private readonly WarehouseService _service;
    private readonly User _currentUser;

    public MainMenu(WarehouseService service, User currentUser)
    {
        _service = service;
        _currentUser = currentUser;
    }

    public void Show()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("=== Warehouse Management System ===");
            Console.WriteLine("1. Add product");
            Console.WriteLine("2. Remove product");
            Console.WriteLine("3. Update product");
            Console.WriteLine("4. Show products");
            Console.WriteLine("5. Block user");
            Console.WriteLine("6. Unblock user");
            Console.WriteLine("0. Exit");
            Console.WriteLine();
            Console.Write("Select an option: ");
            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1": AddProductMenu(); break;
                case "2": RemoveProductMenu(); break;
                case "3": UpdateProductMenu(); break;
                case "4": ShowProductMenu(); break;
                case "5": BlockUserMenu(); break;
                case "6": UnblockUserMenu(); break;
                case "0": return;
                default:
                    Console.WriteLine("Invalid option.");
                    Console.ReadKey();
                    break;
            }
        }
    }

    private void AddProductMenu()
    {
        Console.Clear();
        Console.WriteLine("=== Add Product ===");
        foreach (var productType in Enum.GetValues(typeof(ProductType)))
        {
            Console.WriteLine($"{(int)productType}.{productType}:");
        }
        Console.WriteLine();
        Console.Write("Choose product type: ");
        var option = Console.ReadLine();
        
        Console.Clear();
        
        Console.Write("Enter product name:");
        string? productName = Console.ReadLine();
        
        Console.Write("Enter product price:");
        if (!double.TryParse(Console.ReadLine(),
                NumberStyles.Any,
                CultureInfo.InvariantCulture,
                out double productPrice))
        {
            Console.WriteLine("Invalid product price.");
            Console.ReadKey();
            return;
        }
        Console.Write("Enter product weight:");
        if (!double.TryParse(Console.ReadLine(),
                NumberStyles.Any,
                CultureInfo.InvariantCulture,
                out double productWeight))
        {
            Console.WriteLine("Invalid product weight");
            Console.ReadKey();
            return;
        }
        Console.Write("Enter product quantity:");
        if (!int.TryParse(Console.ReadLine(), out int productQuantity))
        {
            Console.WriteLine("Invalid product quantity.");
            Console.ReadKey();
            return;
        }
        switch (option)
        {
            case "1":
            {
                Console.Write("Enter product expiry date (in days):");
                if (!int.TryParse(Console.ReadLine(), out int productExpiryDate))
                {
                    Console.WriteLine("Invalid product expiry date.");
                    Console.ReadKey();
                    return;
                }
                DateTime expiryDate = DateTime.Today.AddDays(productExpiryDate);
                Product product = new PerishableProduct(expiryDate, productName, productPrice,  productWeight, productQuantity);
                _service.AddProduct(_currentUser, product);
                break;
            }
            case "2":
            {
                Console.Write("Enter product warranty date (in days):");
                if (!int.TryParse(Console.ReadLine(), out int warrantyDateDays))
                {
                    Console.WriteLine("Invalid product warranty date.");
                    Console.ReadKey();
                    return;
                }
                Console.Write("Enter product voltage:");
                if (!double.TryParse(Console.ReadLine(),
                        NumberStyles.Any,
                        CultureInfo.InvariantCulture,
                        out double voltage))
                {
                    Console.WriteLine("Invalid product voltage.");
                    Console.ReadKey();
                    return;
                }
                DateTime warrantyDate = DateTime.Today.AddDays(warrantyDateDays);
                Product product = new Electronics(warrantyDate, voltage , productName, productPrice, productWeight, productQuantity);
                _service.AddProduct(_currentUser, product);
                break;
            }
            case "3":
            {
                Console.Write("Enter product max shaking height: ");
                if (!double.TryParse(Console.ReadLine(),
                        NumberStyles.Any,
                        CultureInfo.InvariantCulture,
                        out double maxShakingHeight))
                {
                    Console.WriteLine("Invalid product max shaking height.");
                    Console.ReadKey();
                    return;
                }
                Product product = new FragileProduct(maxShakingHeight, productName, productPrice, productWeight , productQuantity);
                _service.AddProduct(_currentUser, product);
                break;
            }
            default:
            {
                Console.WriteLine("Invalid option.");
                Console.ReadKey();
                break;
            }
        }
    }

    private void RemoveProductMenu()
    {
        Console.Clear();
        Console.WriteLine("=== Remove Product ===");
        Console.Write("Enter product Id: ");
        if (!Guid.TryParse(Console.ReadLine(), out Guid productId))
        {
            Console.WriteLine("Invalid product id.");
            Console.ReadKey();
            return;
        }
        _service.RemoveProduct(_currentUser, productId);
    }

    private void UpdateProductMenu()
    {
        Console.Clear();
        Console.WriteLine("=== Update Product ===");
        Console.Write("Enter product Id: ");
        if (!Guid.TryParse(Console.ReadLine(), out Guid productId))
        {
            Console.WriteLine("Invalid product id.");
            Console.ReadKey();
            return;
        }
        Console.WriteLine("1.Change price");
        Console.WriteLine("2.Change quantity");
        Console.Write("Choose: ");
        if (!int.TryParse(Console.ReadLine(), out int choice))
        {
            Console.WriteLine("Invalid choice.");
            Console.ReadKey();
            return;
        }
        Console.WriteLine();
        switch (choice)
        {
            case 1:
            {
                Console.Write("Enter new price: ");
                if (!double.TryParse(Console.ReadLine(),
                        NumberStyles.Any,
                        CultureInfo.InvariantCulture,
                        out double newPrice))
                {
                    Console.WriteLine("Invalid product price.");
                    Console.ReadKey();
                    return;
                }
                _service.UpdateProduct(_currentUser, productId, choice ,newPrice, null);
                break;
            }
            case 2:
            {
                Console.Write("Enter new quantity: ");
                if (!int.TryParse(Console.ReadLine(), out int newQuantity))
                {
                    Console.WriteLine("Invalid product quantity.");
                    Console.ReadKey();
                    return;
                }
                _service.UpdateProduct(_currentUser, productId, choice , null, newQuantity);
                break;
            }
            default:
                Console.WriteLine("Invalid choice.");
                Console.ReadKey();
                break;
        }
    }

    private void ShowProductMenu()
    {
        Console.Clear();
        Console.WriteLine("=== Show Products ===");
        _service.ShowProducts(_currentUser);
        Console.ReadKey();
    }
    private void BlockUserMenu()
    {
        Console.Clear();
        Console.WriteLine("=== Block User Menu ===");
        Console.Write("Enter user Id: ");
        if (!Guid.TryParse(Console.ReadLine(), out Guid userId))
        {
            Console.WriteLine("Invalid product id.");
            Console.ReadKey();
            return;
        }
        _service.BlockUser(_currentUser, userId);
        Console.ReadKey();
    }
    private void UnblockUserMenu()
    {
        Console.Clear();
        Console.WriteLine("=== Unblock User Menu ===");
        Console.Write("Enter user Id: ");
        if (!Guid.TryParse(Console.ReadLine(), out Guid userId))
        {
            Console.WriteLine("Invalid product id.");
            Console.ReadKey();
            return;
        }
        _service.UnblockUser(_currentUser, userId);
    }
}