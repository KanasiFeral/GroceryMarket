using GroceryMarketAPI.Interfaces;
using GroceryMarketAPI.Models;
using NLog;

namespace GroceryMarketAPI.Classes
{
    public class OrderScan : IOrderScan
    {
        private readonly Logger _logger;

        public OrderScan()
        {
            _logger = LogManager.GetCurrentClassLogger();
        }

        public string Scan(List<Product> productsPrices, string order)
        {
            var result = "";

            if (string.IsNullOrEmpty(order))
            {
                _logger.Error(new ArgumentNullException(), ErrorCodes.PRODUCT_CODE_VALUE_ERROR_MESSAGE);
                return result;
            }

            if (productsPrices == null || productsPrices.Count() == 0)
            {
                _logger.Error(new ArgumentNullException(), ErrorCodes.CONFIGURATION_DATA_ARE_EMPTY_ERROR_MESSAGE);
                return result;
            }

            foreach (var productCode in order)
            {
                if (productsPrices.Any(x => x.ProductCode == productCode.ToString()))
                {
                    result += productCode.ToString();
                }
            }

            return result;
        }
    }
}