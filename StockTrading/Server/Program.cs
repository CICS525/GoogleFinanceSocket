using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Collections;


namespace StockServer
{
    class Program
    {
        static private void RefreshStockListThread()
        {
            try
            {
                // do any background work
                while (true)
                {
                    Console.WriteLine("RefreshStockListThread(): ...");
                    Thread.Sleep(5 * 1000);
                }
            }
            catch (Exception ex)
            {
                // log errors
            }
        }

        static private void AnswerClientThread()
        {
            try
            {
                // do any background work
                while(true)
                {
                    Console.WriteLine("AnswerClientThread(): ...");
                    Thread.Sleep(3 * 1000);
                }
            }
            catch (Exception ex)
            {
                // log errors
            }
        }

        static void Main(string[] args)
        {
            //create thread for refresh stock list
            Thread tRefresh = new Thread(RefreshStockListThread);
            tRefresh.Start();

            //create thread for answer client
            Thread tAnswer = new Thread(AnswerClientThread);
            tAnswer.Start();

            Console.ReadLine();
            //tRefresh.Join();
            //tAnswer.Join();
            tRefresh.Abort();
            tAnswer.Abort();
        }
    }
}
