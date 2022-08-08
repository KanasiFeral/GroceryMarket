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
        private readonly SaleTerminal _saleTerminal;

        public SaleTerminalTests()
        {
            _initDataRepository = new InitDataRepository();
            _saleTerminal = new SaleTerminal(new OrderScan(),
                new PriceCalculator(),
                new ProductMapper(),
                new DiscountMapper(),
                new ProductPriceMapper()
            );
        }

        [TestMethod]
        public void SetPricingReturnTrueWithProductsList()
        {
            Assert.AreEqual(_saleTerminal.SetPrice(_initDataRepository.ProductDtos, 
                _initDataRepository.ProductPriceDtos, 
                _initDataRepository.DiscountsDtos), true);
        }

        [TestMethod]
        public void SetPricingReturnTrueWithSingleProduct()
        {
            Assert.AreEqual(_saleTerminal.SetPrice(_initDataRepository.ProductDto, 
                _initDataRepository.ProductPriceDto, 
                _initDataRepository.DiscountDto), true);
        }

        [TestMethod]
        public void SetPricingReturnFalseWithNullValue()
        {
            Assert.AreEqual(_saleTerminal.SetPrice(new List<ProductDto>(), new List<ProductPriceDto>(), null), false);
        }

        [TestMethod]
        public void ScanWorkingFine()
        {
            _saleTerminal.SetPrice(_initDataRepository.ProductDtos, 
                _initDataRepository.ProductPriceDtos, 
                _initDataRepository.DiscountsDtos);
            Assert.AreEqual(_saleTerminal.Scan(_initDataRepository.OrderABCDABA), true);
        }

        [TestMethod]
        public void ScanReturnNullScanValue()
        {
            _saleTerminal.SetPrice(_initDataRepository.ProductDtos, 
                _initDataRepository.ProductPriceDtos,
                _initDataRepository.DiscountsDtos);
            Assert.AreEqual(_saleTerminal.Scan(string.Empty), false);
        }

        [TestMethod]
        public void ScanReturnNullWithIncorrectOrder()
        {
            _saleTerminal.SetPrice(_initDataRepository.ProductDtos, 
                _initDataRepository.ProductPriceDtos, 
                _initDataRepository.DiscountsDtos);
            Assert.AreEqual(_saleTerminal.Scan(_initDataRepository.OrderHHH), false);
        }

        [TestMethod]
        public void CalculateTotalWorkingFine()
        {
            _saleTerminal.SetPrice(_initDataRepository.ProductDtos, 
                _initDataRepository.ProductPriceDtos,
                _initDataRepository.DiscountsDtos);
            _saleTerminal.Scan(_initDataRepository.OrderCCCCCCC);
            Assert.AreEqual(_saleTerminal.CalculateTotal(), _initDataRepository.ResultCCCCCCC);
        }

        [TestMethod]
        public void CalculateTotalReturnZero()
        {
            _saleTerminal.SetPrice(_initDataRepository.ProductDtos, 
                _initDataRepository.ProductPriceDtos, 
                _initDataRepository.DiscountsDtos);
            _saleTerminal.Scan(_initDataRepository.OrderHHH);
            Assert.AreEqual(_saleTerminal.CalculateTotal(), _initDataRepository.ResultZero);
        }
    }
}