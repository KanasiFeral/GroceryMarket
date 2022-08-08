using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;
using GroceryMarketAPI.Classes;

namespace GroceryMarketTests
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
        public void TotalCalculationNotZero()
        {
            ProductPriceCalculator priceCalculation = new ProductPriceCalculator();
            Assert.AreNotEqual(priceCalculation.TotalCalculation(_initDataRepository.Products, "ABCDABA"), 
                _initDataRepository.ResultZero);
        }

        [TestMethod]
        public void TotalCalculationNullOrder()
        {
            ProductPriceCalculator priceCalculation = new ProductPriceCalculator();
            Assert.AreEqual(priceCalculation.TotalCalculation(_initDataRepository.Products, string.Empty),
                _initDataRepository.ResultZero);
        }

        [TestMethod]
        public void TotalCalculationNullPrices()
        {
            ProductPriceCalculator priceCalculation = new ProductPriceCalculator();
            Assert.AreEqual(priceCalculation.TotalCalculation(null, "AA"), _initDataRepository.ResultZero);
        }

        [TestMethod]
        public void TotalCalculationWithOrderABCDABA()
        {
            ProductPriceCalculator priceCalculation = new ProductPriceCalculator();
            Assert.AreEqual(priceCalculation.TotalCalculation(_initDataRepository.Products, "ABCDABA"),
                _initDataRepository.ResultABCDABA);
        }

        [TestMethod]
        public void TotalCalculationWithOrderCCCCCCC()
        {
            ProductPriceCalculator priceCalculation = new ProductPriceCalculator();
            Assert.AreEqual(priceCalculation.TotalCalculation(_initDataRepository.Products, "CCCCCCC"),
                _initDataRepository.ResultCCCCCCC);
        }

        [TestMethod]
        public void TotalCalculationWithOrderABCD()
        {
            ProductPriceCalculator priceCalculation = new ProductPriceCalculator();
            Assert.AreEqual(priceCalculation.TotalCalculation(_initDataRepository.Products, "ABCD"),
                _initDataRepository.ResultABCD);
        }
    }
}