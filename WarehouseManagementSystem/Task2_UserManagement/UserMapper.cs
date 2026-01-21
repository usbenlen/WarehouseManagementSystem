using WarehouseManagementSystem.Task2_UserManagement;

namespace WarehouseManagementSystem.Task2_UserManagement;

public static class UserMapper
{
    public static BoxUser UserToBoxUser(this User user)
    {
        return new BoxUser(user.Id, user.UserName, user.Password, user.Role, user.IsBlocked);
    }

    public static User BoxUserToUser(this BoxUser boxUser)
    {
        return User.Restore(boxUser.id,boxUser.userName, boxUser.password, boxUser.role, boxUser.isBlocked);
    }
}