using System.Runtime.Serialization.Formatters.Soap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Xml.Serialization;

namespace lr_13
{
    public interface ISerializer
    {
        void Serialize<T>(T obj, string filePath);
        T Deserialize<T>(string filePath);
    }
    public class BinarySerializer : ISerializer
    {
        BinaryFormatter formatter = new BinaryFormatter();
        public void Serialize<T>(T obj, string filePath)
        {
            using (FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.ReadWrite))
            {
                if (fs.Length != 0)
                {
                    fs.SetLength(0);
                }
                formatter.Serialize(fs, obj);
            }
            Console.WriteLine("Объект сериализован в dat файл");
        }

        public T Deserialize<T>(string filePath)
        {
            using (FileStream fs = new FileStream(filePath, FileMode.Open))
            {
                var res = (T)formatter.Deserialize(fs);
                Console.WriteLine("Объект десериализован из файла dat");
                return res;
            }
        }
    }
    public class SOAPSerializer : ISerializer
    {
        SoapFormatter formatter = new SoapFormatter();
        public void Serialize<T>(T obj, string filePath)
        {
            using (FileStream fs = new FileStream(filePath, FileMode.Create))
            {
                formatter.Serialize(fs, obj);
            }
            Console.WriteLine("Объект сериализован в soap файл");
        }

        public T Deserialize<T>(string filePath)
        {
            using (FileStream fs = new FileStream(filePath, FileMode.Open))
            {
                var res = (T)formatter.Deserialize(fs);
                Console.WriteLine("Объект десериализован из файла soap");
                return res;
            }
        }
    }
    public class JSONSerializer : ISerializer
    {
        public void Serialize<T>(T obj, string filePath)
        {
            using (FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.ReadWrite))
            {
                if (fs.Length != 0)
                {
                    fs.SetLength(0);
                }
                JsonSerializer.Serialize(fs, obj);
                Console.WriteLine("Объект сериализован в json файл");
            }
        }

        public T Deserialize<T>(string filePath)
        {
            using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            using (StreamReader sr = new StreamReader(fs))
            {
                string jsonString = sr.ReadToEnd();
                var res = JsonSerializer.Deserialize<T>(jsonString);
                Console.WriteLine("Объект десериализован из файла json");
                return res;
            }
        }
    }
    public class XMLSerializer<T> : ISerializer
    {
        XmlSerializer serializer = new XmlSerializer(typeof(T));
        public void Serialize<T>(T obj, string filePath)
        {
            using (FileStream fs = new FileStream(filePath, FileMode.Create))
            {
                serializer.Serialize(fs, obj);
                Console.WriteLine("Объект сериализован в xml файл");
            }
        }

        public T Deserialize<T>(string filePath)
        {
            using (FileStream fs = new FileStream(filePath, FileMode.Open))
            {
                var res = (T)serializer.Deserialize(fs);
                Console.WriteLine("Объект десериализован из файла xml");
                return res;
            }
        }
    }

}
