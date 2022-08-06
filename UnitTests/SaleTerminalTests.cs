using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GroceryMarket.Classes;
using GroceryMarket.ModelsDTO;

namespace UnitTests
{
    [TestClass]
    public class SaleTerminalTests
    {
        private readonly List<ProductDto> _products = new List<ProductDto>()
        {
            new ProductDto()
            {
                ProductCode = "A",
                Price = 1.25,
                IsWholesale = true,
                WholesalePrice = 3.00,
                WholesaleCount = 3
            },
            new ProductDto()
            {
                ProductCode = "B",
                Price = 4.25,
                IsWholesale = false,
                WholesalePrice = 0.00,
                WholesaleCount = 0
            },
            new ProductDto()
            {
                ProductCode = "C",
                Price = 1.00,
                IsWholesale = true,
                WholesalePrice = 5.00,
                WholesaleCount = 6
            }
        };
        private readonly ProductDto _product = new ProductDto()
        {
            ProductCode = "D",
            Price = 0.75,
            IsWholesale = false,
            WholesalePrice = 0.00,
            WholesaleCount = 0
        };
        private readonly string _orderABCDABA = "ABCDABA";
        private readonly string _orderCCCCCCC = "CCCCCCC";
        private readonly string _orderHHH = "HHH";
        private readonly double _resultCCCCCCC = 6.00;
        private readonly double _resultZero = 0;

        [TestMethod]
        public void SetPricingReturnTrueWithProductsList()
        {
            SaleTerminal terminal = new SaleTerminal();
            Assert.AreEqual(terminal.SetPricing(_products), true);
        }

        [TestMethod]
        public void SetPricingReturnTrueWithSingleProduct()
        {
            SaleTerminal terminal = new SaleTerminal();
            Assert.AreEqual(terminal.SetPricing(_product), true);
        }

        [TestMethod]
        public void SetPricingReturnFalseWithNullValue()
        {
            SaleTerminal terminal = new SaleTerminal();
            Assert.AreEqual(terminal.SetPricing(new List<ProductDto>()), false);
        }

        [TestMethod]
        public void ScanWorkingFine()
        {
            SaleTerminal terminal = new SaleTerminal();
            terminal.SetPricing(_products);
            Assert.AreEqual(terminal.Scan(_orderABCDABA), true);
        }

        [TestMethod]
        public void ScanReturnNullScanValue()
        {
            SaleTerminal terminal = new SaleTerminal();
            terminal.SetPricing(_products);
            Assert.AreEqual(terminal.Scan(string.Empty), false);
        }

        [TestMethod]
        public void ScanReturnNullWithIncorrectOrder()
        {
            SaleTerminal terminal = new SaleTerminal();
            terminal.SetPricing(_products);
            Assert.AreEqual(terminal.Scan(_orderHHH), false);
        }

        [TestMethod]
        public void CalculateTotalWorkingFine()
        {
            SaleTerminal terminal = new SaleTerminal();
            terminal.SetPricing(_products);
            terminal.Scan(_orderCCCCCCC);
            Assert.AreEqual(terminal.CalculateTotal(), _resultCCCCCCC);
        }

        [TestMethod]
        public void CalculateTotalReturnZero()
        {
            SaleTerminal terminal = new SaleTerminal();
            terminal.SetPricing(_products);
            terminal.Scan(_orderHHH);
            Assert.AreEqual(terminal.CalculateTotal(), _resultZero);
        }
    }
}