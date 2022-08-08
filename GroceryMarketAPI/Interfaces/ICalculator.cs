using GroceryMarketAPI.Models;

namespace GroceryMarketAPI.Interfaces
{
    public interface ICalculator
    {
        double CalculationWithWholesale(List<Product> productsPrices, string order);
        double CalculationWithoutWholesale(List<Product> productsPrices, string order);
        double TotalCalculation(List<Product> productsPrices, string order);
    }
}