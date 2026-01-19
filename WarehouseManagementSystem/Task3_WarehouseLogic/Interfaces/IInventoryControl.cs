using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using WarehouseManagementSystem.Task1_DataModel.Products;

namespace WarehouseManagementSystem.Task3_WarehouseLogic.Interfaces;

public interface IInventoryControl
{
    void AddProduct(Product product);
    void RemoveProduct(string id);
    Product? FindProduct(string id);
    void ShowProducts();
    void UpdateProduct(string id);
}
