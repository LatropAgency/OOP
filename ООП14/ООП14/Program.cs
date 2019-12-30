using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;
using System.Xml.XPath;
using System.Xml;
using System.Xml.Serialization;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Linq;
using System.Xml.Linq;

namespace ООП14
{
    public class Program
    {
        static void Main(string[] args)
        {
            Engine eng1 = new Engine(100);
            Engine eng2 = new Engine(200);
            Engine[] eng = new Engine[] { eng1, eng2 };
            ArrayList en = new ArrayList();
            en.Add(eng1);
            en.Add(eng2);
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream("data.dat", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, eng);
                Console.WriteLine("Объект сериализован");
            }
            using (FileStream fs = new FileStream("data.dat", FileMode.OpenOrCreate))
            {
                Engine[] deserilizeEngine = (Engine[])formatter.Deserialize(fs);

                foreach (Engine p in deserilizeEngine)
                {
                    Console.WriteLine($"Мощность: {p.Power} --- Статус: {p.Status}");
                }
            }
            SoapFormatter sformatter = new SoapFormatter();
            using (FileStream fs = new FileStream("data.soap", FileMode.OpenOrCreate))
            {
                sformatter.Serialize(fs, eng);
                Console.WriteLine("Объект сериализован");
            }
            using (FileStream fs = new FileStream("data.soap", FileMode.OpenOrCreate))
            {
                Engine[] deserilizeEngine = (Engine[])sformatter.Deserialize(fs);

                foreach (Engine p in deserilizeEngine)
                {
                    Console.WriteLine($"Мощность: {p.Power} --- Статус: {p.Status}");
                }
            }
            XmlSerializer xSer = new XmlSerializer(typeof(Engine[]));
            using (FileStream fs = new FileStream("data1.xml", FileMode.OpenOrCreate))
            {
                xSer.Serialize(fs, eng);
                Console.WriteLine("Объект сериализован");
            }
            using (FileStream fs = new FileStream("data1.xml", FileMode.OpenOrCreate))
            {
                Engine[] newP = xSer.Deserialize(fs) as Engine[];
                foreach (Engine p in newP)
                {
                    Console.WriteLine($"Мощность: {p.Power} --- Статус: {p.Status}");
                }
            }
            string json = JsonConvert.SerializeObject(eng);
            Console.WriteLine("Объект сериализован");
            Engine[] js = JsonConvert.DeserializeObject<Engine[]>(json);
            foreach (Engine p in js)
            {
                Console.WriteLine($"Мощность: {p.Power} --- Статус: {p.Status}");
            }
            using (FileStream fs = new FileStream("data.dat", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, en);
                Console.WriteLine("Объект сериализован");
            }
            using (FileStream fs = new FileStream("data.dat", FileMode.OpenOrCreate))
            {
                ArrayList e = new ArrayList();
                e = (ArrayList)formatter.Deserialize(fs);
                foreach (Engine p in e)
                {
                    Console.WriteLine($"Мощность: {p.Power} --- Статус: {p.Status}");
                }
            }
            using (FileStream fs = new FileStream("data.soap", FileMode.OpenOrCreate))
            {
                sformatter.Serialize(fs, en);
                Console.WriteLine("Объект сериализован");
            }
            using (FileStream fs = new FileStream("data.soap", FileMode.OpenOrCreate))
            {
                ArrayList e = new ArrayList();
                e = (ArrayList)sformatter.Deserialize(fs);
                foreach (Engine p in e)
                {
                    Console.WriteLine($"Мощность: {p.Power} --- Статус: {p.Status}");
                }
            }
            List<Engine> a = new List<Engine>();
            a.Add(eng1);
            a.Add(eng2);
            XmlSerializer Xm = new XmlSerializer(typeof(List<Engine>));
            using (FileStream fs = new FileStream("data1.xml", FileMode.OpenOrCreate))
            {
                Xm.Serialize(fs, a);
                Console.WriteLine("Объект сериализован");
            }
            using (FileStream fs = new FileStream("data1.xml", FileMode.OpenOrCreate))
            {
                List<Engine> e = new List<Engine>();
                e = (List<Engine>)Xm.Deserialize(fs);
                foreach (Engine p in e)
                {
                    Console.WriteLine($"Мощность: {p.Power} --- Статус: {p.Status}");
                }
            }
            string ListJson = JsonConvert.SerializeObject(a);
            List<Engine> b = new List<Engine>() { eng1, eng2 };
            b = JsonConvert.DeserializeObject<List<Engine>>(ListJson);
            foreach (Engine p in b)
            {
                Console.WriteLine($"Мощность: {p.Power} --- Статус: {p.Status}");
            }
            using (FileStream fs = new FileStream("data2.xml", FileMode.OpenOrCreate))
            {
                xSer.Serialize(fs, eng);
            }
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load("data2.xml");
            XmlElement xRoot = xDoc.DocumentElement;
            XmlNodeList childnodes = xRoot.SelectNodes("*");
            foreach (XmlNode n in childnodes)
                Console.WriteLine(n.OuterXml);
            XmlNodeList nodes = xRoot.SelectNodes("Engine");
            foreach (XmlNode n in nodes)
            {
                XmlNodeList nnn = n.SelectNodes("Power");
                foreach (XmlNode c in nnn)
                {
                    Console.WriteLine("Power: " + c.InnerText);
                }
                XmlNodeList nn = n.SelectNodes("Status");
                foreach (XmlNode c in nn)
                {
                    Console.WriteLine("Status: " + c.InnerText);
                }
            }
            XDocument doc = new XDocument();
            XElement user = new XElement("user");
            XElement user2 = new XElement("user");
            XAttribute userName = new XAttribute("name", "vova");
            XAttribute userName2 = new XAttribute("name", "gena");
            XElement userPass = new XElement("pass", "null");
            XElement userPass2 = new XElement("pass", "1234");
            user.Add(userName);
            user.Add(userPass);
            user2.Add(userName2);
            user2.Add(userPass2);
            XElement users = new XElement("city");
            XName xn;
            users.Add(user);
            users.Add(user2);
            doc.Add(users);
            doc.Save("linq.xml");
            XDocument xdoc = XDocument.Load("linq.xml");
            var res = from xe in xdoc.Element("city").Elements("user")
                      select new Engine
                      {
                          name = xe.Attribute("name").Value
                      };
            foreach (Engine k in res)
                Console.WriteLine(k.name);
            Console.ReadKey();
        }
    }
}
