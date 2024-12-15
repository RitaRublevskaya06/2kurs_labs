using System;
using System.Xml;
using System.Xml.Linq;
using lr_13;
using static System.Console;
internal class Program
{
    private static void Main(string[] args)
    {
        List<Film> films = new List<Film>
        {
            new Film(),
            new Film()
        };
        films[0].Time = 100;
        films[1].Time = 200;
        films[0].Name = "Фильм 1";
        films[1].Name = "Фильм 2";

        string datFilePath = @"D:\Univer\2 kurs\OOP\ConsoleApp5\ConsoleApp5\res\film.dat";
        string jsonFilePath = @"D:\Univer\2 kurs\OOP\ConsoleApp5\ConsoleApp5\res\film.json";
        string xmlFilePath = @"D:\Univer\2 kurs\OOP\ConsoleApp5\ConsoleApp5\res\film.xml";
        string soapFilePath = @"D:\Univer\2 kurs\OOP\ConsoleApp5\ConsoleApp5\res\film.soap";

        foreach (var t in films)
        {
            WriteLine(t.Name + " " + t.Time + " " + t.Year);
        }
        BinarySerializer serializerDat = new BinarySerializer();
        serializerDat.Serialize(films, datFilePath);
        var deserOfFilmsDat = serializerDat.Deserialize<List<Film>>(datFilePath);

        foreach (var t in deserOfFilmsDat)
        {
            WriteLine(t.Name + " " + t.Time + " " + t.Year);
        }

        SOAPSerializer soapSerializer = new();
        soapSerializer.Serialize(films.ToArray(), soapFilePath);
        var resSoap = soapSerializer.Deserialize<Film[]>(soapFilePath);
        foreach (var item in resSoap)
        {
            WriteLine(item.Name + " " + item.Time + " " + item.Year);
        }

        JSONSerializer jSONSerializer = new JSONSerializer();
        jSONSerializer.Serialize(films, jsonFilePath);
        var deserializedFilmsJson = jSONSerializer.Deserialize<List<Film>>(jsonFilePath);
        foreach (var t in deserializedFilmsJson)
        {
            WriteLine(t.Name + " " + t.Time + " " + t.Year);
        }


        XMLSerializer<Film[]> xmlSerializer = new XMLSerializer<Film[]>();
        xmlSerializer.Serialize(films.ToArray(), xmlFilePath);
        var resXml = xmlSerializer.Deserialize<Film[]>(xmlFilePath);
        foreach (var item in resXml)
        {
            WriteLine(item.Name + " " + item.Time + " " + item.Year);
        }

        WriteLine("\nLINQ to XML");

        XDocument root = new XDocument(
            new XElement("Tree",

                new XElement("NewNode",
                    new XAttribute("name", "Node"),
                    new XAttribute("newAtr", "1")),

                new XElement("NewNode",
                    new XAttribute("name", "Node2"),
                    new XAttribute("newAtr", "2"))
        )
        );

        root.Save(@"D:\Univer\2 kurs\OOP\ConsoleApp5\ConsoleApp5\res\newFilms.xml");


        var res = from film in root.Element("Tree").Elements("NewNode")
                  where (string)film.Attribute("name") == "Node"
                  select film;

        foreach (var film in res)
        {
            WriteLine(film);
        }

        XmlDocument doc = new XmlDocument();
        doc.Load(@"D:\Univer\2 kurs\OOP\ConsoleApp5\ConsoleApp5\res\newFilms.xml");

        XmlElement? Xroot = doc.DocumentElement;
        XmlNodeList? allNodes = Xroot?.SelectNodes("NewNode");

        WriteLine("\nВсе имена узлов");
        foreach (XmlNode item in allNodes)
        {
            WriteLine(item.SelectSingleNode("@name").Value);
        }

        var node = Xroot?.SelectSingleNode("NewNode[@newAtr='2']");

        WriteLine("\nУзел с атрибутом newAtr='2'");
        WriteLine(node.OuterXml);
    }
}