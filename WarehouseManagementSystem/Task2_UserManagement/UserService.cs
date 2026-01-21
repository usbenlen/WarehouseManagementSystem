using Newtonsoft.Json;
using WarehouseManagementSystem.Shared.Enums;

namespace WarehouseManagementSystem.Task2_UserManagement;

public class UserService : IUserService
{
    private readonly List<User> _users;
    private readonly UserStorage _userStorage;
    
    public UserService(UserStorage userStorage)
    {
        _userStorage = userStorage;
        _users = _userStorage.GetUsers();
        if (_users.Count == 0)
        {
            _users.Add(new User("admin","admin", UserRole.Admin));
        }
    }

    public void Show(User currentUser)
    {
        foreach (var user in _users)
        {
            if (user.Id == currentUser.Id)
            {
                Console.Write(user);
                Console.WriteLine(" <=== You");
            }
            else
            {
                Console.WriteLine(user);
            }
        }
    }
    public User Register(string name, string password, UserRole role )
    {
        var user = new User(name, password, role);
        _users.Add(user);
        return user;
    }

    public void DeleteUser(Guid userId)
    {
        User? user = GetUser(userId);
        if (user == null)
        {
            Console.WriteLine("Unknown id");
            Console.ReadKey();
            return;
        }
        _users.Remove(user);
    }
    public User? GetUser(Guid userId)
    {
        return _users.FirstOrDefault(u => u.Id == userId);
    }

    public User? GetUserLogin(string name, string password)
    {
        return _users.FirstOrDefault(u => u.UserName == name && u.Password == password);
            
    }

    public void BlockUser(Guid userId)
    {
        var user = GetUser(userId);
        user?.Block();
    }
    public void UnblockUser(Guid userId)
    {
        var user = GetUser(userId);
        user?.Unblock();
    }
    public void UserChangeRole(Guid userId, UserRole role)
    {
        var user = GetUser(userId);
        user?.ChangeRole(role);
    }

    public void UserSave()
    {
        _userStorage.Save(_users);
    }
}