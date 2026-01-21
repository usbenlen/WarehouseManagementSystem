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
    public Guid Id { get; private set; }
    public string UserName { get; private set; }
    public string Password { get; private set; }
    public UserRole? Role { get; private set; }
    public bool IsBlocked { get; private set; }

    public User(string userName, string password, UserRole role)
    {
        Id = IdGenerator.Generate();
        UserName = userName;
        Password = password;
        Role = role;
        IsBlocked = false;
    }
    
    private User(Guid id, string userName, string password, UserRole? role, bool isBlocked)
    {
        Id = id;
        UserName = userName;
        Password = password;
        Role = role;
        IsBlocked = isBlocked;
    }

    public static User Restore(Guid id
        , string userName,
        string password,
        UserRole? role,
        bool isBlocked)
    {
        return new User(id, userName, password, role, isBlocked);
    }
    public void ChangeRole(UserRole role)
    {
        Role = role;
    }

    public void ChangeName(string name)
    {
        UserName = name;
    }
    public void ChangePassword(string password)
    {
        Password = password;
    }
    public void Block() => IsBlocked = true;
    public void Unblock() => IsBlocked = false;

    public override string ToString()
    {
        return $"Id: {Id},Name: {UserName}, Role: {Role.ToString()}, IsBlocked: {IsBlocked}";
    }
}
