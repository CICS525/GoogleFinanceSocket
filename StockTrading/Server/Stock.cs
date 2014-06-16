using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Collections;

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
    }
}