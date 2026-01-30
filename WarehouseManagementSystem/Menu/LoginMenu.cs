using WarehouseManagementSystem.Task2_UserManagement;

namespace WarehouseManagementSystem.Menu;

public class LoginMenu
{
    private WarehouseService _service;
    
    public LoginMenu(WarehouseService service) { _service = service; }

    public User Login()
    {
        while (true)
        {
            Console.Clear();
            Console.Write("Username: ");
            var userName = Console.ReadLine();
            Console.Write("Password: ");
            var password = Console.ReadLine();
            var user = _service.GetUser(userName, password);

            if (user == null)
            {
                Console.WriteLine("Wrong username or password");
                Console.ReadKey();
            }
            else return user;
            
        }
    }
}