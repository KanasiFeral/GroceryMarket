using System;
using GroceryMarket.Models;
using GroceryMarket.ModelsDTO;

namespace GroceryMarket.Mapper
{
    public sealed class ProductMapper : MapperBase<Product, ProductDto>
    {
        public override Product Map(ProductDto element)
        {
            return new Product
            {
                ProductCode = element.ProductCode,
                Price = element.Price,
                IsWholesale = element.IsWholesale,
                WholesaleCount = element.WholesaleCount,
                WholesalePrice = element.WholesalePrice
            };
        }

        public override ProductDto Map(Product element)
        {
            return new ProductDto
            {
                ProductCode = element.ProductCode,
                Price = element.Price,
                IsWholesale = element.IsWholesale,
                WholesaleCount = element.WholesaleCount,
                WholesalePrice = element.WholesalePrice
            };
        }
    }
}