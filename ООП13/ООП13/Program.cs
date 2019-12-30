using System;
using System.IO;

namespace ООП13
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamWriter sw = KUALog.CreateStream("kualogfile.txt");
            sw.WriteLine("1:10:14:12:2019");
            sw.WriteLine("Hi");
            KUADiskInfo.FreeSpace(sw);
            KUADiskInfo.FileSystemInfo(sw);
            KUADiskInfo.DiskInfo(sw);
            KUAFileInfo.FullDirection(sw, "kualogfile.txt");
            KUAFileInfo.FileInfo(sw, "kualogfile.txt");
            KUAFileInfo.CreationTime(sw, "kualogfile.txt");
            KUADirInfo.CreationTime(sw, "..");
            KUADirInfo.DirCount(sw, "D://");
            //KUAFileManager.DiskReader(sw,"D://");
            KUALog.CloseStream(sw);
            StreamReader sr = new StreamReader("kualogfile.txt");
            //KUAGoogle.SearchHour(sr);
            //KUAGoogle.SearcherOblastb(sr, 0, 2);
            //KUAGoogle.SearcherDate(sr, 20, 12);
            //KUAGoogle.SearcherWord(sr, "Информация");
            KUAGoogle.Delete(sr);
            Console.ReadKey();
        }
    }
}
