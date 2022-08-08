namespace GroceryMarketAPI.Models
{
    public class Stock
    {
        public Product Product { get; set; }
        public double WholesalePrice { get; set; }
        public int WholesaleCount { get; set; }
    }
}