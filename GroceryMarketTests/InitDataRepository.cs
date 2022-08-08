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

        private readonly List<ProductDto> _productDtos = new List<ProductDto>()
        {
            new ProductDto()
            {
                ProductCode = "A"
            },
            new ProductDto()
            {
                ProductCode = "B"
            },
            new ProductDto()
            {
                ProductCode = "C"
            }
        };

        private readonly List<ProductPriceDto> _productPriceDtos = new List<ProductPriceDto>()
        {
            new ProductPriceDto()
            {
                ProductCode = "A",
                Price = 1.25
            },
            new ProductPriceDto()
            {
                ProductCode = "B",
                Price = 4.25
            },
            new ProductPriceDto()
            {
                ProductCode = "C",
                Price = 1.00
            }
        };

        private readonly ProductDto _productDto = new ProductDto()
        {
            ProductCode = "A"
        };

        private readonly ProductPriceDto _productPriceDto = new ProductPriceDto()
        {
            ProductCode = "A",
            Price = 1.25
        };

        private readonly DiscountDto _discountDto = new DiscountDto()
        {
            ProductCode = "A",
            WholesalePrice = 3.00,
            WholesaleCount = 3
        };

        private readonly List<DiscountDto> _discountDtos = new List<DiscountDto>()
        {
            new DiscountDto()
            {
                ProductCode = "A",
                WholesalePrice = 3.00,
                WholesaleCount = 3
            },
            new DiscountDto()
            {
                ProductCode = "C",
                WholesalePrice = 5.00,
                WholesaleCount = 6
            },
        };

        private readonly List<Product> _products = new List<Product>()
        {
            new Product()
            {
                ProductCode = "A",
                ProductPrice = new ProductPrice()
                {
                    ProductCode = "A",
                    Price = 1.25
                },
                Discount = new Discount()
                {
                    ProductCode = "A",
                    WholesalePrice = 3.00,
                    WholesaleCount = 3
                }
            },
            new Product()
            {
                ProductCode = "B",
                ProductPrice = new ProductPrice()
                {
                    ProductCode= "B",                       
                    Price =  4.25
                }
            },
            new Product()
            {
                ProductCode = "C",
                ProductPrice = new ProductPrice()
                {
                    ProductCode = "C",
                    Price = 1.00
                },
                Discount = new Discount()
                {
                    ProductCode = "C",
                    WholesalePrice = 5.00,
                    WholesaleCount = 6
                }
            },
            new Product()
            {
                ProductCode = "D",
                ProductPrice = new ProductPrice()
                {
                    ProductCode = "D",
                    Price = 0.75
                }
            }
        };

        private readonly Discount _discountProductA = new Discount()
        {
            ProductCode = "A",
            WholesalePrice = 3.00,
            WholesaleCount = 3
        };

        private readonly Product _incorrectProductWithNullData = new Product()
        {
            ProductCode = string.Empty,
            ProductPrice = new ProductPrice()
            {
                ProductCode = string.Empty,
                Price = -1
            },
            Discount = new Discount()
            {
                ProductCode = string.Empty,
                WholesalePrice = -1,
                WholesaleCount = -1
            }
        };

        private readonly Product _incorrectProductWithIncorrectData = new Product()
        {
            ProductCode = "ЛЛЛЛЛЛЛЛЛЛЛЛЛЛЛЛЛЛЛЛЛЛЛЛЛЛЛЛЛЛЛЛЛЛЛЛЛЛЛЛЛЛЛЛЛЛЛЛЛЛЛЛЛЛ",
            ProductPrice = new ProductPrice()
            {
                ProductCode = "ЛЛЛЛЛЛЛЛЛЛЛЛЛЛЛЛЛЛЛЛЛЛЛЛЛЛЛЛЛЛЛЛЛЛЛЛЛЛЛЛЛЛЛЛЛЛЛЛЛЛЛЛЛЛ",
                Price = 1000000000
            },
            Discount = new Discount()
            {
                ProductCode = "ЛЛЛЛЛЛЛЛЛЛЛЛЛЛЛЛЛЛЛЛЛЛЛЛЛЛЛЛЛЛЛЛЛЛЛЛЛЛЛЛЛЛЛЛЛЛЛЛЛЛЛЛЛЛ",
                WholesalePrice = 1000000000,
                WholesaleCount = 1000000000
            }
        };

        public string OrderABCDABA => _orderABCDABA;
        public string OrderABCDAEBA => _orderABCDAEBA;
        public string OrderCCCCCCC => _orderCCCCCCC;
        public string OrderHHH => _orderHHH;
        public double ResultABCDABA => _resultABCDABA;
        public double ResultCCCCCCC => _resultCCCCCCC;
        public double ResultABCD => _resultABCD;
        public double ResultZero => _resultZero;
        public List<ProductDto> ProductDtos => _productDtos;
        public List<ProductPriceDto> ProductPriceDtos => _productPriceDtos;
        public ProductDto ProductDto => _productDto;
        public ProductPriceDto ProductPriceDto => _productPriceDto;
        public DiscountDto DiscountDto => _discountDto;
        public List<DiscountDto> DiscountsDtos => _discountDtos;
        public List<Product> Products => _products;
        public Discount DiscountProductA => _discountProductA;
        public Product IncorrectProductWithNullData => _incorrectProductWithNullData;
        public Product IncorrectProductWithIncorrectData => _incorrectProductWithIncorrectData;
    }
}