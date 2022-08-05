using System.Linq;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GroceryMarket.Classes;
using GroceryMarket.Models;

namespace UnitTests
{
    [TestClass]
    public class ProductCodeValidationTests
    {
        private readonly string _orderABCDABA = "ABCDABA";
        private readonly string _orderABCDAEBA = "ABCDAEBA";

        private readonly List<Product> _products = new List<Product>()
        {
            new Product()
            {
                ProductCode = "A",
                Price = 1.25,
                IsWholesale = true,
                WholesalePrice = 3.00,
                WholesaleCount = 3
            },
            new Product()
            {
                ProductCode = "B",
                Price = 4.25,
                IsWholesale = false,
                WholesalePrice = 0.00,
                WholesaleCount = 0
            },
            new Product()
            {
                ProductCode = "C",
                Price = 1.00,
                IsWholesale = true,
                WholesalePrice = 5.00,
                WholesaleCount = 6
            },
            new Product()
            {
                ProductCode = "D",
                Price = 0.75,
                IsWholesale = false,
                WholesalePrice = 0.00,
                WholesaleCount = 0
            }
        };

        [TestMethod]
        public void ScanWithCorrectOrder()
        {
            ProductCodeValidation validation = new ProductCodeValidation();
            Assert.AreEqual(validation.Scan(_products, _orderABCDABA), _orderABCDABA);
        }

        [TestMethod]
        public void ScanWithIncorrectOrder()
        {
            ProductCodeValidation validation = new ProductCodeValidation();
            Assert.AreEqual(validation.Scan(_products, _orderABCDAEBA), _orderABCDABA);
        }

        [TestMethod]
        public void ScanNullOrder()
        {
            ProductCodeValidation validation = new ProductCodeValidation();
            Assert.AreEqual(validation.Scan(_products, string.Empty), "");
        }

        [TestMethod]
        public void ScanNullPrices()
        {
            ProductCodeValidation validation = new ProductCodeValidation();
            Assert.AreEqual(validation.Scan(null, _orderABCDABA), "");
        }
    }
}