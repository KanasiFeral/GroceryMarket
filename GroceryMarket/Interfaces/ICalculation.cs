using GroceryMarket.Models;
using System.Collections.Generic;

namespace GroceryMarket.Interfaces
{
    public interface ICalculation
    {
        double CalculationWithWholesale(List<Product> productsPrices, string order);
        double CalculationWithoutWholesale(List<Product> productsPrices, string order);
        double TotalCalculation(List<Product> productsPrices, string order);
    }
}