using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseManagementSystem.Shared.Utils;

namespace WarehouseManagementSystem.Task1_DataModel.Products;

public abstract class Product
{
    public Guid id { get; private set; }
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

    public void ChangePrice()
    {
        Console.WriteLine($"Enter new price for {this.name}");
        if (!double.TryParse(Console.ReadLine(), out double newPrice))
        {
            Console.WriteLine("Invalid input");
            return;
        }
        if (newPrice < 0)
        {
            Console.WriteLine("Price cannot be negative");
            return;
        }
        basePrice = newPrice;
    }

    public void ChangeQuantity()
    {
        Console.WriteLine($"Enter new quantity for {this.name}");
        if (!int.TryParse(Console.ReadLine(), out int newQuantity))
        {
            Console.WriteLine("Invalid input");
            return;
        }
        if (newQuantity < 0)
        {
            Console.WriteLine("Quantity cannot be negative");
            return;
        }
        quantity = newQuantity;
    }
    public abstract void GetStorageRequirements();
    
}
