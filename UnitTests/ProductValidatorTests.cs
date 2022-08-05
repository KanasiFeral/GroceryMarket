using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GroceryMarket.Classes;
using GroceryMarket.Models;


namespace UnitTests
{
    [TestClass]
    public class ProductValidatorTests
    {
        Product IncorrectProductWithNullData = new Product()
        {
            ProductCode = string.Empty,
            Price = -1,
            IsWholesale = true,
            WholesalePrice = -1,
            WholesaleCount = -1
        };

        Product IncorrectProductWithIncorrectData = new Product()
        {
            ProductCode = "ЛЛЛЛЛЛЛЛЛЛЛЛЛЛЛЛЛЛЛЛЛЛЛЛЛЛЛЛЛЛЛЛЛЛЛЛЛЛЛЛЛЛЛЛЛЛЛЛЛЛЛЛЛЛ",
            Price = 1000000000,
            IsWholesale = true,
            WholesalePrice = 1000000000,
            WholesaleCount = 1000000000
        };

        [TestMethod]
        [ExpectedException(typeof(Exception), "ProductCode cannot be empty")]
        public void IsProductCodeEmptyError()
        {
            ProductValidator validator = new ProductValidator();
            validator.ValidateProductCode(IncorrectProductWithNullData.ProductCode);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "ProductCode cannot be more than 50 symbols")]
        public void IsProductCodeLengthError()
        {
            ProductValidator validator = new ProductValidator();
            validator.ValidateProductCode(IncorrectProductWithIncorrectData.ProductCode);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "ProductCode must using only latin letters")]
        public void IsProductCodeLatinLettersError()
        {
            ProductValidator validator = new ProductValidator();
            validator.ValidateProductCode(IncorrectProductWithNullData.ProductCode);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Price cannot be less 0")]
        public void IsPriceLengthError()
        {
            ProductValidator validator = new ProductValidator();
            validator.ValidatePrice(IncorrectProductWithNullData.Price);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Price cannot be more than 1m")]
        public void IsPriceValueError()
        {
            ProductValidator validator = new ProductValidator();
            validator.ValidatePrice(IncorrectProductWithIncorrectData.Price);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Wholesale count cannot be less 0")]
        public void WholesaleCountLengthError()
        {
            ProductValidator validator = new ProductValidator();
            validator.ValidatePrice(IncorrectProductWithNullData.WholesaleCount);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Wholesale count cannot be more than 1m")]
        public void WholesaleCountValueError()
        {
            ProductValidator validator = new ProductValidator();
            validator.ValidatePrice(IncorrectProductWithIncorrectData.WholesaleCount);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "WholesalePrice cannot be less 0")]
        public void WholesalePriceLengthError()
        {
            ProductValidator validator = new ProductValidator();
            validator.ValidatePrice(IncorrectProductWithNullData.WholesalePrice);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "WholesalePrice cannot be more than 1m")]
        public void WholesalePriceValueError()
        {
            ProductValidator validator = new ProductValidator();
            validator.ValidatePrice(IncorrectProductWithIncorrectData.WholesalePrice);
        }
    }
}