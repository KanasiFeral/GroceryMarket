namespace GroceryMarket.Models
{
    public class Product
    {
        private string _productCode;

        public string ProductCode { get; set; }

        public double Price { get; set; }

        private double _wholesalePrice;
        public double WholesalePrice { get; set; }

        private int _wholesaleCount;
        public int WholesaleCount { get; set; }

        public bool IsWholesale { get; set; }
    }
}