using GroceryMarketAPI.Models;

namespace GroceryMarketAPI.Interfaces
{
    public interface ICalculator
    {
        double TotalCalculation(List<Product> productsPrices, string order);
    }
}