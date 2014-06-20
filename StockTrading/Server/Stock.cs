using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Collections;
using System.Net;
using System.Xml;

namespace StockServer
{
    public class Stock
    {
        public string name;
        public double price;
    }
    public class StockListManager
    {
        private const string DEFAULT_FILENAME = "StockList.dat";
        private List<Stock> stockList;
        private Object stockListLocker = new Object();

        /// <summary>
        /// Constructor
        /// </summary>
        public StockListManager()
        {
            stockList = new List<Stock>();
            ReadFromFile(DEFAULT_FILENAME);
            //...should we update at once? ...
            Update();
        }
        public ~StockListManager()
        {
            SaveToFile(DEFAULT_FILENAME);
        }
        /// <summary>
        /// Update content in stock list via google finance api
        /// </summary>
        public void Update()
        {
            for(int i=0; i<stockList.Count; i++)
            {
                double price = getStockPrice(stockList[i].name);   //get last price

                lock (stockListLocker)  //mutex
                {
                    stockList[i].price = price;
                }
            }
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
        /// Get the stock price for the specified stock name synchronously.
        /// </summary>
        /// <param name="name">The proper name of the stock</param>
        /// <returns name="price">The price of the stock; 0.0 if not found.</returns>
        static public double getStockPrice(string name) 
        {
            string requestURL = String.Format("https://query.yahooapis.com/v1/public/yql?q="
                + "select%20AskRealtime%20from%20yahoo.finance.quotes%20where%20symbol%20%3D%20%22" 
                + "{0}"  
                + "%22&env=store%3A%2F%2Fdatatables.org%2Falltableswithkeys",name);
            
            double price = 0.0d;
            WebRequest request = WebRequest.Create(new Uri(requestURL));
            
            //using the "USING" keyword to ensure that the request is disposed of 
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {
               //using the USING keyword to ensure the xmlreader is discarded
               using (XmlReader reader = XmlReader.Create(response.GetResponseStream()))
               {
                   reader.ReadToFollowing("AskRealtime");
                   try
                   {
                        price = Double.Parse(reader.ReadElementContentAsString());
                   } catch (Exception e)
                   {
                       Console.WriteLine("Error {0}", e.Message);
                   }
               }
            }
            return price;
        }
    }
}