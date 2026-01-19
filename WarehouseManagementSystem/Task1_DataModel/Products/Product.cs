using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseManagementSystem.Shared.Utils;

namespace WarehouseManagementSystem.Task1_DataModel.Products;

public abstract class Product
{
    public string id { get; private set; }
    public string name { get; private set; }
    public double basePrice { get; protected set; }
    public double weight { get; protected set; }
    public int quantity { get; protected set; }

    public Product(string name, double basePrice, double weight, int quantity)
    {
        id = IdGenerator.Generate();
        this.name = name;
        this.basePrice = basePrice;
        this.weight = weight;
        this.quantity = quantity;
    }
    public abstract void GetStorageRequirements();
    
    public override string ToString()
    {
        return $"Id: {id}, Name: {this.name}, Price: {this.basePrice}, Weight: {this.weight}, Quantity: {this.quantity}";
    }
}
