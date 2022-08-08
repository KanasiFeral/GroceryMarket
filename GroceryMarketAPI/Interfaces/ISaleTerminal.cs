using GroceryMarketAPI.ModelsDTO;

namespace GroceryMarketAPI.Interfaces
{
    public interface ISaleTerminal
    {
        bool SetPrice(ProductDto product, DiscountDto? discount);
        bool SetPrice(List<ProductDto> products, List<DiscountDto>? discounts);
        bool Scan(string productCode);
        double CalculateTotal();
    }
}