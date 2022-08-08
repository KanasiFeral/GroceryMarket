using GroceryMarketAPI.Models;

namespace GroceryMarketAPI.Interfaces
{
    public interface IOrderScan
    {
        string Scan(List<Product> productsPrices, string order);
    }
}