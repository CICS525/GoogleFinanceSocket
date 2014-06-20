using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Collections;

//////////////////////////////////////////////////////////////////////////////////////
///  This Command define & implement should be shared by both server & client      ///
//////////////////////////////////////////////////////////////////////////////////////


namespace StockServer
{
    class Command
    {
        static public const int ID_ERROR = 0;
        static public const int ID_QUERRY = 1;
        static public const int ID_BUY = 2;
        static public const int ID_SELL = 3;

        public int id;
        public int stockname;
        public double price;
        public double amount;
        //to be added...

        public Command(string data)
        {
            ParseCommand(data);
        }
        public Command(int id, int stockname, double price, double amount)
        {
            this.id = id;
            this.stockname = stockname;
            this.price = price;
            this.amount = amount;
        }
        static private void ParseCommand(string data) //get info from a string to class member variables
        {
        }
        static private string CreateCommand()   //create a command string from class member variables
        {
            return "to do";
        }
    }
}