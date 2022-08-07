using Microsoft.VisualStudio.TestTools.UnitTesting;
using GroceryMarket.Classes;

namespace UnitTests
{
    [TestClass]
    public class ProductPriceCalculationTests
    {
        private readonly InitDataRepository _initDataRepository;

        public ProductPriceCalculationTests()
        {
            _initDataRepository = new InitDataRepository();
        }

        [TestMethod]
        public void CalculationWithoutWholesaleNotZero()
        {
            ProductPriceCalculation priceCalculation = new ProductPriceCalculation();
            Assert.AreNotEqual(priceCalculation.CalculationWithoutWholesale(_initDataRepository.Products, "BB"), 
                _initDataRepository.ResultZero);
        }

        [TestMethod]
        public void CalculationWithoutWholesaleWithNullOrder()
        {
            ProductPriceCalculation priceCalculation = new ProductPriceCalculation();
            Assert.AreEqual(priceCalculation.CalculationWithoutWholesale(_initDataRepository.Products, string.Empty),
                _initDataRepository.ResultZero);
        }

        [TestMethod]
        public void CalculationWithoutWholesaleNullPrices()
        {
            ProductPriceCalculation priceCalculation = new ProductPriceCalculation();
            Assert.AreEqual(priceCalculation.CalculationWithoutWholesale(null, "AA"), _initDataRepository.ResultZero);
        }

        [TestMethod]
        public void CalculationWithWholesaleNotZero()
        {
            ProductPriceCalculation priceCalculation = new ProductPriceCalculation();
            Assert.AreNotEqual(priceCalculation.CalculationWithWholesale(_initDataRepository.Products, "AA"),
                _initDataRepository.ResultZero);
        }

        [TestMethod]
        public void CalculationWithWholesaleWithNullOrder()
        {
            ProductPriceCalculation priceCalculation = new ProductPriceCalculation();
            Assert.AreEqual(priceCalculation.CalculationWithWholesale(_initDataRepository.Products, string.Empty),
                _initDataRepository.ResultZero);
        }

        [TestMethod]
        public void CalculationWithWholesaleWithNullPrices()
        {
            ProductPriceCalculation priceCalculation = new ProductPriceCalculation();
            Assert.AreEqual(priceCalculation.CalculationWithWholesale(null, "AA"), _initDataRepository.ResultZero);
        }

        [TestMethod]
        public void TotalCalculationNotZero()
        {
            ProductPriceCalculation priceCalculation = new ProductPriceCalculation();
            Assert.AreNotEqual(priceCalculation.TotalCalculation(_initDataRepository.Products, "ABCDABA"), 
                _initDataRepository.ResultZero);
        }

        [TestMethod]
        public void TotalCalculationNullOrder()
        {
            ProductPriceCalculation priceCalculation = new ProductPriceCalculation();
            Assert.AreEqual(priceCalculation.TotalCalculation(_initDataRepository.Products, string.Empty),
                _initDataRepository.ResultZero);
        }

        [TestMethod]
        public void TotalCalculationNullPrices()
        {
            ProductPriceCalculation priceCalculation = new ProductPriceCalculation();
            Assert.AreEqual(priceCalculation.TotalCalculation(null, "AA"), _initDataRepository.ResultZero);
        }

        [TestMethod]
        public void TotalCalculationWithOrderABCDABA()
        {
            ProductPriceCalculation priceCalculation = new ProductPriceCalculation();
            Assert.AreEqual(priceCalculation.TotalCalculation(_initDataRepository.Products, "ABCDABA"),
                _initDataRepository.ResultABCDABA);
        }

        [TestMethod]
        public void TotalCalculationWithOrderCCCCCCC()
        {
            ProductPriceCalculation priceCalculation = new ProductPriceCalculation();
            Assert.AreEqual(priceCalculation.TotalCalculation(_initDataRepository.Products, "CCCCCCC"),
                _initDataRepository.ResultCCCCCCC);
        }

        [TestMethod]
        public void TotalCalculationWithOrderABCD()
        {
            ProductPriceCalculation priceCalculation = new ProductPriceCalculation();
            Assert.AreEqual(priceCalculation.TotalCalculation(_initDataRepository.Products, "ABCD"),
                _initDataRepository.ResultABCD);
        }
    }
}