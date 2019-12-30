using System;
using System.IO.Compression;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace ООП13
{
    static class KUAFileManager
    {
        public static void DiskReader(StreamWriter sd,string s)
        {
            KUALog.KUAWriter(sd, "Создание KUAInspect");
            Directory.CreateDirectory("KUAInspect");
            FileStream fs = File.Create("KUAInspect\\kuadirinfo.txt");
            fs.Close();
            KUALog.KUAWriter(sd, "Создание kuadirinfo.txt");
            StreamWriter sw = new StreamWriter("KUAInspect\\kuadirinfo.txt");
            DirectoryInfo di = new DirectoryInfo(s);
            if (di.Exists)
            {
                DirectoryInfo[] d = di.GetDirectories();
                FileInfo[] f = di.GetFiles();

                for (int i = 0; i < d.Length; i++)
                {
                    Console.WriteLine($"{d[i].Name}");
                    sw.WriteLine(d[i].Name);
                }
                for (int i = 0; i < f.Length; i++)
                {
                    Console.WriteLine($"{f[i].Name}");
                    sw.WriteLine(f[i].Name);
                }
                sw.Close();
                KUALog.KUAWriter(sd, "Создание копирование из kuadirinfo в kuadirinfocopy");
                if (File.Exists("KUAInspect\\kuadirinfocopy.txt"))
                {
                    File.Delete("KUAInspect\\kuadirinfocopy.txt");
                }
                FileInfo q = new FileInfo("KUAInspect\\kuadirinfo.txt");
                q.CopyTo("KUAInspect\\kuadirinfocopy.txt");
                File.Delete("KUAInspect\\kuadirinfo.txt");
                Directory.CreateDirectory("KUAFiles");
                KUALog.KUAWriter(sd, "Создание KUAFiles");
                KUALog.KUAWriter(sd, "Запись в KUAFile");
                for (int i = 0; i < f.Length; i++)
                {
                    if (f[i].Extension == ".pdf")
                    {
                        if (File.Exists("KUAFiles\\"+f[i].Name))
                        {
                            File.Delete("KUAFiles\\"+f[i].Name);
                        }
                        f[i].CopyTo("KUAFiles\\" + f[i].Name);
                    }
                }
                DirectoryInfo d1 = new DirectoryInfo("KUAFiles");
                d1.MoveTo("KUAInspect\\KUAFiles");
                KUALog.KUAWriter(sd, "Перемещение KUAFiles");
                KUALog.KUAWriter(sd, "Архивирование KUAFiles");
                KUALog.KUAWriter(sd, "Разархивирование KUAFiles");
                ZipFile.CreateFromDirectory("KUAInspect\\KUAFiles","KUA.zip");
                ZipFile.ExtractToDirectory("KUA.zip", "KUAEnd");
            }
        }
    }
}
