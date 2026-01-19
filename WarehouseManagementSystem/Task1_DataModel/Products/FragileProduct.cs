using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseManagementSystem.Task1_DataModel.Products;

public class FragileProduct : Product
{
    public double maxShakingHeight { get; private set; }

    public FragileProduct(double maxShakingHeight,
        string name,
        double basePrice,
        double weight,
        int quantity)
        : base(name, basePrice, weight, quantity)
    {
        this.maxShakingHeight = maxShakingHeight;
    }

    public override void GetStorageRequirements()
    {
        Console.WriteLine($"Max Shaking Height: {this.maxShakingHeight} m.");
    }
}
