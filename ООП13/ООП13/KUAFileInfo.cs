using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace ООП13
{
    static class KUAFileInfo
    {
        public static void FullDirection(StreamWriter sw,string f)
        {
            KUALog.KUAWriter(sw, "Полный путь");
            FileInfo fi = new FileInfo(f);
            if (fi.Exists)
            {
                Console.WriteLine($"Full Direction: {fi.DirectoryName}\\{fi.Name}");
            }
        }
        public static void FileInfo(StreamWriter sw,string f)
        {
            KUALog.KUAWriter(sw, "Информация о файлах");
            FileInfo fi = new FileInfo(f);
            if (fi.Exists)
            {
                Console.WriteLine($"Size: {fi.Length},Extension: {fi.Extension}, Name: {fi.Name}");
            }
        }
        public static void CreationTime(StreamWriter sw,string f)
        {
            KUALog.KUAWriter(sw, "Время создания");
            FileInfo fi = new FileInfo(f);
            if (fi.Exists)
            {
                Console.WriteLine($"Creation Time: {fi.CreationTime}");
            }
        }
    }
}
