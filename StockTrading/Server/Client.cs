using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Collections;

namespace StockServer
{
    class Client
    {
        private string username;
        private float balance;
        private List<Stock> stockOwn;

        /// <summary>
        /// Constructor
        /// </summary>
        public Client(string username)
        {
            stockOwn = new List<Stock>();
        }

        /// <summary>
        /// Query
        /// </summary>
        /// <param name="tickername"></param>
        public void Query(string tickername)
        {
        }

        /// <summary>
        /// Buy
        /// </summary>
        /// <param name="tickername"></param>
        /// <param name="stocks"></param>
        /// <returns></returns>
        public bool Buy(string tickername, int stocks)
        {
            return false;
        }

        /// <summary>
        /// Sell
        /// </summary>
        /// <param name="tickername"></param>
        /// <param name="stocks"></param>
        /// <returns></returns>
        public bool Sell(string tickername, int stocks)
        {
            return false;
        }

        /// <summary>
        /// Save into file as username as filename
        /// </summary>
        public void Save()
        {

        }
    }
}