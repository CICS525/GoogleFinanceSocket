using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Net;
using System.Net.Sockets;
using StockCommand;

namespace Client
{
    class Program
    {
        private static string clientname;
        public static void StartClient(string hostname, int port)
        {
            // Data buffer for incoming data.
            byte[] bytes = new byte[1024];

            Console.WriteLine("Input Client Username:");
            clientname = getString();

            if(hostname==null)
            {
                hostname = Dns.GetHostName();
            }

            // Connect to a remote device.
            try
            {
                // Establish the remote endpoint for the socket.
                IPHostEntry ipHostInfo = Dns.Resolve(hostname);
                IPAddress ipAddress = ipHostInfo.AddressList[0];
                IPEndPoint remoteEP = new IPEndPoint(ipAddress, port);

                // Create a TCP/IP  socket.
                Socket sender = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                // Connect the socket to the remote endpoint. Catch any errors.
                try
                {
                    sender.Connect(remoteEP);
                    
                    Console.WriteLine("Socket connected to {0}", sender.RemoteEndPoint.ToString());

                    NetworkStream stream = new NetworkStream(sender);

                    while(true)
                    {
                        Console.WriteLine("----------------------------------------");

                        Command cmd = GetCommand();
                        if (cmd == null)
                            break;  //exit client
                        
                        //cmd.WriteInto(stream);
                        string buff = Command.SerializeToString(cmd);
                        SendCommand(stream, buff);

                        Thread.Sleep(10); 

                        ShowServerMessage(stream);
                    }

                    // Release the socket.
                    sender.Shutdown(SocketShutdown.Both);
                    sender.Close();
                }
                catch (ArgumentNullException ane)
                {
                    Console.WriteLine("ArgumentNullException : {0}", ane.ToString());
                }
                catch (SocketException se)
                {
                    Console.WriteLine("SocketException : {0}", se.ToString());
                }
                catch (Exception e)
                {
                    Console.WriteLine("Unexpected exception : {0}", e.ToString());
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        //private static int debugCounter = 0;
        static private Command GetCommand()
        {
            Console.WriteLine("Select: \r\n {0}:Query \r\n {1}:Buy \r\n {2}:Sell \r\n {3}:Info \r\n Others Quit", Command.ID_QUERY, Command.ID_BUY, Command.ID_SELL, Command.ID_INFO);
            int id = getInt();
            string stockname = "";
            double price = 0.0;
            int amount = 0;

            //switch(debugCounter)
            //{
            //    case 1:
            //        id = Command.ID_QUERY;
            //        debugCounter++;
            //        break;
            //    case 2:
            //        id = Command.ID_SELL;
            //        debugCounter++;
            //        break;
            //    case 3:
            //        id = Command.ID_BUY;
            //        debugCounter++;
            //        break;
            //    case 4:
            //        id = Command.ID_INFO;
            //        debugCounter++;
            //        break;
            //    case 5:
            //        id = Command.ID_ERROR;
            //        debugCounter++;
            //        break;
            //}

            if (id < Command.ID_QUERY || id > Command.ID_INFO)
            {
                return null;
            }
            else
            {
                Console.WriteLine("Stock name:");
                stockname = getString();

                if(id==Command.ID_BUY || id==Command.ID_SELL)
                {
                    Console.WriteLine("Amount:");
                    amount = getInt();
                }

                Command cmd = new Command(id, clientname, stockname, price, amount);
                return cmd;
            }
        }

        static  private void SendCommand(NetworkStream toStream, string cmdstr)
        {
            byte[] buff = System.Text.Encoding.ASCII.GetBytes(cmdstr);
            int len = cmdstr.Length;
            toStream.Write(buff, 0, len);
        }

        static private void ShowServerMessage(NetworkStream fromStream)
        {
            byte[] buff = new byte[1024];
            int len = fromStream.Read(buff, 0, buff.Length);
            byte[] message = buff.Take(len).ToArray();
            string msg = System.Text.Encoding.UTF8.GetString(message);
            Console.WriteLine("Server Return Message: {0}", msg);
        }

        static private int getInt()
        {
            while (true)
            {
                string ln = Console.ReadLine();
                if (ln.Length > 0)
                {
                    int i = Convert.ToInt32(ln);
                    return i;
                }
            }
        }

        static private string getString()
        {
            while(true)
            {
                string ln = Console.ReadLine();
                if (ln.Length > 0)
                {
                    return ln;
                }
            }
        }

        static void Main(string[] args)
        {
            //int id = Command.ID_ERROR;
            //string stockname = "MSFT";
            //double price = 100.01;
            //int amount = 500;
            //Command cmd = new Command(id, "clientname", stockname, price, amount);
            //string xml = Command.SerializeToString(cmd);
            //Command cmd2 = Command.DeserializeFromString(xml);

            StartClient(null, 11000);
        }
    }
}
