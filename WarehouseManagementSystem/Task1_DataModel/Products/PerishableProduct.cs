using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseManagementSystem.Task1_DataModel.Products;

public class PerishableProduct : Product
{
    public DateTime expiryDate{ get; private set; }

    public PerishableProduct(DateTime expiryDate,
        string name,
        double price,
        double weight,
        int quantity) : base(name, price, weight, quantity)
    {
        this.expiryDate = expiryDate;
    }

    public bool IsExpired()
    {
        return DateTime.Now.Date > expiryDate;
    }

    public override void GetStorageRequirements()
    {
        Console.WriteLine("Store in cold place");
    }

    public override string ToString()
    {
        return $"Name: {this.name}, Price: {this.basePrice}, Weight: {this.weight}, Quantity: {this.quantity}";
    }
}
