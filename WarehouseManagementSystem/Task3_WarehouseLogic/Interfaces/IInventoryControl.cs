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
    void RemoveProduct(Guid id);
    Product? FindProduct(Guid id);
    void ShowProducts();
    void ChangeProductQuantity(Guid id, int quantity);
    void ChangeProductPrice(Guid id , double price);
}
