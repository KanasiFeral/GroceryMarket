using System;
using System.Text.RegularExpressions;
using GroceryMarket.Classes;

namespace GroceryMarket.Models
{
    public class Product
    {
        private readonly int _productCodeLenght = 50;

        private string _productCode;

        public string ProductCode
        {
            get => _productCode;
            set
            {
                // Cannot working with empty name of product
                if (string.IsNullOrEmpty(value))
                {
                    throw new Exception(ErrorCodes.PRODUCT_CODE_VALUE_ERROR_MESSAGE);
                }

                // Using variable to limit product name length
                if (value.Length > _productCodeLenght)
                {
                    throw new Exception(ErrorCodes.PRODUCT_CODE_LENGHT_ERROR_MESSAGE);
                }

                // Checking that user input only latin letters
                if (Regex.IsMatch(value, @"^[a-zA-Z]+$") == false)
                {
                    throw new Exception(ErrorCodes.PRODUCT_CODE_LETTERS_ERROR_MESSAGE);
                }

                _productCode = value;
            }
        }

        private double _price;
        public double Price
        {
            get => _price;
            set 
            {
                // Checking that Price cannot be less or equal than 0
                if (value <= 0)
                {
                    throw new Exception(ErrorCodes.PRICE_LENGHT_ERROR_MESSAGE);
                }

                // Checking that Price cannot be more than 1m
                if (value > 999999)
                {
                    throw new Exception(ErrorCodes.PRICE_VALUE_ERROR_MESSAGE);
                }

                _price = Math.Round(value, 2);
            }
        }

        private double _wholesalePrice;
        public double WholesalePrice
        {
            get => _wholesalePrice;
            set
            {
                // Checking that WholesalePrice cannot be less or equal than 0
                if (value <= 0)
                {
                    if (IsWholesale)
                    {
                        throw new Exception(ErrorCodes.WHOLESALE_LENGHT_ERROR_MESSAGE);
                    }
                }

                // Checking that WholesalePrice cannot be more than 1m
                if (value > 999999)
                {
                    throw new Exception(ErrorCodes.WHOLESALE_VALUE_ERROR_MESSAGE);
                }

                _wholesalePrice = Math.Round(value, 2);
            }
        }

        private double _wholesaleCount;
        public double WholesaleCount
        {
            get => _wholesaleCount;
            set
            {
                // Checking that WholesaleCount cannot be less or equal than 0
                if (value <= 0)
                {
                    if (IsWholesale)
                    {
                        throw new Exception(ErrorCodes.WHOLESALE_COUNT_LENGHT_ERROR_MESSAGE);
                    }
                }

                // Checking that WholesaleCount cannot be more than 1m
                if (value > 999999)
                {
                    throw new Exception(ErrorCodes.WHOLESALE_COUNT_VALUE_ERROR_MESSAGE);
                }

                _wholesaleCount = Math.Round(value, 2);
            }
        }

        public bool IsWholesale { get; set; }
    }
}