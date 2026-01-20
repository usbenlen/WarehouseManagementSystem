using WarehouseManagementSystem.Shared.Enums;

namespace WarehouseManagementSystem.Task2_UserManagement;

public class UserService : IUserService
{
    private readonly List<User> _users = new();

    public User Register(string name, UserRole role )
    {
        var user = new User(name, role);
        _users.Add(user);
        return user;
    }
    public User? GetUser(Guid userId)
    {
        return _users.FirstOrDefault(u => u.Id == userId);
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
}