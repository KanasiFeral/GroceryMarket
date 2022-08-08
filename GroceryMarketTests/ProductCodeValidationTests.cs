using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;
using GroceryMarketAPI.Classes;

namespace GroceryMarketTests
{
    [TestClass]
    public class ProductCodeValidationTests
    {
        private readonly InitDataRepository _initDataRepository;

        public ProductCodeValidationTests()
        {
            _initDataRepository = new InitDataRepository();
        }

        [TestMethod]
        public void ScanWithCorrectOrder()
        {
            ProductCodeValidation validation = new ProductCodeValidation();
            Assert.AreEqual(validation.Scan(_initDataRepository.Products, 
                _initDataRepository.OrderABCDABA), _initDataRepository.OrderABCDABA);
        }

        [TestMethod]
        public void ScanWithIncorrectOrder()
        {
            ProductCodeValidation validation = new ProductCodeValidation();
            Assert.AreEqual(validation.Scan(_initDataRepository.Products,
                _initDataRepository.OrderABCDAEBA), _initDataRepository.OrderABCDABA);
        }

        [TestMethod]
        public void ScanNullOrder()
        {
            ProductCodeValidation validation = new ProductCodeValidation();
            Assert.AreEqual(validation.Scan(_initDataRepository.Products, string.Empty), "");
        }

        [TestMethod]
        public void ScanNullPrices()
        {
            ProductCodeValidation validation = new ProductCodeValidation();
            Assert.AreEqual(validation.Scan(null, _initDataRepository.OrderABCDABA), "");
        }
    }
}