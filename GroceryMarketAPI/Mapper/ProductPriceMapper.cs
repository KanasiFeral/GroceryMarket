using GroceryMarketAPI.Classes;
using GroceryMarketAPI.Models;
using GroceryMarketAPI.ModelsDTO;

namespace GroceryMarketAPI.Mapper
{
    public sealed class ProductPriceMapper : MapperBase<ProductPrice, ProductPriceDto>
    {
        private readonly ProductValidator _validator;

        public ProductPriceMapper()
        {
            _validator = new ProductValidator();
        }

        public override ProductPrice Map(ProductPriceDto element)
        {
            return new ProductPrice()
            {
                ProductCode = _validator.ValidateProductCode(element.ProductCode) ? element.ProductCode : string.Empty,
                Price = _validator.ValidatePrice(element.Price) ? element.Price : 0.0
            };
        }

        public override ProductPriceDto Map(ProductPrice element)
        {
            return new ProductPriceDto()
            {
                ProductCode = _validator.ValidateProductCode(element.ProductCode) ? element.ProductCode : string.Empty,
                Price = _validator.ValidatePrice(element.Price) ? element.Price : 0.0
            };
        }
    }
}