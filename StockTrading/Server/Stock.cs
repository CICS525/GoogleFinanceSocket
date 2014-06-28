﻿using System;
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
    public class Stock
    {
        private string name;
        private double price;
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
        #endregion

        public Stock(string stockName, double stockPrice)
        {
            name = stockName;
            price = stockPrice;
        }
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
        ~StockListManager()
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
                double price = getStockPrice(stockList[i].Name);   //get last price

                lock (stockListLocker)  //mutex
                {
                    stockList[i].Price = price;
                }
            }
        }

        /// <summary>
        /// Add a new item into the stock list
        /// </summary>
        /// <param name="newItem"></param>
        public void Add(Stock newItem)
        {
            stockList.Add(newItem);
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

        public double Query(string stockName)
        {
            //if the stock is in stockList, return price directly
            //if the stock is not in stockList, get last price info, save into stockList then return price
            return 0;
        }

        /// <summary>
        /// Read the stock list to
        /// </summary>
        /// <param name="filename">File must already exist on system</param>
        public void ReadFromFile(string filename)
        {
            try
            {
                using (StreamReader reader = new StreamReader(filename))
                {
                    string line;
                    string[] tempArray;
                    while ((line = reader.ReadLine()) != null)
                    {
                        tempArray = line.Split(',');
                        Add(new Stock(tempArray[0], Double.Parse(tempArray[1])));
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
