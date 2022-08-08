using System.Collections.Generic;
using GroceryMarketAPI.Models;

namespace GroceryMarketAPI.Interfaces
{
    public interface IScan
    {
        string Scan(List<Product> productsPrices, string order);
    }
}