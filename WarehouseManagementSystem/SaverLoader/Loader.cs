using Newtonsoft.Json;
using WarehouseManagementSystem.Task1_DataModel.Products;
using WarehouseManagementSystem.Task2_UserManagement;

namespace WarehouseManagementSystem.SaverLoader;

public class Loader
{
    public static List<User>? LoadUsers()
    {
        if (!File.Exists("savedInfo/users.json"))
        {
            return new List<User>();
        }
        List<BoxUser>? data = JsonConvert.DeserializeObject<List<BoxUser>>(File.ReadAllText("savedInfo/users.json"));
        if (data == null)
        {
            return new List<User>();
        }
        return data.Select(UserMapper.BoxUserToUser).ToList();
    }

    public static List<Product>? LoadProducts()
    {
        if (!File.Exists("savedInfo/products.json"))
        {
            return new List<Product>();
        }

        List<BoxProduct>? data = JsonConvert.DeserializeObject<List<BoxProduct>>(File.ReadAllText("savedInfo/products.json"));
        if (data == null)
        {
            return new List<Product>();
        }
        return data.Select(ProductsMapper.BoxProductToProduct).ToList();
    }
}