namespace GroceryMarket.ModelsDTO
{
    public class ProductDto
    {
        public string ProductCode { get; set; }
        public double Price { get; set; }
        public double WholesalePrice { get; set; }
        public double WholesaleCount { get; set; }
        public bool IsWholesale { get; set; }
    }
}