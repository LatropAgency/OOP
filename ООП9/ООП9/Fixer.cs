using System;
using System.Collections.Generic;
using System.Text;

namespace ООП9
{
    static class Fixer
    {
        public static string Trimmer(ref string str)
        {
            str = str.Trim();
            return str;
        }
        public static string Replacer(ref string str)
        {
            str = str.Replace(",", String.Empty);
            str = str.Replace(".", String.Empty);
            str = str.Replace("/", String.Empty);
            str = str.Replace("!", String.Empty);
            str = str.Replace("?", String.Empty);
            str = str.Replace(":", String.Empty);
            str = str.Replace(";", String.Empty);
            return str;
        }
        public static string Lower(ref string str)
        {
            str = str.ToLower();
            return str;
        }
        private static string[] Spliter(string str)
        {
            int n = 999;
            string[] split = null;
            split = str.Split(' ', n);
            return split;
        }
        private static string ResultStr(string[] split)
        {
            string str = "";
            for (int i = split.Length-1; i >=0; i--)
            {
                str += split[i];
            }
            return str;
        }
        public static string GetString(ref string str)
        {
            str = ResultStr(Spliter(str));
            return str;
        }
    }
}
