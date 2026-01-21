using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseManagementSystem.Task2_UserManagement;

namespace WarehouseManagementSystem.Task1_DataModel.Products;

public class Electronics : Product
{
    public DateTime WarrantyPeriod { get; set; } // Дата кінця гарантії
    public double Voltage { get; set; } 

    public Electronics(DateTime warrantyPeriod,
        double voltage,
        string name,
        double basePrice,
        double weight,
        int quantity) : base(name, basePrice, weight, quantity)
    {
        WarrantyPeriod = warrantyPeriod;
        Voltage = voltage;
    }

    public Electronics(BoxProduct boxProduct) : base(boxProduct.Name,
        boxProduct.Price,
        boxProduct.Weight,
        boxProduct.Quantity)
    {
        WarrantyPeriod = (DateTime)boxProduct.WarrantyDate;
        Voltage = (double)boxProduct.Voltage;
    }
    

    public bool IsWarrantyPeriodValid() //  перевірка на дійсність гарантії
    {
        return DateTime.Now.Date <  WarrantyPeriod.Date;
    }

    public override void GetStorageRequirements() // рекомендації для зберігання - "зберігати в сухому приміщенні"
    {
        Console.WriteLine($"Store in a dry place."); 
    }
    public override string ToString()
    {
        return $"Id: {Id}," +
               $" Name: {Name}," +
               $" Price: {BasePrice}," +
               $" Weight: {Weight}," +
               $" Quantity: {Quantity}," +
               $" Warranty Period: {WarrantyPeriod}," +
               $" Voltage: {Voltage},"+
               $" Is warranty period valid: {IsWarrantyPeriodValid()}";
    }
}
