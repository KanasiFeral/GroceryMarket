using System.Linq;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GroceryMarket.Classes;
using GroceryMarket.ModelsDTO;

namespace UnitTests
{
    [TestClass]
    public class SaleTerminalTests
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
            }
        };

        private readonly Product _product = new Product() 
        {
            ProductCode = "D",
            Price = 0.75,
            IsWholesale = false,
            WholesalePrice = 0.00,
            WholesaleCount = 0
        };

        private readonly Product _incorrectProduct = new Product()
        {
            ProductCode = "H",
            Price = 8,
            IsWholesale = false,
            WholesalePrice = 0,
            WholesaleCount = 0
        };

        [TestMethod]
        public void ScanCorrectProducteCode()
        {
            SaleTerminal terminal = new SaleTerminal();
            terminal.SetPricing(_products);
            var result = terminal.Scan(_products.FirstOrDefault().ProductCode);
            Assert.AreEqual(result, true);
        }

        [TestMethod]
        public void ScanIncorrectProducteCode()
        {
            SaleTerminal terminal = new SaleTerminal();
            terminal.SetPricing(_products);
            var result = terminal.Scan(_incorrectProduct.ProductCode);
            Assert.AreEqual(result, true);
        }

        [TestMethod]
        public void ScanProducteCodeWithoutSetPricing()
        {
            SaleTerminal terminal = new SaleTerminal();
            var result = terminal.Scan(_products.FirstOrDefault().ProductCode);
            Assert.AreEqual(result, false);
        }

        [TestMethod]
        public void ScanNullProducteCode()
        {
            SaleTerminal terminal = new SaleTerminal();
            terminal.SetPricing(_products);
            var result = terminal.Scan(string.Empty);
            Assert.AreEqual(result, false);
        }

        [TestMethod]
        public void CalculateProducteCodeWithoutNullResult()
        {
            SaleTerminal terminal = new SaleTerminal();
            terminal.SetPricing(_products);
            terminal.Scan(_products[0].ProductCode);
            terminal.Scan(_products[1].ProductCode);
            Assert.AreNotEqual(terminal.CalculateTotal(), true);
        }

        [TestMethod]
        public void CalculateProducteCodeWithZeroResult()
        {
            SaleTerminal terminal = new SaleTerminal();
            terminal.Scan(_products.FirstOrDefault().ProductCode);
            Assert.AreEqual(terminal.CalculateTotal(), _resultZero);
        }

        [TestMethod]
        public void CalculateProducteCodeWitABCDABA()
        {
            SaleTerminal terminal = new SaleTerminal();
            terminal.SetPricing(_products);
            terminal.Scan("ABCDABA");
            Assert.AreEqual(terminal.CalculateTotal(), _resultABCDABA);
        }

        [TestMethod]
        public void CalculateProducteCodeWitCCCCCCC()
        {
            SaleTerminal terminal = new SaleTerminal();
            terminal.SetPricing(_products);
            terminal.Scan("CCCCCCC");
            Assert.AreEqual(terminal.CalculateTotal(), _resultCCCCCCC);
        }

        [TestMethod]
        public void CalculateProducteCodeWitABCD()
        {
            SaleTerminal terminal = new SaleTerminal();
            terminal.SetPricing(_products);
            terminal.Scan("ABCD");
            Assert.AreEqual(terminal.CalculateTotal(), _resultABCD);
        }

        [TestMethod]
        public void SetPricing()
        {
            SaleTerminal terminal = new SaleTerminal();
            Assert.AreEqual(terminal.SetPricing(_products), true);
        }
    }
}