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
                        Command cmd = GetCommand();
                        if (cmd == null)
                            break;  //exit client
                        
                        cmd.WriteInto(stream);

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

        private static int debugCounter = 1;
        static private Command GetCommand()
        {
            int id = Command.ID_ERROR;
            string stockname = "MSFT";
            double price = 100.01;
            int amount = 500;

            switch(debugCounter)
            {
                case 1:
                    id = Command.ID_QUERRY;
                    debugCounter++;
                    break;
                case 2:
                    id = Command.ID_SELL;
                    debugCounter++;
                    break;
                case 3:
                    id = Command.ID_BUY;
                    debugCounter++;
                    break;
                case 4:
                    id = Command.ID_INFO;
                    debugCounter++;
                    break;
                case 5:
                    id = Command.ID_ERROR;
                    debugCounter++;
                    break;
            }
            if (Command.ID_ERROR == id)
            {
                return null;
            }
            else
            {
                Command cmd = new Command(id, clientname, stockname, price, amount);
                return cmd;
            }
        }

        static private void ShowServerMessage(NetworkStream fromStream)
        {
            byte[] message = new byte[1024];
            int len = fromStream.Read(message, 0, message.Length);
            message[len] = 0x00;
            string msg = System.Text.Encoding.UTF8.GetString(message);
            Console.WriteLine("Message: {0}", msg);
        }

        static private int getInt()
        {
            return 10;
        }

        static private string getString()
        {
            return "ABC";
        }

        static void Main(string[] args)
        {
            StartClient(null, 11000);
        }
    }
}
