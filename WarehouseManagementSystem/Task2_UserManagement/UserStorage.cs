using Newtonsoft.Json;
using WarehouseManagementSystem.SaverLoader;

namespace WarehouseManagementSystem.Task2_UserManagement;

public class UserStorage
{
    private readonly string _path = "savedInfo";

    public void Save(IEnumerable<User> users)
    {
        Saver.SaveUsers(users);
    }

    public List<User>? GetUsers()
    {
        return Loader.LoadUsers();
    }
}