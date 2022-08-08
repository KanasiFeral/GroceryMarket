using GroceryMarketAPI.Models;

namespace GroceryMarketAPI.Interfaces
{
    public interface IPriceCalculator
    {
        double TotalCalculation(List<Product> productsPrices, string order);
    }
}