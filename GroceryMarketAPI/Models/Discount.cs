namespace GroceryMarketAPI.Models
{
    public class Discount
    {
        public string ProductCode { get; set; }
        public double WholesalePrice { get; set; }
        public int WholesaleCount { get; set; }
    }
}