using GroceryMarketAPI.Classes;
using GroceryMarketAPI.Mapper;
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
            SaleTerminal terminal = new SaleTerminal(new OrderScan(),    
                new PriceCalculator(),    
                new ProductMapper(),    
                new DiscountMapper()
            );
            Assert.AreEqual(terminal.SetPrice(_initDataRepository.ProductDtos, _initDataRepository.DiscountsDtos), true);
        }

        [TestMethod]
        public void SetPricingReturnTrueWithSingleProduct()
        {
            SaleTerminal terminal = new SaleTerminal(new OrderScan(),
                new PriceCalculator(),
                new ProductMapper(),
                new DiscountMapper()
            );
            Assert.AreEqual(terminal.SetPrice(_initDataRepository.ProductDto, _initDataRepository.DiscountDto), true);
        }

        [TestMethod]
        public void SetPricingReturnFalseWithNullValue()
        {
            SaleTerminal terminal = new SaleTerminal(new OrderScan(),
                new PriceCalculator(),
                new ProductMapper(),
                new DiscountMapper()
            );
            Assert.AreEqual(terminal.SetPrice(new List<ProductDto>(), null), false);
        }

        [TestMethod]
        public void ScanWorkingFine()
        {
            SaleTerminal terminal = new SaleTerminal(new OrderScan(),
                new PriceCalculator(),
                new ProductMapper(),
                new DiscountMapper()
            );
            terminal.SetPrice(_initDataRepository.ProductDtos, _initDataRepository.DiscountsDtos);
            Assert.AreEqual(terminal.Scan(_initDataRepository.OrderABCDABA), true);
        }

        [TestMethod]
        public void ScanReturnNullScanValue()
        {
            SaleTerminal terminal = new SaleTerminal(new OrderScan(),
                new PriceCalculator(),
                new ProductMapper(),
                new DiscountMapper()
            );
            terminal.SetPrice(_initDataRepository.ProductDtos, _initDataRepository.DiscountsDtos);
            Assert.AreEqual(terminal.Scan(string.Empty), false);
        }

        [TestMethod]
        public void ScanReturnNullWithIncorrectOrder()
        {
            SaleTerminal terminal = new SaleTerminal(new OrderScan(),
                new PriceCalculator(),
                new ProductMapper(),
                new DiscountMapper()
            );
            terminal.SetPrice(_initDataRepository.ProductDtos, _initDataRepository.DiscountsDtos);
            Assert.AreEqual(terminal.Scan(_initDataRepository.OrderHHH), false);
        }

        [TestMethod]
        public void CalculateTotalWorkingFine()
        {
            SaleTerminal terminal = new SaleTerminal(new OrderScan(),
                new PriceCalculator(),
                new ProductMapper(),
                new DiscountMapper()
            );
            terminal.SetPrice(_initDataRepository.ProductDtos, _initDataRepository.DiscountsDtos);
            terminal.Scan(_initDataRepository.OrderCCCCCCC);
            Assert.AreEqual(terminal.CalculateTotal(), _initDataRepository.ResultCCCCCCC);
        }

        [TestMethod]
        public void CalculateTotalReturnZero()
        {
            SaleTerminal terminal = new SaleTerminal(new OrderScan(),
                new PriceCalculator(),
                new ProductMapper(),
                new DiscountMapper()
            );
            terminal.SetPrice(_initDataRepository.ProductDtos, _initDataRepository.DiscountsDtos);
            terminal.Scan(_initDataRepository.OrderHHH);
            Assert.AreEqual(terminal.CalculateTotal(), _initDataRepository.ResultZero);
        }
    }
}