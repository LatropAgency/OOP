using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace ООП13
{
    static class KUADiskInfo
    {
        private static DriveInfo[] allDrives = DriveInfo.GetDrives();

        public static void FreeSpace(StreamWriter sw)
        {
            KUALog.KUAWriter(sw, "Свободное место");
            for (int i = 0; i < allDrives.Length; i++)
            {
                if (allDrives[i].IsReady)
                {
                    Console.WriteLine($"[{allDrives[i].Name}]Avaible Free Space: {allDrives[i].AvailableFreeSpace}");
                }
            }
        }
        public static void FileSystemInfo(StreamWriter sw)
        {
            KUALog.KUAWriter(sw, "Информация о системе");
            Console.WriteLine($"File System Info: {allDrives[0].DriveFormat}");
        }
        public static void DiskInfo(StreamWriter sw)
        {
            KUALog.KUAWriter(sw, "Информация о диске");
            for (int i = 0; i < allDrives.Length; i++)
            {
                if (allDrives[i].IsReady)
                {
                    Console.WriteLine($"[{allDrives[i].Name}] Total Size: {allDrives[i].TotalSize}, Avaible Free Space: {allDrives[i].AvailableFreeSpace}, Label: {allDrives[i].VolumeLabel}");
                }
            }
        }
    }
}
