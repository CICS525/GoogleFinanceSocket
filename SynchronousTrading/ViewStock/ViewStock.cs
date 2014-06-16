using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;


namespace Stocks
{
    class UpdateStock
    {
        static void Main(string[] args)
        {
            startClient();
        }

        public static void startClient()
        {
            while (true)
            {
                try
                {
                    byte[] bytes = new Byte[1024];
                    IPHostEntry ipHostInfo = Dns.Resolve(Dns.GetHostName());
                    IPAddress addr = ipHostInfo.AddressList[0];
                    IPEndPoint local = new IPEndPoint(addr, 9002);

                    //create the socket.
                    Socket sender = new Socket(AddressFamily.InterNetwork, SocketType.Stream,
                        ProtocolType.Tcp);

                    sender.Connect(local);

                    Console.WriteLine("Enter the name of a stock: ");
                    string stockName = Console.ReadLine();
                    
                    string message = String.Format("request,{0}\n", stockName);
                    sender.Send(Encoding.UTF8.GetBytes(message));

                    int bytesRec = sender.Receive(bytes);
                    Console.WriteLine(Encoding.UTF8.GetString(bytes, 0, bytesRec));
                }
                catch (Exception e)
                {
                    Console.WriteLine("Sorry, an error has occured: {0}", e.Message);
                }
            }
        }
    }
}
