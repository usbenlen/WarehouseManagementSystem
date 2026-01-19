using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseManagementSystem.Task1_DataModel.Products;

public class Electronics : Product
{
    public DateTime warrantyPeriod { get; private set; }
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

    public bool IsWarrantyPeriodValid()
    {
        return DateTime.Now.Date <  this.warrantyPeriod.Date;
    }

    public override void GetStorageRequirements()
    {
        Console.WriteLine($"Store in a dry place.");
    }
}
