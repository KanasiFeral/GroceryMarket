namespace GroceryMarketAPI.Models
{
    public class Product
    {
        public string ProductCode { get; set; }
        public ProductPrice ProductPrice { get; set; }
        public Discount Discount { get; set; }
    }
}