using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Collections;
using StockCommand;

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
            this.username = username;
            //open the user file to load his balance and stocklist
            //if can not find the user's file, then this is a new client, create a new file & save initial balance for him.
            stockOwn = new List<Stock>();
            balance = 0;
        }

        /// <summary>
        /// Buy
        /// </summary>
        /// <param name="tickername"></param>
        /// <param name="stocks"></param>
        /// <returns></returns>
        public bool Buy(string tickername, int stocks)
        {
            bool suc = false;
            if(suc)
                Save();
            return suc;
        }

        /// <summary>
        /// Sell
        /// </summary>
        /// <param name="tickername"></param>
        /// <param name="stocks"></param>
        /// <returns></returns>
        public bool Sell(string tickername, int stocks)
        {
            bool suc = false;
            if (suc)
                Save();
            return suc;
        }

        public string ListClientInfo()
        {
            return "return:\r\nclient info in several stings\r\n";
        }

        /// <summary>
        /// Save into file as username as filename
        /// </summary>
        private void Save()
        {
            //every client should have a single file to save all his balance and stocklist
        }
    }
}