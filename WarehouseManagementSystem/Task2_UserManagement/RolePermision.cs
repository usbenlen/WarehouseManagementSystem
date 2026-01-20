using WarehouseManagementSystem.Shared.Enums;

namespace WarehouseManagementSystem.Task2_UserManagement;

public static class RolePermision
{
    private static readonly Dictionary<UserRole, IReadOnlyCollection<LogActionType>> roles = new()
    {
        [UserRole.Storekeeper] = new[]
        {
            LogActionType.AddProduct,
            LogActionType.RemoveProduct,
            LogActionType.UpdateQuantity
        },
        [UserRole.Manager] = new[]
        {
            LogActionType.AddProduct,
            LogActionType.RemoveProduct,
            LogActionType.UpdateQuantity,
            LogActionType.PriceChange
        },
        [UserRole.Admin] = new[]
        {
            LogActionType.AddProduct,
            LogActionType.RemoveProduct,
            LogActionType.UpdateQuantity,
            LogActionType.PriceChange,
            LogActionType.UserBlocked,
            LogActionType.UserUnblocked,
            LogActionType.RemoveUser,
            LogActionType.AddUser
        }
    };
    public static IReadOnlyCollection<LogActionType> getRoles(UserRole role) => roles[role];
    
}