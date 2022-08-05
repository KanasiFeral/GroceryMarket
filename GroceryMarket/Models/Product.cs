namespace GroceryMarket.Models
{
    public class Product
    {
        public string ProductCode { get; set; }

        public double Price { get; set; }

        public double WholesalePrice { get; set; }

        public int WholesaleCount { get; set; }

        public bool IsWholesale { get; set; }
    }
}