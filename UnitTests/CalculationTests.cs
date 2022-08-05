using System.Linq;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GroceryMarket.Classes;
using GroceryMarket.Models;

namespace UnitTests
{
    [TestClass]
    public class CalculationTests
    {
        private readonly double _resultABCDABA = 13.25;
        private readonly double _resultCCCCCCC = 6.00;
        private readonly double _resultABCD = 7.25;
        private readonly double _resultZero = 0;

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
        public void CalculationWithoutWholesaleNotZero()
        {
            ProductPriceCalculation priceCalculation = new ProductPriceCalculation();
            Assert.AreNotEqual(priceCalculation.CalculationWithoutWholesale(_products, "BB"), _resultZero);
        }

        [TestMethod]
        public void CalculationWithoutWholesaleWithNullOrder()
        {
            ProductPriceCalculation priceCalculation = new ProductPriceCalculation();
            Assert.AreEqual(priceCalculation.CalculationWithoutWholesale(_products, string.Empty), _resultZero);
        }

        [TestMethod]
        public void CalculationWithoutWholesaleNullPrices()
        {
            ProductPriceCalculation priceCalculation = new ProductPriceCalculation();
            Assert.AreEqual(priceCalculation.CalculationWithoutWholesale(null, "AA"), _resultZero);
        }

        [TestMethod]
        public void CalculationWithWholesaleNotZero()
        {
            ProductPriceCalculation priceCalculation = new ProductPriceCalculation();
            Assert.AreNotEqual(priceCalculation.CalculationWithWholesale(_products, "AA"), _resultZero);
        }

        [TestMethod]
        public void CalculationWithWholesaleWithNullOrder()
        {
            ProductPriceCalculation priceCalculation = new ProductPriceCalculation();
            Assert.AreEqual(priceCalculation.CalculationWithWholesale(_products, string.Empty), _resultZero);
        }

        [TestMethod]
        public void CalculationWithWholesaleWithNullPrices()
        {
            ProductPriceCalculation priceCalculation = new ProductPriceCalculation();
            Assert.AreEqual(priceCalculation.CalculationWithWholesale(null, "AA"), _resultZero);
        }

        [TestMethod]
        public void TotalCalculationNotZero()
        {
            ProductPriceCalculation priceCalculation = new ProductPriceCalculation();
            Assert.AreNotEqual(priceCalculation.TotalCalculation(_products, "ABCDABA"), _resultZero);
        }

        [TestMethod]
        public void TotalCalculationNullOrder()
        {
            ProductPriceCalculation priceCalculation = new ProductPriceCalculation();
            Assert.AreEqual(priceCalculation.TotalCalculation(_products, string.Empty), _resultZero);
        }

        [TestMethod]
        public void TotalCalculationNullPrices()
        {
            ProductPriceCalculation priceCalculation = new ProductPriceCalculation();
            Assert.AreEqual(priceCalculation.TotalCalculation(null, "AA"), _resultZero);
        }

        [TestMethod]
        public void TotalCalculationWithOrderABCDABA()
        {
            ProductPriceCalculation priceCalculation = new ProductPriceCalculation();
            Assert.AreEqual(priceCalculation.TotalCalculation(_products, "ABCDABA"), _resultABCDABA);
        }

        [TestMethod]
        public void TotalCalculationWithOrderCCCCCCC()
        {
            ProductPriceCalculation priceCalculation = new ProductPriceCalculation();
            Assert.AreEqual(priceCalculation.TotalCalculation(_products, "CCCCCCC"), _resultCCCCCCC);
        }

        [TestMethod]
        public void TotalCalculationWithOrderABCD()
        {
            ProductPriceCalculation priceCalculation = new ProductPriceCalculation();
            Assert.AreEqual(priceCalculation.TotalCalculation(_products, "ABCD"), _resultABCD);
        }
    }
}