using WarehouseManagementSystem.Task1_DataModel.Products;

namespace WarehouseManagementSystem.Task3_WarehouseLogic.Events;

public class Notification
{
    public void Subscribe(Warehouse warehouse)
    {
        warehouse.LowStockAlert += LowStockAlert;
    }

    public void LowStockAlert(object sender, LowStockEventArgs e)
    {
        Console.WriteLine($"{e.Product.Name} remain {e.CurrentQuantity}");
    }
    
}