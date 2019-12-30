using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace ООП13
{
    class KUADirInfo
    {
        public static void CreationTime(StreamWriter sw,string s)
        {
            KUALog.KUAWriter(sw, "Время создания");
            DirectoryInfo di = new DirectoryInfo(s);
            if (di.Exists)
                Console.WriteLine($"Creation Time: {di.CreationTime}");
        }
        public static void FileCount(StreamWriter sw,string s)
        {
            KUALog.KUAWriter(sw, "Количество файлов");
            DirectoryInfo di = new DirectoryInfo(s);
            if (di.Exists)
            {
                FileInfo[] fi = di.GetFiles();
                Console.WriteLine($"File Count: {fi.Length}");
            }
        }
        public static void DirCount(StreamWriter sw,string s)
        {
            KUALog.KUAWriter(sw, "Количество каталогов");
            DirectoryInfo di = new DirectoryInfo(s);
            if (di.Exists && di.Extension == "")
            {
                DirectoryInfo[] d = di.GetDirectories();
                Console.WriteLine($"Directory Count: {d.Length}");
            }
        }
        public static void ParentsCount(StreamWriter sw,string s)
        {
            KUALog.KUAWriter(sw, "Количество родительских каталогов");
            DirectoryInfo di = new DirectoryInfo(s);
            if (di.Exists)
            {
                Console.WriteLine($"Root: {di.Root}");
            }
        }
        }
}
