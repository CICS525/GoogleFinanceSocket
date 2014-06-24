using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Collections;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

//////////////////////////////////////////////////////////////////////////////////////
///  This Command define & implement should be shared by both server & client      ///
//////////////////////////////////////////////////////////////////////////////////////


//namespace StockServer
namespace StockCommand
{
    [Serializable]
    public class Command
    {
        public const int ID_ERROR = -1;
        public const int ID_QUERRY = 1;
        public const int ID_BUY = 2;
        public const int ID_SELL = 3;

        public int id;
        public string stockname;
        public double price;
        public double amount;
        //to be added...

        //public Command(string data)
        //{
        //    Deserialize(data);
        //}
        public Command(int id, string stockname, double price, double amount)
        {
            this.id = id;
            this.stockname = stockname;
            this.price = price;
            this.amount = amount;
        }
        //public string Serialize()
        //{
        //    return Serialize(this);
        //}

        //static private void ParseCommand(string data) //get info from a string to class member variables
        //{
        //}
        //static private string CreateCommand()   //create a command string from class member variables
        //{
        //    return "to do";
        //}
        public void WriteInto(Stream stream)
        {
            BinaryFormatter b = new BinaryFormatter();
            b.Serialize(stream, this);
        }
        static public Command ReadFrom(Stream stream)
        {
            BinaryFormatter b = new BinaryFormatter();
            Command c = (Command)b.Deserialize(stream);
            return c;
        }
        static public void test(Command cmd)
        {
            MemoryStream s = new MemoryStream();
            BinaryFormatter b = new BinaryFormatter();
            b.Serialize(s, cmd);

            s.Seek(0, SeekOrigin.Begin);

            BinaryFormatter b2 = new BinaryFormatter();
            Command c = (Command)b2.Deserialize(s);
        }
        //static public string Serialize(Command command)
        //{
        //    MemoryStream s = new MemoryStream();
        //    BinaryFormatter b = new BinaryFormatter();
        //    b.Serialize(s, command);
        //    s.Seek(0, SeekOrigin.Begin);
        //    StreamReader sr = new StreamReader(s);
        //    string str = sr.ReadToEnd();
        //    s.Close();
        //    return str;
        //}
        //static public Command Deserialize(string str)
        //{
        //    MemoryStream s = new MemoryStream();
        //    StreamWriter sw = new StreamWriter(s);
        //    sw.Write(str);
        //    sw.Flush();
        //    BinaryFormatter b = new BinaryFormatter();
        //    Command c = (Command)b.Deserialize(s);
        //    s.Close();
        //    return c;
        //}
        //static public string Serialize(Command command)
        //{
        //    //return "abc";
        //    DataContractSerializer serializer = new DataContractSerializer(typeof(Command));
        //    return serializer.ToString();
        //}
        //static public Command Deserialize(string str)
        //{
        //    //return null;
        //    DataContractSerializer serializer = new DataContractSerializer(typeof(Command));
        //    MemoryStream stream = new MemoryStream();
        //    StreamWriter writer = new StreamWriter(stream);
        //    writer.Write(str);
        //    writer.Flush();
        //    stream.Seek(0, SeekOrigin.Begin);
        //    object obj = serializer.ReadObject(stream);
        //    return (Command)obj;
        //}
    }
}