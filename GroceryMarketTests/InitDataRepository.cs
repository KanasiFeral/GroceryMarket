using GroceryMarketAPI.Models;
using GroceryMarketAPI.ModelsDTO;

namespace GroceryMarketTests
{
    public class InitDataRepository
    {
        private readonly string _orderABCDABA = "ABCDABA";
        private readonly string _orderABCDAEBA = "ABCDAEBA";
        private readonly string _orderCCCCCCC = "CCCCCCC";
        private readonly string _orderHHH = "HHH";
        private readonly double _resultABCDABA = 13.25;
        private readonly double _resultCCCCCCC = 6.00;
        private readonly double _resultABCD = 7.25;
        private readonly double _resultZero = 0;

        private readonly List<ProductDto> _productsDto = new List<ProductDto>()
        {
            new ProductDto()
            {
                ProductCode = "A",
                Price = 1.25,
                IsWholesale = true,
                WholesalePrice = 3.00,
                WholesaleCount = 3
            },
            new ProductDto()
            {
                ProductCode = "B",
                Price = 4.25,
                IsWholesale = false,
                WholesalePrice = 0.00,
                WholesaleCount = 0
            },
            new ProductDto()
            {
                ProductCode = "C",
                Price = 1.00,
                IsWholesale = true,
                WholesalePrice = 5.00,
                WholesaleCount = 6
            }
        };
        private readonly ProductDto _productDto = new ProductDto()
        {
            ProductCode = "D",
            Price = 0.75,
            IsWholesale = false,
            WholesalePrice = 0.00,
            WholesaleCount = 0
        };
        private readonly List<Product> _products = new List<Product>()
        {
            new Product()
            {
                ProductCode = "A",
                Price = 1.25,
                IsWholesale = true,
                WholesalePrice = 3.00,
                WholesaleCount = 3
            },
            new Product()
            {
                ProductCode = "B",
                Price = 4.25,
                IsWholesale = false,
                WholesalePrice = 0.00,
                WholesaleCount = 0
            },
            new Product()
            {
                ProductCode = "C",
                Price = 1.00,
                IsWholesale = true,
                WholesalePrice = 5.00,
                WholesaleCount = 6
            },
            new Product()
            {
                ProductCode = "D",
                Price = 0.75,
                IsWholesale = false,
                WholesalePrice = 0.00,
                WholesaleCount = 0
            }
        };
        private readonly Product _incorrectProductWithNullData = new Product()
        {
            ProductCode = string.Empty,
            Price = -1,
            IsWholesale = true,
            WholesalePrice = -1,
            WholesaleCount = -1
        };
        private readonly Product _incorrectProductWithIncorrectData = new Product()
        {
            ProductCode = "ЛЛЛЛЛЛЛЛЛЛЛЛЛЛЛЛЛЛЛЛЛЛЛЛЛЛЛЛЛЛЛЛЛЛЛЛЛЛЛЛЛЛЛЛЛЛЛЛЛЛЛЛЛЛ",
            Price = 1000000000,
            IsWholesale = true,
            WholesalePrice = 1000000000,
            WholesaleCount = 1000000000
        };

        public string OrderABCDABA => _orderABCDABA;
        public string OrderABCDAEBA => _orderABCDAEBA;
        public string OrderCCCCCCC => _orderCCCCCCC;        
        public string OrderHHH => _orderHHH;
        public double ResultABCDABA => _resultABCDABA;
        public double ResultCCCCCCC => _resultCCCCCCC;
        public double ResultABCD => _resultABCD;
        public double ResultZero => _resultZero;
        public List<ProductDto> ProductDtos => _productsDto;
        public ProductDto ProductDto => _productDto;
        public List<Product> Products => _products;
        public Product IncorrectProductWithNullData => _incorrectProductWithNullData;
        public Product IncorrectProductWithIncorrectData => _incorrectProductWithIncorrectData;
    }
}