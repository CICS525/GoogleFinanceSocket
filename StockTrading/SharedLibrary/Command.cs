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
using System.Xml.Serialization;

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
        public const int ID_QUERY = 1;
        public const int ID_BUY = 2;
        public const int ID_SELL = 3;
        public const int ID_INFO = 4;
        public const int ID_QUIT = 5;

        public const int ID_MIN = 1;
        public const int ID_MAX = 5;

        public int id;
        public string clientname;
        public string stockname;
        public double price;
        public int amount;
        //to be added...

        public Command()
        {
        }
        public Command(int id, string clientname, string stockname, double price, int amount)
        {
            this.id = id;
            this.clientname = clientname;
            this.stockname = stockname;
            this.price = price;
            this.amount = amount;
        }
        //public void WriteInto(Stream stream)
        //{
        //    BinaryFormatter b = new BinaryFormatter();
        //    b.Serialize(stream, this);
        //}
        //static public Command ReadFrom(Stream stream)
        //{
        //    BinaryFormatter b = new BinaryFormatter();
        //    Command c = (Command)b.Deserialize(stream);
        //    return c;
        //}
        static public void test(Command cmd)
        {
            MemoryStream s = new MemoryStream();
            BinaryFormatter b = new BinaryFormatter();
            b.Serialize(s, cmd);

            s.Seek(0, SeekOrigin.Begin);

            BinaryFormatter b2 = new BinaryFormatter();
            Command c = (Command)b2.Deserialize(s);
        }
        public static string SerializeToString(Command cmd)
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(Command));
                using (StringWriter writer = new StringWriter())
                {
                    serializer.Serialize(writer, cmd);
                    return writer.ToString();
                }
            }
            catch (Exception e) { }
            return null;
        }
        public static Command DeserializeFromString(string str)
        {
            try
            {
                var serializer = new XmlSerializer(typeof(Command));
                Command result;
                using (TextReader reader = new StringReader(str))
                {
                    result = (Command)serializer.Deserialize(reader);
                }
                return result;
            }
            catch (Exception e) { }
            return null;
        }
    }
}