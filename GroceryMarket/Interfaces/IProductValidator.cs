namespace GroceryMarket.Interfaces
{
    public interface IProductValidator
    {
        void ValidateProductCode(string productode);
        void ValidatePrice(double price);
        void ValidateWholesalePrice(double wholesalePrice);
        void ValidateWholesaleCount(int wholesaleCount);
    }
}