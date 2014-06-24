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
        static private StockListManager stockListManager = new StockListManager();

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

                while (stream.CanRead && stream.DataAvailable)     //need to handle network close
                {
                    Command cmd = Command.ReadFrom(stream);
                    switch(cmd.id)
                    {
                        case Command.ID_QUERRY:
                            break;
                        case Command.ID_BUY:
                            break;
                        case Command.ID_SELL:
                            break;
                        default:
                            break;
                    }

                    string message = "OK";
                    byte[] b = Encoding.ASCII.GetBytes(message);
                    stream.Write(b, 0, message.Length);
                    Thread.Sleep(1000);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            //network is closed, do some clean up
        }

        static void Main(string[] args)
        {
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
