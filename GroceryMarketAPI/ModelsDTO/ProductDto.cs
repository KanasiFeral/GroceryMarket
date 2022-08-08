﻿namespace GroceryMarketAPI.ModelsDTO
{
    public class ProductDto
    {
        public string ProductCode { get; set; }
        public double Price { get; set; }
        public double WholesalePrice { get; set; }
        public int WholesaleCount { get; set; }
        public bool IsWholesale { get; set; }
    }
}