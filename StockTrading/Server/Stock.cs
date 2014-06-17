using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Collections;
using System.Net;

namespace StockServer
{
    class Stock
    {
        string name;
        double price;
    }
    class StockListManager
    {
        private List<Stock> stockList;

        /// <summary>
        /// Constructor
        /// </summary>
        StockListManager()
        {
            stockList = new List<Stock>();
        }
        /// <summary>
        /// Update content in stock list via google finance api
        /// </summary>
        public void Update()
        {

        }

        /// <summary>
        /// Add a new item into the stock list
        /// </summary>
        /// <param name="newItem"></param>
        public void Add(Stock newItem)
        {

        }

        /// <summary>
        /// Save the stock list into a file
        /// </summary>
        /// <param name="filename"></param>
        public void SaveToFile(string filename)
        {

        }

        /// <summary>
        /// Read the stock list to
        /// </summary>
        /// <param name="filename"></param>
        public void ReadFromFile(string filename)
        {
        }

        /// <summary>
        /// Get the stock price for the specified stock name
        /// </summary>
        /// <param name="name">The proper name of the stock</param>
        private void getStockPrice(string name)
        {
            string requestURL = String.Format("https://query.yahooapis.com/v1/public/yql?q="
                + "select%20*%20from%20yahoo.finance.quotes%20where%20symbol%20%3D%20%22" 
                + "{0}"  
                + "%22&env=store%3A%2F%2Fdatatables.org%2Falltableswithkeys",name);
            
            WebRequest request = WebRequest.Create(new Uri(requestURL));
            
            //using the "USING" keyword to ensure that the request is disposed of 
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {

            }

        }
    }
}