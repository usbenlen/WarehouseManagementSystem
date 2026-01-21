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
                    productToBox.id,
                    productToBox.name,
                    productToBox.basePrice,
                    productToBox.weight,
                    productToBox.quantity,
                    productToBox.expiryDate,
                    null,
                    null,
                    null);
            }
            case "FragileProduct":
            {
                var productToBox =  (FragileProduct)product;
                return new BoxProduct(type,
                    productToBox.id,
                    productToBox.name,
                    productToBox.basePrice,
                    productToBox.weight,
                    productToBox.quantity,
                    null,
                    null,
                    null,
                    productToBox.maxShakingHeight);
            }
            case "Electronics":
            {
                var productToBox = (Electronics)product;
                return new BoxProduct(type,
                    productToBox.id,
                    productToBox.name,
                    productToBox.basePrice,
                    productToBox.weight,
                    productToBox.quantity,
                    null,
                    productToBox.warrantyPeriod,
                    productToBox.voltage,
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