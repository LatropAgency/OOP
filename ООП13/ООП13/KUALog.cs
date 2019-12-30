using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace ООП13
{
    static class KUALog
    {
        public static StreamWriter CreateStream(string s)
        {
            StreamWriter sw = new StreamWriter(s);
            return sw;
        }
        public static void KUAWriter(StreamWriter sw, string info)
        {
            sw.WriteLine(DateTime.Now.Hour + ":" + DateTime.Now.Minute + ":" + DateTime.Now.Day + ":" + DateTime.Now.Month + ":" + DateTime.Now.Year + " ");
            sw.WriteLine(info);
        }
        public static void CloseStream(StreamWriter sw)
        {
            sw.Close();
        }
        public static string KUAReader(StreamReader sr)
        {
            return sr.ReadToEnd();
        }
        public static void KUASearcher(StreamReader sr, string info)
        {
            string text = KUAReader(sr);
            if (text.Contains(info))
            {
                Console.WriteLine("Да, содержит");
            }
            else
            {
                Console.WriteLine("Нет, не содержит");
            }

        }
    }
}
