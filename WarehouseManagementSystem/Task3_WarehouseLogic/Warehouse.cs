using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseManagementSystem.Menu;
using WarehouseManagementSystem.Task1_DataModel.Products;
using WarehouseManagementSystem.Task3_WarehouseLogic.Interfaces;
using WarehouseManagementSystem.Task3_WarehouseLogic.Events;

namespace WarehouseManagementSystem.Task3_WarehouseLogic;

public class Warehouse : IInventoryControl, IComparer<Product>
{
    private const int LowStockThreshold = 5;
    private readonly List<Product> _products;
    public IReadOnlyCollection<Product> Products => _products;

    public event EventHandler<LowStockEventArgs>? LowStockAlert;
    
    public Warehouse()
    {
        _products = new List<Product>();
    }
    public void AddProduct(Product product)
    {
        _products.Add(product);
        CheckStock(product);
        _products.Sort(Compare);
    }

    public void RemoveProduct(Guid id)
    {
        _products.RemoveAll(p => p.id == id);
    }
    public Product? FindProduct(Guid id)
    {
        return _products.FirstOrDefault(p => p.id == id);
    }

    public void ShowProducts()
    {
        foreach (var product in _products)
        {
            Console.WriteLine(product);
        }
    }

    private void CheckStock(Product product)
    {
        if (product.quantity < LowStockThreshold)
        {
            
        }
    }

    private void OnLowStockAlert(Product product)
    {
        LowStockAlert?.Invoke(this,new LowStockEventArgs(product, product.quantity));
    }

    public void UpdateProduct(Guid id)
    {
        var product = FindProduct(id);
        if (product == null)
        {
            Console.WriteLine($"Product {id} not found");
            return;
        }
        else
        {
            ChangeMenu.ShowMenu();
            if(!int.TryParse(Console.ReadLine(), out int choice));
            switch (choice)
            {
                case 1:
                {
                    Console.WriteLine($"Enter new price for {product.name}");
                    double price = double.Parse(Console.ReadLine());
                    product.ChangePrice(price);
                    break;
                }
                case 2:
                {
                    Console.WriteLine($"Enter new quantity for {product.name}");
                    int quantity = int.Parse(Console.ReadLine());
                    product.ChangeQuantity(quantity);
                    CheckStock(product);
                    break;
                }
                default:
                    Console.WriteLine("Invalid operation");
                    break;
            }
        }
    }

    public int Compare(Product? x, Product? y)
    {
        if (x == null || y == null)
        {
            return 0;
        }

        bool xPershable = x is PerishableProduct;
        bool yPershable = y is PerishableProduct;

        if (xPershable && !yPershable) return -1;
        if (!xPershable && yPershable) return 1;

        return 0;
    }
}
