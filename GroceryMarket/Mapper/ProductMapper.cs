using System;
using GroceryMarket.Classes;
using GroceryMarket.Models;
using GroceryMarket.ModelsDTO;

namespace GroceryMarket.Mapper
{
    public sealed class ProductMapper : MapperBase<Product, ProductDto>
    {
        // Validator for data
        private readonly ProductValidator _validator;

        public ProductMapper()
        {
            // Init validator
            _validator = new ProductValidator();
        }

        public override Product Map(ProductDto element)
        {
            // Validate data
            ValidateData(element);

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
            // Validate data
            ValidateData(element);

            return new ProductDto
            {
                ProductCode = element.ProductCode,
                Price = element.Price,
                IsWholesale = element.IsWholesale,
                WholesaleCount = element.WholesaleCount,
                WholesalePrice = element.WholesalePrice
            };
        }

        // Validate model dto
        private void ValidateData(ProductDto element)
        {
            _validator.ValidateProductCode(element.ProductCode);
            _validator.ValidatePrice(element.Price);
            _validator.ValidateWholesaleCount(element.WholesaleCount);
            _validator.ValidateWholesalePrice(element.WholesalePrice);
        }

        // Validate model
        private void ValidateData(Product element)
        {
            _validator.ValidateProductCode(element.ProductCode);
            _validator.ValidatePrice(element.Price);
            _validator.ValidateWholesaleCount(element.WholesaleCount);
            _validator.ValidateWholesalePrice(element.WholesalePrice);
        }
    }
}