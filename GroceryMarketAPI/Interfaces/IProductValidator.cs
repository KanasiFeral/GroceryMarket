namespace GroceryMarketAPI.Interfaces
{
    public interface IProductValidator
    {
        bool ValidateProductCode(string productode);
        bool ValidatePrice(double price);
        bool ValidateWholesalePrice(double wholesalePrice);
        bool ValidateWholesaleCount(int wholesaleCount);
    }
}