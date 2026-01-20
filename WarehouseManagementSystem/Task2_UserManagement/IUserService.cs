using WarehouseManagementSystem.Shared.Enums;

namespace WarehouseManagementSystem.Task2_UserManagement;

public interface IUserService
{
    User Register(string username, UserRole role);
    void BlockUser(Guid userId);
    void UnblockUser(Guid userId);
    void UserChangeRole(Guid userId, UserRole role);
    User? GetUser(Guid userId);
}