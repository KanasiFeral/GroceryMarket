using GroceryMarketAPI.ModelsDTO;

namespace GroceryMarketAPI.Interfaces
{
    public interface ISaleTerminal
    {
        bool SetPricing(ProductDto product, DiscountDto? discount);
        bool SetPricing(List<ProductDto> products, List<DiscountDto>? discounts);
        bool Scan(string productCode);
        double CalculateTotal();
    }
}