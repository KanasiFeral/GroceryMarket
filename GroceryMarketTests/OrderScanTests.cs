using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;
using GroceryMarketAPI.Classes;

namespace GroceryMarketTests
{
    [TestClass]
    public class OrderScanTests
    {
        private readonly InitDataRepository _initDataRepository;

        public OrderScanTests()
        {
            _initDataRepository = new InitDataRepository();
        }

        [TestMethod]
        public void ScanWithCorrectOrder()
        {
            OrderScan validation = new OrderScan();
            Assert.AreEqual(validation.Scan(_initDataRepository.Products, 
                _initDataRepository.OrderABCDABA), _initDataRepository.OrderABCDABA);
        }

        [TestMethod]
        public void ScanWithIncorrectOrder()
        {
            OrderScan validation = new OrderScan();
            Assert.AreEqual(validation.Scan(_initDataRepository.Products,
                _initDataRepository.OrderABCDAEBA), _initDataRepository.OrderABCDABA);
        }

        [TestMethod]
        public void ScanNullOrder()
        {
            OrderScan validation = new OrderScan();
            Assert.AreEqual(validation.Scan(_initDataRepository.Products, string.Empty), "");
        }

        [TestMethod]
        public void ScanNullPrices()
        {
            OrderScan validation = new OrderScan();
            Assert.AreEqual(validation.Scan(null, _initDataRepository.OrderABCDABA), "");
        }
    }
}