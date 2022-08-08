using System.Text.RegularExpressions;
using GroceryMarketAPI.Interfaces;
using NLog;

namespace GroceryMarketAPI.Classes
{
    public class ProductValidator : IProductValidator
    {
        private readonly int _productCodeLenght = 50;
        private readonly Logger _logger;

        public ProductValidator()
        {
            _logger = LogManager.GetCurrentClassLogger();
        }

        public bool ValidatePrice(double price)
        {
            // Checking that Price cannot be less than 0
            if (price < 0)
            {
                _logger.Error(new Exception(), ErrorCodes.PRICE_LENGHT_ERROR_MESSAGE);
                return false;
            }

            // Checking that Price cannot be more than 1m
            if (price > 999999)
            {
                _logger.Error(new Exception(), ErrorCodes.PRICE_VALUE_ERROR_MESSAGE);
                return false;
            }

            return true;
        }

        public bool ValidateProductCode(string productode)
        {
            // Cannot working with empty name of product
            if (string.IsNullOrEmpty(productode))
            {
                _logger.Error(new Exception(), ErrorCodes.PRODUCT_CODE_VALUE_ERROR_MESSAGE);
                return false;
            }

            // Using variable to limit product name length
            if (productode.Length > _productCodeLenght)
            {
                _logger.Error(new Exception(), ErrorCodes.PRODUCT_CODE_LENGHT_ERROR_MESSAGE);
                return false;
            }

            // Checking that user input only latin letters
            if (Regex.IsMatch(productode, @"^[a-zA-Z]+$") == false)
            {
                _logger.Error(new Exception(), ErrorCodes.PRODUCT_CODE_LETTERS_ERROR_MESSAGE);
                return false;
            }

            return true;
        }

        public bool ValidateWholesaleCount(int wholesaleCount)
        {
            // Checking that WholesaleCount cannot be less than 0
            if (wholesaleCount < 0)
            {
                _logger.Error(new Exception(), ErrorCodes.WHOLESALE_COUNT_LENGHT_ERROR_MESSAGE);
                return false;
            }

            // Checking that WholesaleCount cannot be more than 1m
            if (wholesaleCount > 999999)
            {
                _logger.Error(new Exception(), ErrorCodes.WHOLESALE_COUNT_VALUE_ERROR_MESSAGE);
                return false;
            }

            return true;
        }

        public bool ValidateWholesalePrice(double wholesalePrice)
        {
            // Checking that WholesaleCount cannot be less than 0
            if (wholesalePrice < 0)
            {
                _logger.Error(new Exception(), ErrorCodes.WHOLESALE_LENGHT_ERROR_MESSAGE);
                return false;
            }

            // Checking that WholesalePrice cannot be more than 1m
            if (wholesalePrice > 999999)
            {
                _logger.Error(new Exception(), ErrorCodes.WHOLESALE_VALUE_ERROR_MESSAGE);
                return false;
            }

            return true;
        }
    }
}
