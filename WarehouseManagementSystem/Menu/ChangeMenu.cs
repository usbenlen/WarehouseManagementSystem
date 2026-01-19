using WarehouseManagementSystem.Task1_DataModel.Products;

namespace WarehouseManagementSystem.Menu;

public class ChangeMenu
{
    public static void ShowMenu()
    {
        Console.WriteLine("+=====Change Menu=====+");
        foreach (var item in Enum.GetValues(typeof(ItemChangeMenu)))
        {
            Console.WriteLine($"{(int)item}. {item}");
        }
    }
}