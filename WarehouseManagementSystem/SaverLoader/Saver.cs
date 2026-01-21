using Newtonsoft.Json;
using WarehouseManagementSystem.Task1_DataModel.Products;
using WarehouseManagementSystem.Task2_UserManagement;

namespace WarehouseManagementSystem.SaverLoader;

public class Saver
{
    public static void SaveProducts(IEnumerable<Product> products)
    {
        if (products.Count() == 0)
        {
            return;
        }
        var boxProducts = products.Select(ProductsMapper.ProductToBoxProsuct).ToList();
        string json = JsonConvert.SerializeObject(boxProducts);
        if (!Directory.Exists("savedInfo/"))
        {
            Directory.CreateDirectory("savedInfo");
        }
        File.WriteAllText("savedInfo/products.json", json);
    }

    public static void SaveUsers(IEnumerable<User> users)
    {
        var boxUsers = users.Select(UserMapper.UserToBoxUser).ToList();
        string json = JsonConvert.SerializeObject(boxUsers);
        if (!Directory.Exists("savedInfo/"))
        {
            Directory.CreateDirectory("savedInfo");
        }
        File.WriteAllText("savedInfo/users.json", json);
    }
}