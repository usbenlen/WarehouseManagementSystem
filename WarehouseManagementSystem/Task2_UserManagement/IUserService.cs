using WarehouseManagementSystem.Shared.Enums;

namespace WarehouseManagementSystem.Task2_UserManagement;

public interface IUserService
{
    User Register(string username, string password, UserRole role);
    void DeleteUser(Guid userId);
    void BlockUser(Guid userId);
    void UnblockUser(Guid userId);
    void UserChangeRole(Guid userId, UserRole role);
    User? GetUser(Guid userId);
    User? GetUserLogin(string userName, string password);
    void UserSave();
    void Show(User currentUser);
}