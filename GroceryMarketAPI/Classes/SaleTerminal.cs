using GroceryMarketAPI.Interfaces;
using GroceryMarketAPI.Mapper;
using GroceryMarketAPI.Models;
using GroceryMarketAPI.ModelsDTO;
using NLog;

namespace GroceryMarketAPI.Classes
{
    public class SaleTerminal : ISaleTerminal
    {
        private List<Product> _productsPrices;
        private List<Discount> _productsDiscounts;
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
            _productsPrices = new List<Product>();
            _productsDiscounts = new List<Discount>();
            _order = "";
            _logger = LogManager.GetCurrentClassLogger();

            _productCodeValidation = orderScan;
            _productPriceCalculation = productPriceCalculator;
            _productMapper = productMapper;
            _discountMapper = discountMapper;
        }

        public double CalculateTotal()
        {
            var total = _productPriceCalculation.TotalCalculation(_productsPrices, _order);
            _order = string.Empty;
            return total;
        }

        public bool Scan(string productCode)
        {
           _order += _productCodeValidation.Scan(_productsPrices, productCode);

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

            _productsPrices.Add(_productMapper.Map(product));

            if (discount != null)
            {
                _productsDiscounts.Add(_discountMapper.Map(discount));
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
                _productsPrices.Add(_productMapper.Map(product));
            }

            if (discounts != null && discounts.Count() > 0)
            {
                foreach (var discount in discounts)
                {
                    _productsDiscounts.Add(_discountMapper.Map(discount));
                }               
            }

            SetDiscount();

            return true;
        }

        private void SetDiscount()
        {
            foreach (var discount in _productsDiscounts)
            {
                if (_productsPrices.Any(x => x.ProductCode == discount.ProductCode))
                {
                    _productsPrices.First(x => x.ProductCode == discount.ProductCode).Discount = new Discount
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