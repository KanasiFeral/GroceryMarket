using System.Collections.Generic;
using ProductDTO = GroceryMarket.ModelsDTO.Product;

namespace GroceryMarket.Interfaces
{
    public interface ISaleTerminal
    {
        bool SetPricing(ProductDTO product);
        bool SetPricing(List<ProductDTO> products);
        bool Scan(string productCode);
        double CalculateTotal();
    }
}