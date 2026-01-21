namespace WarehouseManagementSystem.Task2_UserManagement;

public class BoxProduct
{
    public string Type { get; }
    public Guid Id { get; }
    public string Name { get; }
    public double Price { get; }
    public double Weight { get; }
    public int Quantity { get; }
    
    public DateTime? ExpiryDate { get; }
    public DateTime? WarrantyDate { get; }
    public double? Voltage { get; }
    public double? MaxShakingWeight { get; }
    
    public BoxProduct(string type,
        Guid id,
        string name,
        double price,
        double weight,
        int quantity,
        DateTime? expiryDate,
        DateTime? warrantyDate,
        double? voltage,
        double? maxShakingWeight){
        Type = type;
        Id = id;
        Name = name;
        Price = price;
        Weight = weight;
        Quantity = quantity;
        ExpiryDate = expiryDate;
        WarrantyDate = warrantyDate;
        Voltage = voltage;
        MaxShakingWeight = maxShakingWeight;
    }
    
}