using GroceryMarketAPI.Models;

namespace GroceryMarketAPI.Interfaces
{
    public interface IPriceCalculator
    {
        double CalculateTotal(List<Product> productsPrices, string order);
    }
}