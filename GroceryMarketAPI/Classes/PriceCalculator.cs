using GroceryMarketAPI.Interfaces;
using GroceryMarketAPI.Models;
using NLog;

namespace GroceryMarketAPI.Classes
{
    public class PriceCalculator : IPriceCalculator
    {
        private readonly Logger _logger;

        public PriceCalculator()
        {
            _logger = LogManager.GetCurrentClassLogger();
        }

        private static double CalculateWithoutWholesale(List<Product> productsPrices, string order)
        {
            var total = 0.0;

            foreach (var productCode in order)
            {
                var product = productsPrices.Where(x => x.ProductCode == productCode.ToString()).FirstOrDefault();

                if (product != null)
                {
                    if (product.Discount == null)
                    {
                        total += product.ProductPrice.Price;
                    }
                }
            }

            return total;
        }

        private static double CalculateWithWholesale(List<Product> productsPrices, string order)
        {
            var total = 0.0;

            foreach (var productCode in order.Distinct())
            {
                var product = productsPrices.Where(x => x.ProductCode == productCode.ToString()).FirstOrDefault();

                if (product != null)
                {
                    if (product.Discount != null)
                    {
                        var countItems = order.Where(x => x.ToString() == product.ProductCode).Count();

                        if (countItems == 1)
                        {
                            total += product.ProductPrice.Price;
                            continue;
                        }

                        if (countItems % product.Discount.WholesaleCount == 0)
                        {
                            total += product.Discount.WholesalePrice * (countItems / product.Discount.WholesaleCount);
                        }
                        else
                        {
                            var unevenCount = countItems / product.Discount.WholesaleCount;

                            total += unevenCount * product.Discount.WholesalePrice;

                            var remainderCount = countItems - (unevenCount * product.Discount.WholesaleCount);

                            total += remainderCount * product.ProductPrice.Price;
                        }
                    }
                }
            }

            return total;
        }

        public double CalculateTotal(List<Product> productsPrices, string order)
        {
            var total = 0.0;

            if (string.IsNullOrEmpty(order))
            {
                _logger.Error(new ArgumentNullException(), ErrorCodes.PRODUCT_CODE_VALUE_ERROR_MESSAGE);
                return total;
            }

            if (productsPrices == null || productsPrices.Count() == 0)
            {
                _logger.Error(new ArgumentNullException(), ErrorCodes.CONFIGURATION_DATA_ARE_EMPTY_ERROR_MESSAGE);
                return total;
            }

            total += CalculateWithoutWholesale(productsPrices, order);

            total += CalculateWithWholesale(productsPrices, order);

            return total;
        }
    }
}