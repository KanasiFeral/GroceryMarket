using System.Collections.Generic;
using GroceryMarketAPI.ModelsDTO;

namespace GroceryMarketAPI.Interfaces
{
    public interface ISaleTerminal
    {
        bool SetPricing(ProductDto product);
        bool SetPricing(List<ProductDto> products);
        bool Scan(string productCode);
        double CalculateTotal();
    }
}