//Щоб мати доступ до коду з папки в головній програмі
using System.Globalization;
using WarehouseManagementSystem.Menu;
using WarehouseManagementSystem.Shared.Enums;
using WarehouseManagementSystem.Task1_DataModel.Products;
using WarehouseManagementSystem.Task2_UserManagement;
using WarehouseManagementSystem.Task3_WarehouseLogic;
using WarehouseManagementSystem.Task4_BusinessAndSecurity.Logging;
using WarehouseManagementSystem.Task4_BusinessAndSecurity.Validation;

namespace WarehouseManagementSystem;

internal class Program
{
    static void Main(string[] args)
    {
        //Код тестувати тут
        var warehouse =  new Warehouse();
        var logger = new Logger();
        var productValidator = new ProductValidator();
        var userValidator = new UserValidator();
        var userStorage = new UserStorage();
        var userService = new UserService(userStorage);
        
        var service = new WarehouseService(
            warehouse,
            productValidator,
            userValidator ,
            logger
            ,userService);

        while (true)
        {
            var loginMenu = new LoginMenu(service);
            var currentUser = loginMenu.Login();

            if (currentUser == null)
            {
                Console.WriteLine("Login failed. Press any key to try again.");
                Console.ReadKey();
                continue;
            }

            var menu = new MainMenu(service, currentUser);
            bool switchAccount = menu.Show();

            if (!switchAccount) break;
        }

        logger.FlushToFile();
    }
}
