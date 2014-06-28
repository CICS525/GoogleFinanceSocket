using System;
using StockServer;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ServerTests
{
    [TestClass]
    public class StockUnitTest
    {
        /// <summary>
        /// Test the intial correctness of the method
        /// </summary>
        [TestMethod]
        public void TestGetStockPrice()
        {
            StockListManager mgr = new StockListManager();
            double msftPrice = StockListManager.getStockPrice("MSFT");
            Assert.IsNotNull(msftPrice);
        }

        [TestMethod]
        public void TestFileRead()
        {
            StockListManager mgr = new StockListManager();
            Assert.AreEqual(2, mgr.Stocks.Count);
        }
    }
}
