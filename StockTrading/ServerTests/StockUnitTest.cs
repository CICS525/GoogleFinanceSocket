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
            double msftPrice = mgr.getStockPrice("MSFT");
            Assert.IsNotNull(msftPrice);
            Assert.AreEqual(41.64d, msftPrice);
        }
    }
}
