using GroceryMarketAPI.Classes;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace GroceryMarketTests
{
    [TestClass]
    public class ProductValidatorTests
    {
        private readonly InitDataRepository _initDataRepository;

        public ProductValidatorTests()
        {
            _initDataRepository = new InitDataRepository();
        }

        [TestMethod]
        public void ProductCodeEmptyError()
        {
            ProductValidator validator = new ProductValidator();
            Assert.AreEqual(validator.ValidateProductCode(_initDataRepository.IncorrectProductWithNullData.ProductCode), false);
        }

        [TestMethod]
        public void ProductCodeLengthError()
        {
            ProductValidator validator = new ProductValidator();
            Assert.AreEqual(validator.ValidateProductCode(_initDataRepository.IncorrectProductWithIncorrectData.ProductCode), false);
        }       

        [TestMethod]
        public void ProductCodeLatinLettersError()
        {
            ProductValidator validator = new ProductValidator();
            Assert.AreEqual(validator.ValidateProductCode(_initDataRepository.IncorrectProductWithNullData.ProductCode), false);
        }

        [TestMethod]
        public void ProductCodeValid()
        {
            ProductValidator validator = new ProductValidator();
            Assert.AreEqual(validator.ValidateProductCode(_initDataRepository.ProductDto.ProductCode), true);
        }

        [TestMethod]
        public void PriceLengthError()
        {
            ProductValidator validator = new ProductValidator();
            Assert.AreEqual(validator.ValidatePrice(_initDataRepository.IncorrectProductWithNullData.Price), false);
        }

        [TestMethod]
        public void PriceValueError()
        {
            ProductValidator validator = new ProductValidator();
            Assert.AreEqual(validator.ValidatePrice(_initDataRepository.IncorrectProductWithIncorrectData.Price), false);
        }

        [TestMethod]
        public void PriceValueValid()
        {
            ProductValidator validator = new ProductValidator();
            Assert.AreEqual(validator.ValidatePrice(_initDataRepository.ProductDto.Price), true);
        }

        [TestMethod]
        public void WholesaleCountLengthError()
        {
            ProductValidator validator = new ProductValidator();
            Assert.AreEqual(validator.ValidateWholesaleCount(_initDataRepository.IncorrectProductWithNullData.Discount.WholesaleCount), false);
        }

        [TestMethod]
        public void WholesaleCountValueError()
        {
            ProductValidator validator = new ProductValidator();
            Assert.AreEqual(validator.ValidateWholesaleCount(_initDataRepository.IncorrectProductWithIncorrectData.Discount.WholesaleCount), false);
        }

        [TestMethod]
        public void WholesaleCountValid()
        {
            ProductValidator validator = new ProductValidator();
            Assert.AreEqual(validator.ValidateWholesaleCount(_initDataRepository.DiscountProductA.WholesaleCount), true);
        }

        [TestMethod]
        public void WholesalePriceLengthError()
        {
            ProductValidator validator = new ProductValidator();
            Assert.AreEqual(validator.ValidateWholesalePrice(_initDataRepository.IncorrectProductWithNullData.Discount.WholesalePrice), false);
        }

        [TestMethod]
        public void WholesalePriceValueError()
        {
            ProductValidator validator = new ProductValidator();
            Assert.AreEqual(validator.ValidateWholesalePrice(_initDataRepository.IncorrectProductWithIncorrectData.Discount.WholesalePrice), false);
        }

        [TestMethod]
        public void WholesalePriceValid()
        {
            ProductValidator validator = new ProductValidator();
            Assert.AreEqual(validator.ValidateWholesalePrice(_initDataRepository.DiscountProductA.WholesalePrice), true);
        }
    }
}