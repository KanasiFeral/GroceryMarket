using Microsoft.VisualStudio.TestTools.UnitTesting;
using GroceryMarket.Classes;
using GroceryMarket.Models;

namespace UnitTests
{
    [TestClass]
    public class XMLConfigReaderTests
    {
        [TestMethod]
        public void ReadCorrect()
        {
            XMLConfigReader reader = new XMLConfigReader();

            Assert.IsNotNull(reader.Read<Product>());
        }
    }
}