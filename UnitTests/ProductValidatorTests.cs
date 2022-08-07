using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GroceryMarket.Classes;

namespace UnitTests
{
    [TestClass]
    public class ProductValidatorTests
    {
        private readonly InitDataRepository _initDataRepository;

        public ProductValidatorTests()
        {
            _initDataRepository = new InitDataRepository();
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "ProductCode cannot be empty")]
        public void IsProductCodeEmptyError()
        {
            ProductValidator validator = new ProductValidator();
            validator.ValidateProductCode(_initDataRepository.IncorrectProductWithNullData.ProductCode);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "ProductCode cannot be more than 50 symbols")]
        public void IsProductCodeLengthError()
        {
            ProductValidator validator = new ProductValidator();
            validator.ValidateProductCode(_initDataRepository.IncorrectProductWithIncorrectData.ProductCode);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "ProductCode must using only latin letters")]
        public void IsProductCodeLatinLettersError()
        {
            ProductValidator validator = new ProductValidator();
            validator.ValidateProductCode(_initDataRepository.IncorrectProductWithNullData.ProductCode);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Price cannot be less 0")]
        public void IsPriceLengthError()
        {
            ProductValidator validator = new ProductValidator();
            validator.ValidatePrice(_initDataRepository.IncorrectProductWithNullData.Price);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Price cannot be more than 1m")]
        public void IsPriceValueError()
        {
            ProductValidator validator = new ProductValidator();
            validator.ValidatePrice(_initDataRepository.IncorrectProductWithIncorrectData.Price);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Wholesale count cannot be less 0")]
        public void WholesaleCountLengthError()
        {
            ProductValidator validator = new ProductValidator();
            validator.ValidatePrice(_initDataRepository.IncorrectProductWithNullData.WholesaleCount);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Wholesale count cannot be more than 1m")]
        public void WholesaleCountValueError()
        {
            ProductValidator validator = new ProductValidator();
            validator.ValidatePrice(_initDataRepository.IncorrectProductWithIncorrectData.WholesaleCount);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "WholesalePrice cannot be less 0")]
        public void WholesalePriceLengthError()
        {
            ProductValidator validator = new ProductValidator();
            validator.ValidatePrice(_initDataRepository.IncorrectProductWithNullData.WholesalePrice);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "WholesalePrice cannot be more than 1m")]
        public void WholesalePriceValueError()
        {
            ProductValidator validator = new ProductValidator();
            validator.ValidatePrice(_initDataRepository.IncorrectProductWithIncorrectData.WholesalePrice);
        }
    }
}