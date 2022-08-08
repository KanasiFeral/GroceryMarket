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
        private string _order;
        private readonly Logger _logger;
        private ProductCodeScan _productCodeValidation;
        private readonly ProductPriceCalculator _productPriceCalculation;
        private readonly MapperBase<Product, ProductDto> _productMapper;

        public SaleTerminal()
        {
            _productsPrices = new List<Product>();
            _order = "";
            _logger = LogManager.GetCurrentClassLogger();
            _productCodeValidation = new ProductCodeScan();
            _productPriceCalculation = new ProductPriceCalculator();
            _productMapper = new ProductMapper();
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

        public bool SetPricing(ProductDto product)
        {
            if (product == null)
            {
                _logger.Info(ErrorCodes.CONFIGURATION_DATA_ARE_EMPTY_ERROR_MESSAGE);
                return false;
            }

            _productsPrices.Add(_productMapper.Map(product));
            return true;
        }

        public bool SetPricing(List<ProductDto> products)
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

            return true;
        }
    }
}