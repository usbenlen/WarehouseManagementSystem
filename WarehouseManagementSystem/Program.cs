//Щоб мати доступ до коду з папки в головній програмі
using WarehouseManagementSystem.Task1_DataModel.Products;
using WarehouseManagementSystem.Task3_WarehouseLogic;

namespace WarehouseManagementSystem;

internal class Program
{
    static void Main(string[] args)
    {
        //Код тестувати тут
        Warehouse warehouse = new Warehouse();
        warehouse.AddProduct(new PerishableProduct(DateTime.Now.Date,"Banana", 5,4,100));
        warehouse.AddProduct(new PerishableProduct(DateTime.Now.AddDays(14),"Pepperoni", 5,4,100));
        
        warehouse.ShowProducts();
    }
}
