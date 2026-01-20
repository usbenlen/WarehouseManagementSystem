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
        var userService = new UserService();
        
        var service = new WarehouseService(
            warehouse,
            productValidator,
            userValidator ,
            logger
            ,userService);
        var loginMenu = new LoginMenu(service);
        var currentUser = loginMenu.Login();
        var menu = new MainMenu(service, currentUser);
        menu.Show();
        
        logger.FlushToFile();
    }
}
