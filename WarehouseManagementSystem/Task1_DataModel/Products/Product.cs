using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseManagementSystem.Shared.Utils;

namespace WarehouseManagementSystem.Task1_DataModel.Products;

public abstract class Product
{
    public Guid id { get; protected set; }
    public string name { get; set; }
    public double basePrice { get; set; }
    public double weight { get; set; }
    public int quantity { get; set; }

    public Product(string name, double basePrice, double weight, int quantity)
    {
        id = IdGenerator.Generate();
        this.name = name;
        this.basePrice = basePrice;
        this.weight = weight;
        this.quantity = quantity;
    }

    public Product(Guid id, string name, double basePrice, double weight, int quantity)
    {
        this.id = id;
        this.name = name;
        this.basePrice = basePrice;
        this.weight = weight;
        this.quantity = quantity;
    }

    public void ChangePrice(double newPrice)
    {
        basePrice = newPrice;
    }

    public void ChangeQuantity(int newQuantity)
    {
        
        quantity = newQuantity;
    }
    public abstract void GetStorageRequirements();
    
}
