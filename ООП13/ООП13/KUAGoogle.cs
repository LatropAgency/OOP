using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace ООП13
{
    static class KUAGoogle
    {
        public static void SearchHour(StreamReader sr)
        {
            int h = DateTime.Now.Hour;
            int m = DateTime.Now.Minute;
            int tmph, tmpm;
            string str, tmp = "";
            int i = 0, k = 0;
            while (!sr.EndOfStream)
            {
                i = 0;
                k++;
                str = sr.ReadLine();
                while (str[i] != ':')
                {
                    tmp += str[i];
                    i++;
                }
                i++;
                tmph = Convert.ToInt32(tmp);
                tmp = "";
                for (int j = i; str[j] != ':'; j++)
                {
                    tmp += str[j];
                }
                tmpm = Convert.ToInt32(tmp);
                tmp = "";
                if (h * 60 + m - tmph * 60 - tmpm < 60)
                {
                    str = sr.ReadLine();
                    Console.WriteLine(str);
                }
                else
                    str = sr.ReadLine();
            }
            Console.WriteLine(k + " записей");
        }
        public static void SearcherOblastb(StreamReader sr, int n1, int n2)
        {
            int tmph, tmpm;
            string str, tmp = "";
            int i = 0, k = 0;
            while (!sr.EndOfStream)
            {
                i = 0;
                k++;
                str = sr.ReadLine();
                while (str[i] != ':')
                {
                    tmp += str[i];
                    i++;
                }
                i++;
                tmph = Convert.ToInt32(tmp);
                tmp = "";
                if (tmph < n2 && tmph > n1)
                {
                    str = sr.ReadLine();
                    Console.WriteLine(str);
                }
                else
                    str = sr.ReadLine();
            }
            Console.WriteLine(k + " записей");
        }
        public static void SearcherDate(StreamReader sr, int day, int month)
        {
            int tmpd, tmpm;
            string str, tmp = "";
            int i = 0, k = 0, m = 0;

            while (!sr.EndOfStream)
            {
                m = 0;
                i = 0;
                k++;
                str = sr.ReadLine();
                while (m < 2)
                {
                    if (str[i] == ':')
                    {
                        m++;
                    }
                    i++;
                }
                while (str[i] != ':')
                {
                    tmp += str[i];
                    i++;
                }
                i++;
                tmpd = Convert.ToInt32(tmp);
                tmp = "";
                for (int j = i; str[j] != ':'; j++)
                {
                    tmp += str[j];
                }
                tmpm = Convert.ToInt32(tmp);
                tmp = "";
                if (day == tmpd && month == tmpm)
                {
                    str = sr.ReadLine();
                    Console.WriteLine(str);
                }
                else
                    str = sr.ReadLine();
            }
            Console.WriteLine(k + " записей");
        }
        public static void SearcherWord(StreamReader sr, string word)
        {
            string tmp;
            while (!sr.EndOfStream)
            {
                sr.ReadLine();
                tmp = sr.ReadLine();
                if (tmp.Contains(word))
                {
                    Console.WriteLine(tmp);
                }
            }
        }
        public static void Delete(StreamReader sr)
        {
            string[] mass = new string[100];
            int h = DateTime.Now.Hour;
            int m = DateTime.Now.Minute;
            int tmph, tmpm;
            int size = 0;
            string str, tmp = "";
            int i = 0, k = 0;
            while (!sr.EndOfStream)
            {
                i = 0;
                k++;
                str = sr.ReadLine();
                while (str[i] != ':')
                {
                    tmp += str[i];
                    i++;
                }
                i++;
                tmph = Convert.ToInt32(tmp);
                tmp = "";
                for (int j = i; str[j] != ':'; j++)
                {
                    tmp += str[j];
                }
                tmpm = Convert.ToInt32(tmp);
                tmp = "";
                if (h * 60 + m - tmph * 60 - tmpm < 60)
                {
                    mass[size] = str;
                    size++;
                    str = sr.ReadLine();
                    mass[size] = str;
                    size++;
                    Console.WriteLine(str);
                }
                else
                    str = sr.ReadLine();
            }
            sr.Close();
            File.Delete("kualogfile.txt");
            StreamWriter sw = new StreamWriter("kualogfile.txt");
            for (int l = 0; l < size; l++)
            {
                sw.WriteLine(mass[l]);
            }
            sw.Close();
            Console.WriteLine(k + " записей");
        }
    }
}
