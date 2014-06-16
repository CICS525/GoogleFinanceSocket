using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace StockServer
{
    class StockServer
    {
        static Dictionary<string, float> stockPrices = new Dictionary<string, float>();
        static string data = null; //data from client

        static void Main(string[] args)
        {
            Thread updateThread = new Thread(startServer);
            updateThread.Start();
            Thread requestThread = new Thread(handleRequest);
            requestThread.Start();
        }

        public static void startServer()
        {
            // set the starting IP and port for the server
            IPHostEntry ipInfo = Dns.Resolve(Dns.GetHostName());
            IPAddress ipAddr = ipInfo.AddressList[0];
            IPEndPoint local = new IPEndPoint(ipAddr, 9001);
            //data buffer from clients
            byte[] bytes = new Byte[1024]; 

            //create TCP socket
            Socket listener = new Socket(AddressFamily.InterNetwork, SocketType.Stream,
                ProtocolType.Tcp);
            try
            {
                listener.Bind(local);
                listener.Listen(10); // 10 incoming connections allowed.

                while (true)
                {
                    Socket incomingData = listener.Accept();
                    data = null;

                    // proccess the incoming data
                    while (true)
                    {
                        Console.WriteLine("Incoming connection detected");
                        bytes = new Byte[1024];
                        int incomingBytes = incomingData.Receive(bytes);
                        data += Encoding.UTF8.GetString(bytes, 0, incomingBytes);
                        if (data.IndexOf("\n") > -1)
                        {
                            break;
                        }

                    }
                    handleData(data, ref incomingData); // pass socket by reference, as to not create a new one.
                }


            }
            catch (Exception e)
            {
                Console.WriteLine("Sorry an error occured: {0}", e.Message);
            }
        }

        public static void handleRequest()
        {
            // set the starting IP and port for the server
            IPHostEntry ipInfo = Dns.Resolve(Dns.GetHostName());
            IPAddress ipAddr = ipInfo.AddressList[0];
            IPEndPoint local = new IPEndPoint(ipAddr, 9002);

            Console.WriteLine("Listening on port 9002");
            //data buffer from clients
            byte[] bytes = new Byte[1024];

            //create TCP socket
            Socket listener = new Socket(AddressFamily.InterNetwork, SocketType.Stream,
                ProtocolType.Tcp);
            try
            {
                listener.Bind(local);
                listener.Listen(10); // 10 incoming connections allowed.

                while (true)
                {
                    Socket incomingData = listener.Accept();
                    data = null;

                    // proccess the incoming data
                    while (true)
                    {
                        Console.WriteLine("Incoming connection detected");
                        bytes = new Byte[1024];
                        int incomingBytes = incomingData.Receive(bytes);
                        data += Encoding.UTF8.GetString(bytes, 0, incomingBytes);
                        if (data.IndexOf("\n") > -1)
                        {
                            break;
                        }

                    }
                    handleData(data, ref incomingData); // pass socket by reference, as to not create a new one.
                }


            }
            catch (Exception e)
            {
                Console.WriteLine("Sorry an error occured: {0}", e.Message);
            }
        }

        /// <summary>
        /// Does not partake in any error handling whatsoever.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="dataHandler"></param>
        public static void handleData(string data, ref Socket dataHandler)
        {
            string[] dataArray = data.Split(',');
            if (dataArray[0].Equals("update"))
            {
                string stockName = dataArray[1];
                float stockPrice = float.Parse(dataArray[2]);
                stockPrices[stockName] = stockPrice;
                string message = String.Format("Stock name: {0} updated to {1}", stockName, stockPrice);
                dataHandler.Send(Encoding.UTF8.GetBytes(message), message.Length, SocketFlags.None);
            }
            if (dataArray[0].Equals("request"))
            {
                string stockName = dataArray[1];
                stockName = stockName.Substring(0, stockName.Length - 1);
                float price = stockPrices[stockName];
                string message = String.Format("Stock name: {0}, price is: {1}", stockName, price);
                dataHandler.Send(Encoding.UTF8.GetBytes(message));
            }
        }
    }
}
