using GroceryMarketAPI.Interfaces;
using GroceryMarketAPI.Models;
using NLog;

namespace GroceryMarketAPI.Classes
{
    public class PriceCalculator : IPriceCalculator
    {
        // Logger for save info when something do wrong
        private readonly Logger _logger;

        public PriceCalculator()
        {
            // Init log
            _logger = LogManager.GetCurrentClassLogger();
        }

        private double CalculationWithoutWholesale(List<Product> productsPrices, string order)
        {
            var total = 0.0;

            // Calculate data without wholesale
            foreach (var productCode in order)
            {
                // Get full info about this current product
                var product = productsPrices.Where(x => x.ProductCode == productCode.ToString()).FirstOrDefault();
                // If product code in the price list
                if (product != null)
                {
                    // If this product don't have sales for wholesale
                    if (product.Discount == null)
                    {
                        total += product.Price;
                    }
                }
            }

            return total;
        }

        private double CalculationWithWholesale(List<Product> productsPrices, string order)
        {
            var total = 0.0;

            // Final calculating with data with wholesale
            foreach (var productCode in order.Distinct())
            {
                // Get full info about this current product
                var product = productsPrices.Where(x => x.ProductCode == productCode.ToString()).FirstOrDefault();
                // If product code in the price list
                if (product != null)
                {
                    // If this product have sales for wholesale
                    if (product.Discount != null)
                    {
                        // Getting count of product
                        var countItems = order.Where(x => x.ToString() == product.ProductCode).Count();
                        // If item is wholesale, but only one
                        if (countItems == 1)
                        {
                            total += product.Price;
                            continue;
                        }
                        // If we can sell this item as wholesale
                        if (countItems % product.Discount.WholesaleCount == 0)
                        {
                            total += product.Discount.WholesalePrice * (countItems / product.Discount.WholesaleCount);
                        }
                        else
                        {
                            var unevenCount = countItems / product.Discount.WholesaleCount;

                            total += unevenCount * product.Discount.WholesalePrice;

                            var remainderCount = countItems - (unevenCount * product.Discount.WholesaleCount);

                            total += remainderCount * product.Price;
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

            // Calculating products without wholesale
            total += CalculationWithoutWholesale(productsPrices, order);

            // Calculating products with wholesale
            total += CalculationWithWholesale(productsPrices, order);

            return total;
        }
    }
}