using WarehouseManagementSystem.Task1_DataModel.Products;
using WarehouseManagementSystem.Task3_WarehouseLogic;

namespace WarehouseManagementSystem.Task2_UserManagement;

public class WarehouseService
{
    private readonly Warehouse _warehouse;
    
    WarehouseService(Warehouse warehouse)
    {
        _warehouse = warehouse;
    }

    private bool IsBlocked(User user)
    {
        if (user.IsBlocked)
        {
            Console.WriteLine("This user is blocked");
            return true;
        }
        return false;
    }

    public void AddProduct(User user, Product product)
    {
        if(IsBlocked(user)){return;}
        if (!AcessControl.CanAddProduct(user))
        {
            Console.WriteLine("This user is not allowed to add product");
            return;
        }
        _warehouse.AddProduct(product);
    }

    public void RemoveProduct(User user, Product product)
    {
        if(IsBlocked(user)){return;}
        if (!AcessControl.CanAddProduct(user))
        {
            Console.WriteLine("This user is not allowed to remove product");
        }
        _warehouse.RemoveProduct(product.id);
    }

    public void BlockUser(User user, User user2)
    {
        if(IsBlocked(user)){return;}
        if(user == user2) {return;}

        if (!AcessControl.CanManageUsers(user))
        {
            Console.WriteLine("This user is not allowed to manage users");
        }
        user2.Block();
    }

    public void UnblockUser(User user, User user2)
    {
        if(IsBlocked(user)){return;}
        if(user == user2) {return;}

        if (!AcessControl.CanManageUsers(user))
        {
            Console.WriteLine("This user is not allowed to unblock user");
        }
    }
}