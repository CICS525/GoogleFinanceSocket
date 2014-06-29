using System;
using StockServer;
using System.IO;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ServerTests
{
    [TestClass]
    public class StockUnitTest
    {
        StockListManager mgr = new StockListManager();
        /// <summary>
        /// Test the intial correctness of the method
        /// </summary>
        [TestMethod]
        public void TestGetStockPrice()
        {
            double msftPrice = StockListManager.getStockPrice("MSFT");
            Console.WriteLine(msftPrice);
            Assert.IsNotNull(msftPrice);
        }

        [TestMethod]
        public void TestInvalidStock()
        {
            double price = StockListManager.getStockPrice("SMS");
            Console.WriteLine(price);
            Assert.AreEqual(-1.0d, price);
        }

        [TestMethod]
        public void TestFileRead()
        {

            Assert.AreEqual(3, mgr.Stocks.Count);
        }

        [TestMethod]
        public void TestQuery()
        {
            double price = mgr.Query("GOOG");
            Assert.AreEqual(3, mgr.Stocks.Count);
        }

        [TestMethod]
        public void TestWrite()
        {
            Dictionary<string, int> stockList = new Dictionary<string, int>();
            using (StreamReader reader = new StreamReader("StockList.dat"))
            {
                string line;
                string[] tempArray;
                while ((line = reader.ReadLine()) != null)
                {
                    tempArray = line.Split(',');
                    if (tempArray[0].Equals("GOOG"))
                    {
                        stockList.Add(tempArray[0], 100);
                    }
                    else
                    {
                        stockList.Add(tempArray[0], 0);
                    }
                }
            }

            Assert.AreEqual(100, stockList["GOOG"]);
        }
    }
}
