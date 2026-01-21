using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseManagementSystem.Task2_UserManagement;

namespace WarehouseManagementSystem.Task1_DataModel.Products;

public class PerishableProduct : Product 
{
    public DateTime ExpiryDate{ get; set; } // термін придатності

    public PerishableProduct(DateTime expiryDate,
        string name,
        double price,
        double weight,
        int quantity) : base(name, price, weight, quantity)
    {
        ExpiryDate = expiryDate;
    }

    public PerishableProduct(BoxProduct boxProduct) : base(boxProduct.Name,
        boxProduct.Price,
        boxProduct.Weight,
        boxProduct.Quantity)
    {
        Id = boxProduct.Id;
        ExpiryDate = (DateTime)boxProduct.ExpiryDate;
    }

    public bool IsExpired() // перевірка терміна придатності
    {
        return DateTime.Now.Date > ExpiryDate;
    }

    public override void GetStorageRequirements() // рекомендації щодо зберігання - "зберігати в холодному приміщенні"
    {
        Console.WriteLine("Store in cold place");
    }
    public override string ToString()
    {
        return $"Id: {Id}," +
               $" Name: {Name}," +
               $" Price: {BasePrice}," +
               $" Weight: {Weight}," +
               $" Quantity: {Quantity}," +
               $" Expiry date: {ExpiryDate},"+
               $" IsExpired: {IsExpired()}";
    }
}
