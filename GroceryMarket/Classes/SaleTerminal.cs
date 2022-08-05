using System;
using System.Collections.Generic;
using System.Linq;
using GroceryMarket.Interfaces;
using GroceryMarket.Mapper;
using GroceryMarket.Models;
using GroceryMarket.ModelsDTO;
using NLog;

namespace GroceryMarket.Classes
{
    public class SaleTerminal : ISaleTerminal
    {
        // Universal interface for getting config data: xml, file, database and etc.
        private readonly IRepositoryConfig _config;
        // Configuration data
        private List<Product> _productsPrices;
        // Products codes
        private List<string> _productCodes;
        // Logger for save info when something do wrong
        private readonly Logger _logger;
        // Mapper to convert DTO model to internal model
        private readonly MapperBase<Product, ProductDto> _productMapper;

        public SaleTerminal()
        {
            // Using XML class to read config. Can be change for another one
            _config = new XMLConfigReader();
            // Init list to saving production code
            _productCodes = new List<string>();
            // Init log
            _logger = LogManager.GetCurrentClassLogger();
            // Init mapper
            _productMapper = new ProductMapper();
        }

        public double CalculateTotal()
        {
            double total = 0;

            if (_productCodes.Count == 0)
            {
                _logger.Info(ErrorCodes.PRODUCT_CODE_LIST_ARE_EMPTY_ERROR_MESSAGE);
                return total;
            }

            // Calculate data without wholesale
            foreach (var productCode in _productCodes)
            {
                // Get full info about this current product
                var product = _productsPrices.Where(x => x.ProductCode == productCode).FirstOrDefault();
                // If this product don't have sales for wholesale
                if (!product.IsWholesale)
                {
                    total += product.Price;
                }
            }

            // Get prices without wholesale
            var withoutWholesale = _productsPrices.Where(s => !s.IsWholesale).Select(x => x.ProductCode);
            // Remove all values that not having wholesale flag
            foreach (var item in withoutWholesale)
            {
                _productCodes.RemoveAll(x => x == item);
            }

            // Final calculating with data with wholesale
            foreach (var productCode in _productCodes.Distinct())
            {
                // Get full info about this current product
                var product = _productsPrices.Where(x => x.ProductCode == productCode).FirstOrDefault();
                // Getting count of product
                var countItems = _productCodes.Where(x => x == product.ProductCode).Count();
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

            return total;
        }

        public bool Scan(string productCode)
        {
            _productCodes = new List<string>();

            if (string.IsNullOrEmpty(productCode))
            {
                _logger.Error(new ArgumentNullException(), ErrorCodes.PRODUCT_CODE_VALUE_ERROR_MESSAGE);
                return false;
            }

            if (_productsPrices == null || _productsPrices.Count() == 0)
            {
                _logger.Error(new ArgumentNullException(), ErrorCodes.CONFIGURATION_DATA_ARE_EMPTY_ERROR_MESSAGE);
                return false;
            }

            var temp = new List<string>();
            foreach (var code in productCode)
            {
                // Find product code in price list
                if (!_productsPrices.Any(x => x.ProductCode == code.ToString()))
                {
                    _logger.Error(new Exception(), ErrorCodes.PRODUCT_CODE_NOT_FOUND_ERROR_MESSAGE);
                    continue;
                }

                // If product code is correct, adding to the list
                temp.Add(code.ToString());
            }

            // If product code is correct, adding to the list
            _productCodes.AddRange(temp);

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