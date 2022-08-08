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
            _validator = new ProductValidator();
        }

        public override Product Map(ProductDto element)
        {
            return new Product
            {
                ProductCode = _validator.ValidateProductCode(element.ProductCode) ? element.ProductCode : string.Empty
            };
        }

        public override ProductDto Map(Product element)
        {
            return new ProductDto
            {
                ProductCode = _validator.ValidateProductCode(element.ProductCode) ? element.ProductCode : string.Empty
            };
        }
    }
}