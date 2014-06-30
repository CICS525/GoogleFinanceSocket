using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Collections;
using System.Net;
using System.Net.Sockets;
using StockCommand;

namespace StockServer
{
    class StockServerMain
    {
        private const int SERVER_LISTEN_PORT = 11000;
        static private StockListManager stockListManager = StockListManager.getStockListManager(); //new StockListManager();

        static public StockListManager getStockListManager()
        {
            return stockListManager;
        }
        static private void RefreshStockListThread()
        {
            try
            {
                while (true)    //infnite loop in background to update stock list
                {
                    //get system time now
                    Console.WriteLine("RefreshStockListThread(): ...");
                    stockListManager.Update();

                    //get system time again
                    Thread.Sleep(2 * 60 * 1000);
                }
            }
            catch (Exception ex)
            {
                // log errors
            }
        }

        static private void WaitClientThread()
        {
            IPHostEntry ipHostInfo = Dns.Resolve(Dns.GetHostName());
            IPAddress ipAddress = ipHostInfo.AddressList[0];
            IPEndPoint localEndPoint = new IPEndPoint(ipAddress, SERVER_LISTEN_PORT);

            // Create a TCP/IP socket.
            Socket listener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            try
            {
                listener.Bind(localEndPoint);
                listener.Listen(10);

                while (true)     //infnite loop in background to answer incoming client session
                {
                    Console.WriteLine("WaitClientThread(): ...");
                    //answer the client in a new thread, so this thread can continue to next incoming client
                    Socket handler = listener.Accept();

                    Thread tClient = new Thread(AnswerClientThread);
                    tClient.Start(handler);
                }
            }
            catch (Exception ex)
            {
                // log errors
            }
        }

        static private void AnswerClientThread(Object para)
        {
            Socket handler = (Socket)para;
            try
            {
                NetworkStream stream = new NetworkStream(handler);

                while (stream.CanRead)     //need to handle network close (stream.CanRead && stream.DataAvailable)
                {
                    Client client = null;

                    byte[] buff = new byte[1024];
                    int len = stream.Read(buff, 0, buff.Length);
                    if (len <= 0)
                        break;

                    string str = System.Text.Encoding.UTF8.GetString(buff);
                    Command cmd = Command.DeserializeFromString(str);
                    //Command cmd = Command.ReadFrom(stream);
                    if (cmd == null)
                        break;  //nothing to do for error

                    Console.WriteLine("{0}: Get Command {1};{2};{3}", cmd.clientname, cmd.id, cmd.stockname, cmd.amount);
                    bool suc = false;
                    string message = null;
                    switch (cmd.id)
                    {
                        case Command.ID_QUERY:
                            cmd.price = stockListManager.Query(cmd.stockname);
                            if (cmd.price > 0)
                                message = string.Format("The recent price of {0} is {1}", cmd.stockname, cmd.price);
                            else
                                message = string.Format("Price not available for {0}", cmd.stockname);
                            break;
                        case Command.ID_BUY:
                            client = new Client(cmd.clientname);
                            suc = client.Buy(cmd.stockname, cmd.amount);
                            if (suc)
                                message = string.Format("Successfuly bought {0} of {1}", cmd.amount, cmd.stockname);
                            else
                                message = string.Format("Can not buy {0} of {1}", cmd.amount, cmd.stockname);
                            break;
                        case Command.ID_SELL:
                            client = new Client(cmd.clientname);
                            suc = client.Sell(cmd.stockname, cmd.amount);
                            if (suc)
                                message = string.Format("Successfuly selled {0} of {1}", cmd.amount, cmd.stockname);
                            else
                                message = string.Format("Can not sell {0} of {1}", cmd.amount, cmd.stockname);
                            break;
                        case Command.ID_INFO:
                            client = new Client(cmd.clientname);
                            message = client.ListClientInfo();
                            break;
                        default:
                            message = string.Format("Unknow command: ID={0}", cmd.id);
                            break;
                    }

                    Console.WriteLine(message);
                    byte[] b = Encoding.ASCII.GetBytes(message);
                    stream.Write(b, 0, message.Length);
                    Thread.Sleep(10);   //delay a little while then continue for next loop
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            //network is closed, do some clean up
        }

        static void test()
        {
            Client client = new Client("Tom");                  //should check if the local file is loaded correctly.
            StockListManager stocks = StockListManager.getStockListManager();   //should check if the local file is loaded correctly.

            stocks.Query("MSFT");
            stocks.Query("MSFT");      //next time querry same stock should not connect server again.
            stocks.Update();

            bool sucS = client.Sell("MSFT", 5);
            bool sucB = client.Buy("MSFT", 10);
            string msg = client.ListClientInfo();
            Console.WriteLine(msg);
        }

        static void Main(string[] args)
        {
            //test();  //<-- Please use this to test APIs, by Eli

            //create thread for refresh stock list
            Thread tRefresh = new Thread(RefreshStockListThread);
            tRefresh.Start();

            //create thread for answer client
            Thread tAnswer = new Thread(WaitClientThread);
            tAnswer.Start();

            Console.ReadLine();
            //tRefresh.Join();
            //tAnswer.Join();
            tRefresh.Abort();
            tAnswer.Abort();
        }
    }
}
