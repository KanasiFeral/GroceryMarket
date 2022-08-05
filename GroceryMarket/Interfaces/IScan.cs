using System.Collections.Generic;
using GroceryMarket.Models;

namespace GroceryMarket.Interfaces
{
    public interface IScan
    {
        string Scan(List<Product> productsPrices, string order);
    }
}