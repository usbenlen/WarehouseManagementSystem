using WarehouseManagementSystem.Shared.Enums;

namespace WarehouseManagementSystem.Task2_UserManagement;

public static class AccessControl
{
    public static bool CanAddProduct(User user) 
        => user.Role == UserRole.Storekeeper || user.Role == UserRole.Admin;
    public static bool CanChangePrice(User user)
        => user.Role == UserRole.Manager ||  user.Role == UserRole.Admin;

    public static bool CanManageUsers(User user)
        => user.Role == UserRole.Admin;
}