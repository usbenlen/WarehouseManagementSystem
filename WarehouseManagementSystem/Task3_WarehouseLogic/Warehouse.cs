using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseManagementSystem.Menu;
using WarehouseManagementSystem.SaverLoader;
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
        var data = Loader.LoadProducts();
        if (data == null)
        {
            _products = new();
        }
        else
        {
            _products = data.ToList();
        }
    }
    public void AddProduct(Product product)
    {
        _products.Add(product);
        CheckStock(product);
        _products.Sort(Compare);
    }

    public void RemoveProduct(Guid id)
    {
        _products.RemoveAll(p => p.Id == id);
    }
    public Product? FindProduct(Guid id)
    {
        return _products.FirstOrDefault(p => p.Id == id);
    }

    public void ShowProducts()
    {
        foreach (var product in _products)
        {
            Console.WriteLine(product);
        }
    }

    public void ChangeProductPrice(Guid id , double price)
    {
        var product = FindProduct(id);
        if (product == null)
        {
            return;
        }

        product.ChangePrice(price);
    }

    public void ChangeProductQuantity(Guid id, int quantity)
    {
        var product = FindProduct(id);
        if (product == null)
        {
            return;
        }
        product.ChangeQuantity(quantity);
        CheckStock(product);
    }

    private void CheckStock(Product product)
    {
        if (product.Quantity < LowStockThreshold)
        {
            OnLowStockAlert(product);
        }
    }

    private void OnLowStockAlert(Product product)
    {
        LowStockAlert?.Invoke(this,new LowStockEventArgs(product, product.Quantity));
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

    public void SaveProducts()
    {
        
    }
}
