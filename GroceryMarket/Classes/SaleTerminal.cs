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
        // Configuration data
        private List<Product> _productsPrices;
        // Products codes
        private string _order;
        // Logger for save info when something do wrong
        private readonly Logger _logger;
        // ProductCode validation
        private ProductCodeValidation _productCodeValidation;
        // Calculation total price
        private ProductPriceCalculation _productPriceCalculation;
        // Mapper to convert DTO model to internal model
        private readonly MapperBase<Product, ProductDto> _productMapper;

        public SaleTerminal()
        {
            // Init product prices list
            _productsPrices = new List<Product>();
            // Init order
            _order = "";
            // Init log
            _logger = LogManager.GetCurrentClassLogger();
            // Init ProductCodeValidation
            _productCodeValidation = new ProductCodeValidation();
            // Init ProductCalculation
            _productPriceCalculation = new ProductPriceCalculation();
            // Init mapper
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