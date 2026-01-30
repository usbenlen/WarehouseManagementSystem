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
        _service.AuthLog(_currentUser);
    }

    public bool Show()
    {
        bool switchAccount = false;

        switch (_currentUser.Role)
        {
            case UserRole.Admin: AdminMenu(ref switchAccount); break;
            case UserRole.Storekeeper: StorekeeperMenu(ref switchAccount); break;
            case UserRole.Manager: ManageMenu(ref switchAccount); break;
        }

        _service.Save();
        return switchAccount;
    }

    private delegate bool TryParseDelegate<T>(string? input, out T value);

    private bool TryRead<T>(string message, TryParseDelegate<T> tryParse, out T value)
    {
        Console.Write(message);
        if (!tryParse(Console.ReadLine(), out value))
        {
            Console.WriteLine("Invalid input.");
            Console.ReadKey();
            return false;
        }
        return true;
    }

    private Product? CreateProductByType(string? option)
    {
        Console.Write("Enter product name: ");
        string? name = Console.ReadLine();

        if (!TryRead("Enter product price: ",
                (string? s, out double v) => double.TryParse(s, NumberStyles.Any, CultureInfo.InvariantCulture, out v),
                out double price)) return null;

        if (!TryRead("Enter product weight: ",
                (string? s, out double v) => double.TryParse(s, NumberStyles.Any, CultureInfo.InvariantCulture, out v),
                out double weight)) return null;

        if (!TryRead("Enter product quantity: ", int.TryParse, out int quantity)) return null;

        switch (option)
        {
            case "1":
                if (!TryRead("Enter product expiry date (in days): ", int.TryParse, out int days))
                    return null;
                return new PerishableProduct(DateTime.Today.AddDays(days), name, price, weight, quantity);

            case "2":
                if (!TryRead("Enter product warranty date (in days): ", int.TryParse, out int warrantyDays))
                    return null;

                if (!TryRead("Enter product voltage: ",
                        (string? s, out double v) => double.TryParse(s, NumberStyles.Any, CultureInfo.InvariantCulture, out v),
                        out double voltage)) return null;

                return new Electronics(DateTime.Today.AddDays(warrantyDays), voltage, name, price, weight, quantity);

            case "3":
                if (!TryRead("Enter product max shaking height: ",
                        (string? s, out double v) => double.TryParse(s, NumberStyles.Any, CultureInfo.InvariantCulture, out v),
                        out double height)) return null;

                return new FragileProduct(height, name, price, weight, quantity);

            default:
                Console.WriteLine("Invalid option.");
                Console.ReadKey();
                return null;
        }
    }

    private void AddProductMenu()
    {
        Console.Clear();
        Console.WriteLine("=== Add Product ===");

        foreach (var type in Enum.GetValues(typeof(ProductType)))
            Console.WriteLine($"{(int)type}. {type}");

        Console.Write("Choose product type: ");
        var option = Console.ReadLine();

        Console.Clear();
        var product = CreateProductByType(option);
        if (product != null) _service.AddProduct(_currentUser, product);
    }

    private void RemoveProductMenu()
    {
        Console.Clear();
        Console.WriteLine("=== Remove Product ===");

        if (!TryRead("Enter product Id: ", Guid.TryParse, out Guid productId)) return;

        _service.RemoveProduct(_currentUser, productId);
    }


    private void UpdateProductMenu()
    {
        Console.Clear();
        Console.WriteLine("=== Update Product ===");

        if (!TryRead("Enter product Id: ", Guid.TryParse, out Guid productId)) return;

        Console.WriteLine("1. Change price");
        Console.WriteLine("2. Change quantity");
        Console.Write("Choose: ");

        if (!TryRead("Choose: ", int.TryParse, out int choice)) return;

        switch (choice)
        {
            case 1:
                if (!TryRead("Enter new price: ",
                        (string? s, out double v) => double.TryParse(s, NumberStyles.Any, CultureInfo.InvariantCulture, out v),
                        out double newPrice)) return;

                _service.UpdateProduct(_currentUser, productId, choice, newPrice, null);
                break;

            case 2:
                if (!TryRead("Enter new quantity: ", int.TryParse, out int newQuantity)) return;

                _service.UpdateProduct(_currentUser, productId, choice, null, newQuantity);
                break;

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
        if (!TryRead("Enter user Id: ", Guid.TryParse, out Guid userId)) return;

        _service.BlockUser(_currentUser, userId);
        Console.ReadKey();
    }

    private void UnblockUserMenu()
    {
        Console.Clear();
        if (!TryRead("Enter user Id: ", Guid.TryParse, out Guid userId)) return;

        _service.UnblockUser(_currentUser, userId);
    }
    private void AddUserMenu()
    {
        Console.Clear();
        Console.Write("Enter user name: ");
        var userName = Console.ReadLine();

        Console.Write("Enter password: ");
        var password = Console.ReadLine();

        Console.WriteLine("Enter role:");
        foreach (var role in Enum.GetValues(typeof(UserRole)))
            Console.WriteLine($"{(int)role}. {role}");

        if (!TryRead("Choose: ", int.TryParse, out int choice)) return;

        var roles = Enum.GetValues(typeof(UserRole)).Cast<UserRole>().ToArray();

        if (choice < 1 || choice > roles.Length)
        {
            Console.WriteLine("Invalid choice.");
            Console.ReadKey();
            return;
        }

        UserRole selectedRole = roles[choice - 1];
        _service.AddUser(_currentUser, userName, password, selectedRole);
    }

    private void RemoveUserMenu()
    {
        Console.Clear();
        if (!TryRead("Enter user Id: ", Guid.TryParse, out Guid userId)) return;

        _service.RemoveUser(_currentUser, userId);
    }

    private void ShowUserMenu()
    {
        Console.Clear();
        Console.WriteLine("=== Users ===");
        _service.ShowUsers(_currentUser);
        Console.ReadKey();
    }
    private void AdminMenu(ref bool switchAccount)
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
            Console.WriteLine("7. Add user");
            Console.WriteLine("8. Delete user");
            Console.WriteLine("9. Show users");
            Console.WriteLine("10. Switch account");
            Console.WriteLine("0. Exit");
            Console.WriteLine();
            Console.Write("Select an option: ");

            switch (Console.ReadLine())
            {
                case "1": AddProductMenu(); break;
                case "2": RemoveProductMenu(); break;
                case "3": UpdateProductMenu(); break;
                case "4": ShowProductMenu(); break;
                case "5": BlockUserMenu(); break;
                case "6": UnblockUserMenu(); break;
                case "7": AddUserMenu(); break;
                case "8": RemoveUserMenu(); break;
                case "9": ShowUserMenu(); break;
                case "10": switchAccount = true; return;
                case "0": switchAccount = false; return;
                default:
                    Console.WriteLine("Invalid option.");
                    Console.ReadKey();
                    break;
            }
        }
    }
    private void StorekeeperMenu(ref bool switchAccount)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("=== Warehouse Management System ===");
            Console.WriteLine("1. Add product");
            Console.WriteLine("2. Remove product");
            Console.WriteLine("3. Update product");
            Console.WriteLine("4. Switch account");
            Console.WriteLine("0. Exit");
            Console.WriteLine();
            Console.Write("Select an option: ");

            switch (Console.ReadLine())
            {
                case "1": AddProductMenu(); break;
                case "2": RemoveProductMenu(); break;
                case "3": UpdateProductMenu(); break;
                case "4": switchAccount = true; return;
                case "0": switchAccount = false; return;
                default:
                    Console.WriteLine("Invalid option.");
                    Console.ReadKey();
                    break;
            }
        }
    }

    public void ManageMenu(ref bool switchAccount)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("=== Warehouse Management System ===");
            Console.WriteLine("1. Add product");
            Console.WriteLine("2. Remove product");
            Console.WriteLine("3. Update product");
            Console.WriteLine("4. Show products");
            Console.WriteLine("5. Switch account");
            Console.WriteLine("0. Exit");
            Console.WriteLine();
            Console.Write("Select an option: ");

            switch (Console.ReadLine())
            {
                case "1": AddProductMenu(); break;
                case "2": RemoveProductMenu(); break;
                case "3": UpdateProductMenu(); break;
                case "4": ShowProductMenu(); break;
                case "5": switchAccount = true; return;
                case "0": switchAccount = false; return;
                default:
                    Console.WriteLine("Invalid option.");
                    Console.ReadKey();
                    break;
            }
        }
    }
}