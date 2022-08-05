using GroceryMarket.Classes;
using GroceryMarket.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GroceryMarket.Tests
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