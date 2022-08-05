using System.Collections.Generic;
using System.Linq;
using GroceryMarket.Interfaces;
using GroceryMarket.Models;

namespace GroceryMarket.Classes
{
    public class ProductCalculation : ICalculation
    {
        public double CalculationWithoutWholesale(List<Product> productsPrices, string order)
        {
            var total = 0.0;

            // Calculate data without wholesale
            foreach (var productCode in order)
            {
                // Get full info about this current product
                var product = productsPrices.Where(x => x.ProductCode == order).FirstOrDefault();
                // If this product don't have sales for wholesale
                if (!product.IsWholesale)
                {
                    total += product.Price;
                }
            }

            return total;
        }

        public double CalculationWithWholesale(List<Product> productsPrices, string order)
        {
            var total = 0.0;

            // Final calculating with data with wholesale
            foreach (var productCode in order.Distinct())
            {
                // Get full info about this current product
                var product = productsPrices.Where(x => x.ProductCode == productCode.ToString()).FirstOrDefault();
                // If this product have sales for wholesale
                if (product.IsWholesale)
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
                    if (countItems % product.WholesaleCount == 0)
                    {
                        total += product.WholesalePrice * (countItems / product.WholesaleCount);
                    }
                    else
                    {
                        var unevenCount = (int)(countItems / product.WholesaleCount);

                        total += unevenCount * product.WholesalePrice;

                        var remainderCount = countItems - (unevenCount * product.WholesaleCount);

                        total += remainderCount * product.Price;
                    }
                }
            }

            return total;
        }
    }
}