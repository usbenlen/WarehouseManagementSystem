using System;

using WarehouseManagementSystem.Task1_DataModel.Products;

namespace WarehouseManagementSystem.Task3_WarehouseLogic.Events;

public class LowStockEventArgs : EventArgs
{
    public Product Product { get; }
    public int CurrentQuantity { get; }

    public LowStockEventArgs(Product product, int quantity)
    {
        Product = product;
        CurrentQuantity = quantity;
    }
}
