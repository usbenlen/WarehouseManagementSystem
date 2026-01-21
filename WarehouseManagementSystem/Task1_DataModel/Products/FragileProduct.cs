using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseManagementSystem.Task2_UserManagement;

namespace WarehouseManagementSystem.Task1_DataModel.Products;

public class FragileProduct : Product
{
    public double MaxShakingHeight { get;  set; } // максимальний рівень вібрацій який може витримати продукт

    public FragileProduct(double maxShakingHeight,
        string name,
        double basePrice,
        double weight,
        int quantity)
        : base(name, basePrice, weight, quantity)
    {
        MaxShakingHeight = maxShakingHeight;
    }

    public FragileProduct(BoxProduct boxProduct) : base(boxProduct.Name, 
        boxProduct.Price,
        boxProduct.Weight,
        boxProduct.Quantity)
    {
        Id = boxProduct.Id;
        MaxShakingHeight = (double)boxProduct.MaxShakingWeight;
    }

    public override void GetStorageRequirements() // рекомендації щодо зберігання
    {
        Console.WriteLine($"Max Shaking Height: {MaxShakingHeight} m."); 
    }
    public override string ToString()
    {
        return $"Id: {Id}," +
               $" Name: {Name}," +
               $" Price: {BasePrice}," +
               $" Weight: {Weight}," +
               $" Quantity: {Quantity}," +
               $" Max shacking height: {MaxShakingHeight}";
    }
}
