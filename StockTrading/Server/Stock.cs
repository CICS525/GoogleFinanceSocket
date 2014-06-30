using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Collections;
using System.Net;
using System.Xml;
using System.IO;

namespace StockServer
{
    [Serializable]
    public class Stock
    {
        private string name;
        private double price;
        private int amount;
        // public accessors (or FIELDS, as called in C#)
        #region Accessors
        public string Name
        {
            get { return this.name; }
            set { name = value; }
        }

        public double Price
        {
            get { return this.price; }
            set { price = value; }
        }

        public int Amount
        {
            get { return this.amount; }
            set { amount = value; }
        }
        #endregion

        public Stock()
        {
            name = null;
            price = 0;
            amount = 0;
        }

        public Stock(string stockName, double stockPrice)
        {
            name = stockName;
            price = stockPrice;
        }
        public Stock(string stockName, double stockPrice, int stockAmount)
        {
            name = stockName;
            price = stockPrice;
            amount = stockAmount;
        }
        public static bool validPrice(double price)
        {
            if (price > -1)
                return true;
            else
                return false;
        }
    }
    public class StockListManager   //singleton
    {
        private const string DEFAULT_FILENAME = "StockList.dat";
        private List<Stock> stockList;
        private Object stockListLocker = new Object();
        private static StockListManager that = null;

        #region Accessors
        public List<Stock> Stocks
        {
            get { return this.stockList; }
        }
        #endregion

        public static StockListManager getStockListManager()
        {
            if(that==null)
            {
                that = new StockListManager();
            }
            return that;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        private StockListManager()
        {
            stockList = new List<Stock>();
            ReadFromFile(DEFAULT_FILENAME);
            //...should we update at once? ...
            Update();
        }

        /// <summary>
        /// Update content in stock list via google finance api
        /// </summary>
        public void Update()
        {
            for(int i=0; i<stockList.Count; i++)
            {
                double price = getStockPrice(stockList[i].Name);   //get last price

                lock (stockListLocker)  //mutex
                {
                    stockList[i].Price = price;
                }
            }
            SaveToFile(DEFAULT_FILENAME);
        }

        /// <summary>
        /// Add a new item into the stock list, then saves the file.
        /// </summary>
        /// <param name="newItem"></param>
        public void Add(Stock newItem)
        {
            lock (stockListLocker)
            {
                stockList.Add(newItem);
            }
            //SaveToFile(DEFAULT_FILENAME);
        }

        /// <summary>
        /// Save the stock list into a file. Creates the file if it doesn't exist,
        /// opens it if it does, then writes to it.
        /// </summary>
        /// <param name="filename"></param>
        /// <throw>IOException</throw>
        public void SaveToFile(string filename)
        {
            // create the file if non-existent, or open one for writing.
            // does NOT append to the file, overwrites the whole thing.
            using (StreamWriter writer = new StreamWriter(filename))
            {
                foreach (Stock temp in stockList)
                {
                    string fileLine = String.Format("{0}, {1}", temp.Name, temp.Price);
                    writer.WriteLine(fileLine);
                }
            }
        }

        /// <summary>
        /// Looks for the existence of a stock; if it doesn't exist, creates it and
        /// adds it into the stocklist.
        /// </summary>
        /// <param name="stockName"></param>
        /// <returns>The price of the newly added stock, -1 if the stock doesn't exist</returns>
        public double Query(string stockName)
        {
            lock (stockListLocker)
            {
                foreach (Stock temp in stockList)
                {
                    if (temp.Name.Equals(stockName))
                    {
                        return temp.Price;
                    }
                }
            }

            double price = getStockPrice(stockName); //get the price
            //if (price > -1)
            if( Stock.validPrice(price) )
            {
                Add(new Stock(stockName, price)); //add into the stockList
                SaveToFile(DEFAULT_FILENAME);
            }
            return price;
        }

        /// <summary>
        /// Read the stock list to
        /// </summary>
        /// <param name="filename">File must already exist on system</param>
        public void ReadFromFile(string filename)
        {
            // if the file does not exist, don't do anything, we will create it
            // when we save
            if (!File.Exists(filename)) { return; }
            try
            {
                using (StreamReader reader = new StreamReader(filename))
                {
                    string line;
                    string[] tempArray;
                    while ((line = reader.ReadLine()) != null)
                    {
                        tempArray = line.Split(',');
                        Stock s = new Stock(tempArray[0], Double.Parse(tempArray[1]));
                        Add(s);
                    }
                }
            }
            catch (Exception e)
            {
               Console.WriteLine("Sorry, an error occured: {0}", e.Message);
            }
        }

        /// <summary>
        /// Get the stock price for the specified stock name synchronously.
        /// </summary>
        /// <param name="name">The proper name of the stock</param>
        /// <returns name="price">The price of the stock; -1 if not found.</returns>
        public static double getStockPrice(string name) 
        {
            string requestURL = String.Format("https://query.yahooapis.com/v1/public/yql?q="
                + "select%20AskRealtime%20from%20yahoo.finance.quotes%20where%20symbol%20%3D%20%22" 
                + "{0}"  
                + "%22&env=store%3A%2F%2Fdatatables.org%2Falltableswithkeys",name);
            
            double price = -1.0d;
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
