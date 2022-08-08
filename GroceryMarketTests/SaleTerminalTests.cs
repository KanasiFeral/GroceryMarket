using GroceryMarketAPI.Classes;
using GroceryMarketAPI.ModelsDTO;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace GroceryMarketTests
{
    [TestClass]
    public class SaleTerminalTests
    {
        private readonly InitDataRepository _initDataRepository;

        public SaleTerminalTests()
        {
            _initDataRepository = new InitDataRepository();
        }

        [TestMethod]
        public void SetPricingReturnTrueWithProductsList()
        {
            SaleTerminal terminal = new SaleTerminal();
            Assert.AreEqual(terminal.SetPricing(_initDataRepository.ProductDtos), true);
        }

        [TestMethod]
        public void SetPricingReturnTrueWithSingleProduct()
        {
            SaleTerminal terminal = new SaleTerminal();
            Assert.AreEqual(terminal.SetPricing(_initDataRepository.ProductDto), true);
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
            terminal.SetPricing(_initDataRepository.ProductDtos);
            Assert.AreEqual(terminal.Scan(_initDataRepository.OrderABCDABA), true);
        }

        [TestMethod]
        public void ScanReturnNullScanValue()
        {
            SaleTerminal terminal = new SaleTerminal();
            terminal.SetPricing(_initDataRepository.ProductDtos);
            Assert.AreEqual(terminal.Scan(string.Empty), false);
        }

        [TestMethod]
        public void ScanReturnNullWithIncorrectOrder()
        {
            SaleTerminal terminal = new SaleTerminal();
            terminal.SetPricing(_initDataRepository.ProductDtos);
            Assert.AreEqual(terminal.Scan(_initDataRepository.OrderHHH), false);
        }

        [TestMethod]
        public void CalculateTotalWorkingFine()
        {
            SaleTerminal terminal = new SaleTerminal();
            terminal.SetPricing(_initDataRepository.ProductDtos);
            terminal.Scan(_initDataRepository.OrderCCCCCCC);
            Assert.AreEqual(terminal.CalculateTotal(), _initDataRepository.ResultCCCCCCC);
        }

        [TestMethod]
        public void CalculateTotalReturnZero()
        {
            SaleTerminal terminal = new SaleTerminal();
            terminal.SetPricing(_initDataRepository.ProductDtos);
            terminal.Scan(_initDataRepository.OrderHHH);
            Assert.AreEqual(terminal.CalculateTotal(), _initDataRepository.ResultZero);
        }
    }
}