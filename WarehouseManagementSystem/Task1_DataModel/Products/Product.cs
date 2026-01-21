using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseManagementSystem.Shared.Utils;

namespace WarehouseManagementSystem.Task1_DataModel.Products;

public abstract class Product
{
    public Guid Id { get; protected set; }
    public string Name { get; set; }
    public double BasePrice { get; set; }
    public double Weight { get; set; }
    public int Quantity { get; set; }

    public Product(string name, double basePrice, double weight, int quantity)
    {
        Id = IdGenerator.Generate();
        Name = name;
        BasePrice = basePrice;
        Weight = weight;
        Quantity = quantity;
    }

    public Product(Guid id, string name, double basePrice, double weight, int quantity)
    {
        Id = id;
        Name = name;
        BasePrice = basePrice;
        Weight = weight;
        Quantity = quantity;
    }

    public void ChangePrice(double newPrice)
    {
        BasePrice = newPrice;
    }

    public void ChangeQuantity(int newQuantity)
    {
        
        Quantity = newQuantity;
    }
    public abstract void GetStorageRequirements();
    
}
