namespace GroceryMarketAPI.ModelsDTO
{
    public class StockDto
    {
        public ProductDto ProductDto { get; set; }
        public double WholesalePrice { get; set; }
        public int WholesaleCount { get; set; }
    }
}