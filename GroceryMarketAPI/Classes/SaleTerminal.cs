using GroceryMarketAPI.Interfaces;
using GroceryMarketAPI.Mapper;
using GroceryMarketAPI.Models;
using GroceryMarketAPI.ModelsDTO;
using NLog;

namespace GroceryMarketAPI.Classes
{
    public class SaleTerminal : ISaleTerminal
    {
        private List<Product> _productNames;
        private List<Discount> _productDiscounts;
        private List<ProductPrice> _productPrices;
        private string _order;
        private readonly Logger _logger;
        private readonly OrderScan _productCodeValidation;
        private readonly PriceCalculator _productPriceCalculation;
        private readonly MapperBase<Product, ProductDto> _productMapper;
        private readonly MapperBase<Discount, DiscountDto> _discountMapper;
        private readonly MapperBase<ProductPrice, ProductPriceDto> _productPriceMapper;

        public SaleTerminal(OrderScan orderScan, 
            PriceCalculator productPriceCalculator, 
            ProductMapper productMapper,
            DiscountMapper discountMapper,
            ProductPriceMapper productPriceMapper)
        {
            _productNames = new List<Product>();
            _productDiscounts = new List<Discount>();
            _productPrices = new List<ProductPrice>();
            _order = "";
            _logger = LogManager.GetCurrentClassLogger();

            _productCodeValidation = orderScan;
            _productPriceCalculation = productPriceCalculator;
            _productMapper = productMapper;
            _discountMapper = discountMapper;
            _productPriceMapper = productPriceMapper;
        }

        public double CalculateTotal()
        {
            var total = _productPriceCalculation.CalculateTotal(_productNames, _order);
            _order = string.Empty;
            return total;
        }

        public bool Scan(string productCode)
        {
           _order += _productCodeValidation.Scan(_productNames, productCode);

            if (string.IsNullOrEmpty(_order))
            {
                return false;
            }

            return true;
        }

        public bool SetPrice(ProductDto product, ProductPriceDto productPrice, DiscountDto? discount)
        {
            if (product == null || productPrice == null)
            {
                _logger.Info(ErrorCodes.CONFIGURATION_DATA_ARE_EMPTY_ERROR_MESSAGE);
                return false;
            }

            _productNames.Add(_productMapper.Map(product));
            _productPrices.Add(_productPriceMapper.Map(productPrice));

            if (discount != null)
            {
                _productDiscounts.Add(_discountMapper.Map(discount));
            }

            SetProductPrice();
            SetDiscount();

            return true;
        }

        public bool SetPrice(List<ProductDto> products, List<ProductPriceDto> productPrices, List<DiscountDto>? discounts)
        {
            if (products == null || products.Count() <= 0 || productPrices == null || productPrices.Count <= 0)
            {
                _logger.Info(ErrorCodes.CONFIGURATION_DATA_ARE_EMPTY_ERROR_MESSAGE);
                return false;
            }

            foreach (var product in products)
            {
                _productNames.Add(_productMapper.Map(product));
            }

            foreach (var productPrice in productPrices)
            {
                _productPrices.Add(_productPriceMapper.Map(productPrice));
            }

            if (discounts != null && discounts.Count() > 0)
            {
                foreach (var discount in discounts)
                {
                    _productDiscounts.Add(_discountMapper.Map(discount));
                }               
            }

            SetProductPrice();
            SetDiscount();

            return true;
        }

        private void SetDiscount()
        {
            foreach (var discount in _productDiscounts)
            {
                if (_productNames.Any(x => x.ProductCode == discount.ProductCode))
                {
                    _productNames.First(x => x.ProductCode == discount.ProductCode).Discount = new Discount
                    {
                        ProductCode = discount.ProductCode,
                        WholesaleCount = discount.WholesaleCount,
                        WholesalePrice = discount.WholesalePrice
                    };
                }
            }
        }

        private void SetProductPrice()
        {
            foreach (var productPrice in _productPrices)
            {
                if (_productNames.Any(x => x.ProductCode == productPrice.ProductCode))
                {
                    _productNames.First(x => x.ProductCode == productPrice.ProductCode).ProductPrice = new ProductPrice()
                    {
                        ProductCode = productPrice.ProductCode,
                        Price = productPrice.Price
                    };
                }
            }
        }
    }
}