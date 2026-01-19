using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseManagementSystem.Task1_DataModel.Products;

public class FragileProduct : Product
{
    public double maxShakingHeight { get; private set; } // максимальний рівень вібрацій який може витримати продукт

    public FragileProduct(double maxShakingHeight,
        string name,
        double basePrice,
        double weight,
        int quantity)
        : base(name, basePrice, weight, quantity)
    {
        this.maxShakingHeight = maxShakingHeight;
    }

    public override void GetStorageRequirements() // рекомендації щодо зберігання
    {
        Console.WriteLine($"Max Shaking Height: {this.maxShakingHeight} m."); 
    }
    public override string ToString()
    {
        return $"Id: {id}, Name: {this.name}, Price: {this.basePrice}, Weight: {this.weight}, Quantity: {this.quantity} , Max shacking height: {maxShakingHeight}";
    }
}
