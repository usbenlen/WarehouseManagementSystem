using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseManagementSystem.Task1_DataModel.Products;

public class Electronics : Product
{
    public DateTime warrantyPeriod { get; private set; } // Дата кінця гарантії
    public double voltage { get; private set; } 

    public Electronics(DateTime warrantyPeriod,
        double voltage,
        string name,
        double basePrice,
        double weight,
        int quantity) : base(name, basePrice, weight, quantity)
    {
        this.warrantyPeriod = warrantyPeriod;
        this.voltage = voltage;
    }

    public bool IsWarrantyPeriodValid() //  перевірка на дійсність гарантії
    {
        return DateTime.Now.Date <  this.warrantyPeriod.Date;
    }

    public override void GetStorageRequirements() // рекомендації для зберігання - "зберігати в сухому приміщенні"
    {
        Console.WriteLine($"Store in a dry place."); 
    }
    public override string ToString()
    {
        return $"Id: {id}, Name: {this.name}, Price: {this.basePrice}, Weight: {this.weight}, Quantity: {this.quantity} , Warranty Period: {this.warrantyPeriod} , Voltage: {this.voltage}";
    }
}
