using GroceryMarketAPI.Interfaces;
using GroceryMarketAPI.Mapper;
using GroceryMarketAPI.Models;
using GroceryMarketAPI.ModelsDTO;
using NLog;

namespace GroceryMarketAPI.Classes
{
    public class SaleTerminal : ISaleTerminal
    {
        private List<Product> _productPrices;
        private List<Discount> _productDiscounts;
        private string _order;
        private readonly Logger _logger;
        private OrderScan _productCodeValidation;
        private readonly PriceCalculator _productPriceCalculation;
        private readonly MapperBase<Product, ProductDto> _productMapper;
        private readonly MapperBase<Discount, DiscountDto> _discountMapper;

        public SaleTerminal(OrderScan orderScan, 
            PriceCalculator productPriceCalculator, 
            ProductMapper productMapper,
            DiscountMapper discountMapper)
        {
            _productPrices = new List<Product>();
            _productDiscounts = new List<Discount>();
            _order = "";
            _logger = LogManager.GetCurrentClassLogger();

            _productCodeValidation = orderScan;
            _productPriceCalculation = productPriceCalculator;
            _productMapper = productMapper;
            _discountMapper = discountMapper;
        }

        public double CalculateTotal()
        {
            var total = _productPriceCalculation.TotalCalculation(_productPrices, _order);
            _order = string.Empty;
            return total;
        }

        public bool Scan(string productCode)
        {
           _order += _productCodeValidation.Scan(_productPrices, productCode);

            if (string.IsNullOrEmpty(_order))
            {
                return false;
            }

            return true;
        }

        public bool SetPricing(ProductDto product, DiscountDto? discount)
        {
            if (product == null)
            {
                _logger.Info(ErrorCodes.CONFIGURATION_DATA_ARE_EMPTY_ERROR_MESSAGE);
                return false;
            }

            _productPrices.Add(_productMapper.Map(product));

            if (discount != null)
            {
                _productDiscounts.Add(_discountMapper.Map(discount));
            }

            SetDiscount();

            return true;
        }

        public bool SetPricing(List<ProductDto> products, List<DiscountDto>? discounts)
        {
            if (products == null || products.Count() <= 0)
            {
                _logger.Info(ErrorCodes.CONFIGURATION_DATA_ARE_EMPTY_ERROR_MESSAGE);
                return false;
            }

            foreach (var product in products)
            {
                _productPrices.Add(_productMapper.Map(product));
            }

            if (discounts != null && discounts.Count() > 0)
            {
                foreach (var discount in discounts)
                {
                    _productDiscounts.Add(_discountMapper.Map(discount));
                }               
            }

            SetDiscount();

            return true;
        }

        private void SetDiscount()
        {
            foreach (var discount in _productDiscounts)
            {
                if (_productPrices.Any(x => x.ProductCode == discount.ProductCode))
                {
                    _productPrices.First(x => x.ProductCode == discount.ProductCode).Discount = new Discount
                    {
                        ProductCode = discount.ProductCode,
                        WholesaleCount = discount.WholesaleCount,
                        WholesalePrice = discount.WholesalePrice
                    };
                }
            }
        }
    }
}