using System;
using System.Text.RegularExpressions;
using GroceryMarket.Interfaces;

namespace GroceryMarket.Classes
{
    public class ProductValidator : IProductValidator
    {
        private readonly int _productCodeLenght = 50;

        public bool ValidatePrice(double price)
        {
            var isValid = false;

            // Checking that Price cannot be less or equal than 0
            if (price <= 0)
            {
                throw new Exception(ErrorCodes.PRICE_LENGHT_ERROR_MESSAGE);
            }

            // Checking that Price cannot be more than 1m
            if (price > 999999)
            {
                throw new Exception(ErrorCodes.PRICE_VALUE_ERROR_MESSAGE);
            }

            return isValid;
        }

        public bool ValidateProductCode(string productode)
        {
            var isValid = false;

            // Cannot working with empty name of product
            if (string.IsNullOrEmpty(productode))
            {
                throw new Exception(ErrorCodes.PRODUCT_CODE_VALUE_ERROR_MESSAGE);
            }

            // Using variable to limit product name length
            if (productode.Length > _productCodeLenght)
            {
                throw new Exception(ErrorCodes.PRODUCT_CODE_LENGHT_ERROR_MESSAGE);
            }

            // Checking that user input only latin letters
            if (Regex.IsMatch(productode, @"^[a-zA-Z]+$") == false)
            {
                throw new Exception(ErrorCodes.PRODUCT_CODE_LETTERS_ERROR_MESSAGE);
            }

            return isValid;
        }

        public bool ValidateWholesaleCount(int wholesaleCount)
        {
            var isValid = false;

            // Checking that WholesaleCount cannot be less or equal than 0
            if (wholesaleCount <= 0)
            {
                throw new Exception(ErrorCodes.WHOLESALE_COUNT_LENGHT_ERROR_MESSAGE);
            }

            // Checking that WholesaleCount cannot be more than 1m
            if (wholesaleCount > 999999)
            {
                throw new Exception(ErrorCodes.WHOLESALE_COUNT_VALUE_ERROR_MESSAGE);
            }

            return isValid;
        }

        public bool ValidateWholesalePrice(double wholesalePrice)
        {
            var isValid = false;

            // Checking that WholesalePrice cannot be more than 1m
            if (wholesalePrice > 999999)
            {
                throw new Exception(ErrorCodes.WHOLESALE_VALUE_ERROR_MESSAGE);
            }

            return isValid;
        }
    }
}
