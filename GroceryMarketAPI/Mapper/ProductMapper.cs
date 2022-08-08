using GroceryMarketAPI.Classes;
using GroceryMarketAPI.Models;
using GroceryMarketAPI.ModelsDTO;

namespace GroceryMarketAPI.Mapper
{
    public sealed class ProductMapper : MapperBase<Product, ProductDto>
    {
        private readonly ProductValidator _validator;        

        public ProductMapper()
        {
            // Init validator
            _validator = new ProductValidator();
        }

        public override Product Map(ProductDto element)
        {
            return new Product
            {
                ProductCode = _validator.ValidateProductCode(element.ProductCode) ? element.ProductCode : string.Empty,
                Price = _validator.ValidatePrice(element.Price) ? element.Price : 0.0,
                IsWholesale = element.IsWholesale,
                WholesaleCount = _validator.ValidateWholesaleCount(element.WholesaleCount) ? element.WholesaleCount: 0,
                WholesalePrice = _validator.ValidateWholesalePrice(element.WholesalePrice) ? element.WholesalePrice : 0.0
            };
        }

        public override ProductDto Map(Product element)
        {
            return new ProductDto
            {
                ProductCode = _validator.ValidateProductCode(element.ProductCode) ? element.ProductCode : string.Empty,
                Price = _validator.ValidatePrice(element.Price) ? element.Price : 0.0,
                IsWholesale = element.IsWholesale,
                WholesaleCount = _validator.ValidateWholesaleCount(element.WholesaleCount) ? element.WholesaleCount : 0,
                WholesalePrice = _validator.ValidateWholesalePrice(element.WholesalePrice) ? element.WholesalePrice : 0.0
            };
        }
    }
}