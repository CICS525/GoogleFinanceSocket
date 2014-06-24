using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using StockCommand;

namespace Client
{
    class Program
    {
        private static string name;
        public static void StartClient(string hostname, int port)
        {
            // Data buffer for incoming data.
            byte[] bytes = new byte[1024];

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
                    byte[] message = new byte[1024];

                    while(true)
                    {
                        int id = Command.ID_ERROR;
                        string stockname = "MSFT";
                        double price = 100.01;
                        double amount = 500;

                        Command cmd = new Command(id, stockname, price, amount);
                        cmd.WriteInto(stream);

                        int len = stream.Read(message, 0, message.Length);
                        message[len] = 0x00;
                        string msg = System.Text.Encoding.UTF8.GetString(message);
                        Console.WriteLine("Message: {0}", msg);
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

        static void Main(string[] args)
        {
            StartClient(null, 11000);
        }
    }
}
