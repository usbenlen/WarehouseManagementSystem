using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseManagementSystem.Shared.Enums;
using WarehouseManagementSystem.Shared.Utils;

namespace WarehouseManagementSystem.Task2_UserManagement;

public class User
{
    public Guid Id { get; }
    public string UserName { get; }
    public UserRole Role { get; private set; }
    public bool IsBlocked { get; private set; }

    public User(string userName, UserRole role)
    {
        Id = IdGenerator.Generate();
        UserName = userName;
        Role = role;
        IsBlocked = false;
    }
    public void ChangeRole(UserRole role)
    {
        Role = role;
    }
    public void Block() => IsBlocked = true;
    public void Unblock() => IsBlocked = false;
}
