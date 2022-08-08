namespace GroceryMarketAPI.Models
{
    public class Product
    {
        public string ProductCode { get; set; }
        public double Price { get; set; }
        public Discount Discount { get; set; }
    }
}