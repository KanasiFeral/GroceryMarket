using GroceryMarketAPI.Classes;
using GroceryMarketAPI.Models;
using GroceryMarketAPI.ModelsDTO;

namespace GroceryMarketAPI.Mapper
{
    public sealed class DiscountMapper : MapperBase<Discount, DiscountDto>
    {
        private readonly ProductValidator _validator;

        public DiscountMapper()
        {
            _validator = new ProductValidator();
        }

        public override Discount Map(DiscountDto element)
        {
            return new Discount
            {
                ProductCode = _validator.ValidateProductCode(element.ProductCode) ? element.ProductCode : string.Empty,
                WholesaleCount = _validator.ValidateWholesaleCount(element.WholesaleCount) ? element.WholesaleCount : 0,
                WholesalePrice = _validator.ValidateWholesalePrice(element.WholesalePrice) ? element.WholesalePrice : 0.0
            };
        }

        public override DiscountDto Map(Discount element)
        {
            return new DiscountDto
            {
                ProductCode = _validator.ValidateProductCode(element.ProductCode) ? element.ProductCode : string.Empty,
                WholesaleCount = _validator.ValidateWholesaleCount(element.WholesaleCount) ? element.WholesaleCount : 0,
                WholesalePrice = _validator.ValidateWholesalePrice(element.WholesalePrice) ? element.WholesalePrice : 0.0
            };
        }
    }
}