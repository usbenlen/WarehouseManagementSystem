using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using WarehouseManagementSystem.Task1_DataModel.Products;
using WarehouseManagementSystem.Task3_WarehouseLogic.Interfaces;

namespace WarehouseManagementSystem.Task3_WarehouseLogic;

public class Warehouse : IInventoryControl
{
    public List<Product> products { get; private set; }

    public Warehouse()
    {
        products = new List<Product>();
    }
    public void AddProduct(Product product)
    {
        products.Add(product);
    }

    public void RemoveProduct(string id)
    {
        products.RemoveAll(p => p.id == id);
    }
    public Product? FindProduct(string id)
    {
        return products.FirstOrDefault(p => p.id == id);
    }

    public void ShowProducts()
    {
        foreach (var product in products)
        {
            Console.WriteLine(product);
        }
    }

    public void UpdateProduct(string id)
    {
        var product = FindProduct(id);
        if (product == null)
        {
            Console.WriteLine($"Product {id} not found");
            return;
        }
        else
        {
            
        }
    }
}
