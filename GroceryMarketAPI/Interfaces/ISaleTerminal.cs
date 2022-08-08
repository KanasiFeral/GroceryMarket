using GroceryMarketAPI.ModelsDTO;

namespace GroceryMarketAPI.Interfaces
{
    public interface ISaleTerminal
    {
        bool SetPrice(ProductDto product, ProductPriceDto productPrice, DiscountDto? discount);
        bool SetPrice(List<ProductDto> products, List<ProductPriceDto> productPrices, List<DiscountDto>? discounts);
        bool Scan(string productCode);
        double CalculateTotal();
    }
}