using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Collections;
using StockCommand;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;


namespace StockServer
{
    [Serializable]
    public class ClientData
    {
        public string username;
        public double balance;
        public List<Stock> stockOwn;

        public ClientData()
        {
            username = null;
            balance = 0.0;
            stockOwn = null;
        }
        public ClientData(Client client)
        {
            if (client!=null)
            {
                this.username = client.Username;
                this.balance = client.Balance;
                this.stockOwn = client.StockOwn;
            }
        }
    }

    public class Client
    {
        private string username;
        private double balance;
        private List<Stock> stockOwn;

        #region Accessors
        public string Username
        {
            get { return this.username; }
            set { username = value; }
        }
        public double Balance
        {
            get { return this.balance; }
            set { balance = value; }
        }
        public List<Stock> StockOwn
        {
            get { return this.stockOwn; }
            set { stockOwn = value; }
        }
        #endregion

        public Client()
        {
            username = null;
            balance = 0.0;
            stockOwn = null;
        }
        /// <summary>
        /// Constructor
        /// </summary>
        public Client(string username)
        {
            this.username = username;
            //open the user file to load his balance and stocklist
            //if can not find the user's file, then this is a new client, create a new file & save initial balance for him.
            bool bF = File.Exists(getFileName());
            if (bF)
            {
                balance = 0;
                stockOwn = new List<Stock>();
                using (StreamReader reader = new StreamReader(getFileName()))
                {
                    string line = reader.ReadToEnd();
                    ClientData temp = DeserializeFromString(line);
                    this.balance = temp.balance;
                    this.stockOwn = temp.stockOwn;
                }
            }
            else
            {
                balance = 1000;
                stockOwn = new List<Stock>();
                SaveToFile();
            }
        }

        /// <summary>
        /// Buy
        /// </summary>
        /// <param name="tickername"></param>
        /// <param name="amount"></param>
        /// <returns></returns>
        public bool Buy(string tickername, int amount)
        {
            StockListManager stockListManager = StockListManager.getStockListManager();
            double price = stockListManager.Query(tickername);
            bool suc = false;

            if (Stock.validPrice(price) && amount > 0)
            {
                if (balance >= amount * price)
                {
                    balance -= amount * price;
                    foreach (Stock one in stockOwn)
                    {
                        if (tickername.CompareTo(one.Name) == 0)    //the same stock has already in stock Own list
                        {
                            one.Amount += amount;
                            suc = true;
                            break;
                        }
                    }
                    if (!suc)  //the stock amount has NOT been updated
                    {
                        Stock item = new Stock(tickername, price, amount);
                        stockOwn.Add(item);
                        suc = true;
                    }
                }

                if (suc)
                    SaveToFile();
            }
            return suc;
        }

        /// <summary>
        /// Sell
        /// </summary>
        /// <param name="tickername"></param>
        /// <param name="amount"></param>
        /// <returns></returns>
        public bool Sell(string tickername, int amount)
        {
            StockListManager stockListManager = StockListManager.getStockListManager();
            double price = stockListManager.Query(tickername);

            bool suc = false;
            if (Stock.validPrice(price) && amount > 0)
            {
                for (int i = 0; i < stockOwn.Count; i++)
                {
                    if (tickername.CompareTo(stockOwn[i].Name) == 0)    //the same stock has already in stock Own list
                    {
                        if (stockOwn[i].Amount >= amount)
                        {
                            stockOwn[i].Amount -= amount;
                            balance += price * amount;
                            suc = true;

                            if (stockOwn[i].Amount == 0)    //no more this stock, remove it from stock list
                            {
                                stockOwn.RemoveAt(i);
                            }
                            break;
                        }
                    }
                }

                if (suc)
                    SaveToFile();
            }

            return suc;
        }

        public string ListClientInfo()
        {
            //return "return:\r\nclient info in several stings\r\n";
            string s = string.Format("Balance: {0:00}\r\n", balance);
            foreach (Stock one in stockOwn)
            {
                s += string.Format("Stock {0}: {1} share(s)\r\n", one.Name, one.Amount);
            }
            return s;
        }

        /// <summary>
        /// Save into file as username as filename
        /// </summary>
        private bool SaveToFile()
        {
            //every client should have a single file to save all his balance and stocklist
            string filename = getFileName();
            string xml = SerializeToString(this);
            using (StreamWriter writer = new StreamWriter(filename))
            {
                writer.WriteLine(xml);
            }
            return true;
        }
        private string getFileName()
        {
            string filename = username + ".txt";
            return filename;
        }
        public static string SerializeToString(Client client)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(ClientData));
            ClientData data = new ClientData(client);
            using (StringWriter writer = new StringWriter())
            {
                serializer.Serialize(writer, data);
                return writer.ToString();
            }
        }
        public static ClientData DeserializeFromString(string str)
        {
            var serializer = new XmlSerializer(typeof(ClientData));
            ClientData result;
            using (TextReader reader = new StringReader(str))
            {
                result = (ClientData)serializer.Deserialize(reader);
            }
            return result;
        }
    }
}
