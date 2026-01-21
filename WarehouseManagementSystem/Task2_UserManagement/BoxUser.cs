using WarehouseManagementSystem.Shared.Enums;

namespace WarehouseManagementSystem.Task2_UserManagement;

public class BoxUser
{
    public Guid id { get; set; }
    public string userName { get; set; }
    public string password { get; set; }
    public UserRole? role { get; set; }
    public bool isBlocked { get; set; }

    public BoxUser(Guid id, string userName, string password, UserRole? role, bool isBlocked)
    {
        this.id = id;
        this.userName = userName;
        this.password = password;
        this.role = role;
        this.isBlocked = isBlocked;
    }
}