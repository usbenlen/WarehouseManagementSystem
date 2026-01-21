using WarehouseManagementSystem.Task1_DataModel.Products;

namespace WarehouseManagementSystem.Task2_UserManagement;

public class ProductsMapper
{
    public static BoxProduct ProductToBoxProsuct(Product product)
    {
        string type = product.GetType().Name;
        switch (type)
        {
            case "PerishableProduct":
            {
                var productToBox = (PerishableProduct)product;
                return new BoxProduct(type,
                    productToBox.Id,
                    productToBox.Name,
                    productToBox.BasePrice,
                    productToBox.Weight,
                    productToBox.Quantity,
                    productToBox.ExpiryDate,
                    null,
                    null,
                    null);
            }
            case "FragileProduct":
            {
                var productToBox =  (FragileProduct)product;
                return new BoxProduct(type,
                    productToBox.Id,
                    productToBox.Name,
                    productToBox.BasePrice,
                    productToBox.Weight,
                    productToBox.Quantity,
                    null,
                    null,
                    null,
                    productToBox.MaxShakingHeight);
            }
            case "Electronics":
            {
                var productToBox = (Electronics)product;
                return new BoxProduct(type,
                    productToBox.Id,
                    productToBox.Name,
                    productToBox.BasePrice,
                    productToBox.Weight,
                    productToBox.Quantity,
                    null,
                    productToBox.WarrantyPeriod,
                    productToBox.Voltage,
                    null);
            }
        }
        return null;
    }

    public static Product BoxProductToProduct(BoxProduct boxProduct)
    {
        switch (boxProduct.Type)
        {
            case "FragileProduct":
            {
                return new FragileProduct(boxProduct);
            }
            case "Electronics":
            {
                return new Electronics(boxProduct);
            }
            case "PerishableProduct":
            {
                return new PerishableProduct(boxProduct);
            }
        }
        return null;
    }
}