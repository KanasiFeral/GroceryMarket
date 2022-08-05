using System.Collections.Generic;
using GroceryMarket.ModelsDTO;

namespace GroceryMarket.Interfaces
{
    public interface ISaleTerminal
    {
        bool SetPricing(ProductDto product);
        bool SetPricing(List<ProductDto> products);
        bool Scan(string productCode);
        double CalculateTotal();
    }
}