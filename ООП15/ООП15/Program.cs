using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics;
using System.Reflection;

namespace ооп15
{
    class Program
    {
        static void Main(string[] args)
        {
            using (StreamWriter fs = new StreamWriter("processes.txt"))
            {
                var AllProcess = Process.GetProcesses();
                foreach (Process p in AllProcess)
                {
                    fs.WriteLine(p.Id);
                    fs.WriteLine(p.ProcessName);
                    fs.WriteLine(p.BasePriority);
                    fs.WriteLine(p.Responding);
                    fs.WriteLine(p.Container);
                    fs.WriteLine(p.HandleCount);
                }
            }
            AppDomain newapp = AppDomain.CreateDomain("New Domain");
            newapp.Load("ооп15");
            Console.WriteLine(newapp.Id);
            Console.WriteLine(newapp.FriendlyName);
            Console.WriteLine(newapp.BaseDirectory);
            Assembly[] newasswem = newapp.GetAssemblies();
            foreach (Assembly p in newasswem)
            {
                Console.WriteLine(p.FullName);
            }
            AppDomain app = AppDomain.CurrentDomain;
            Console.WriteLine(app.Id);
            Console.WriteLine(app.FriendlyName);
            Console.WriteLine(app.BaseDirectory);
            Assembly[] assem = app.GetAssemblies();
            foreach (Assembly p in assem)
            {
                Console.WriteLine(p.FullName);
            }
            int n = 100;
            AppDomain.Unload(newapp);
            StreamWriter sw = new StreamWriter("simple.txt");
            Thread th = new Thread(new ParameterizedThreadStart(operation));
            th.Start(sw);
            Console.WriteLine(th.ThreadState);
            Console.WriteLine(th.Priority);
            th.Name = "SecondThread";
            Console.WriteLine(th.Name);
            Console.WriteLine("id: " + th.ManagedThreadId);
            for (int i = 2; i <= n; i++)
            {
                if (isSimple(i))
                {
                    sw.WriteLine(i);
                    Console.WriteLine(i);
                }
            }
            Thread.Sleep(1000);
            sw.Close();
            Thread th1 = new Thread(new ThreadStart(even));
            Thread th2 = new Thread(new ThreadStart(noteven));
            th1.Priority = ThreadPriority.AboveNormal;
            th1.Start();
            th2.Start();
            DateTime num = DateTime.Now;
            Console.ReadLine();
            TimerCallback tm = new TimerCallback(Count);
            Timer timer = new Timer(tm, num, 0, 2000);
            Console.ReadLine();
        }
        public static bool isSimple(int N)
        {
            for (int i = 2; i < (int)(N / 2); i++)
            {
                if (N % i == 0)
                    return false;
            }
            return true;
        }
        public static void operation(object sw)
        {
            int n = 100;
            StreamWriter s = (StreamWriter)sw;
            {
                for (int i = 2; i <= n; i++)
                {
                    if (isSimple(i))
                    {
                        s.WriteLine(i);
                        Console.WriteLine(i);
                    }
                }
            }
        }
        public static void even()
        {
            int n = 100;
            for (int i = 2; i < n; i += 2)
            {
                Thread.Sleep(30);
                Console.WriteLine(i);
            }
        }
        public static void noteven()
        {
            int n = 100;
            for (int i = 1; i < n; i += 2)
            {
                Thread.Sleep(60);
                Console.WriteLine(i);
            }
        }
        static object locker = new object();
        /*public static void even()
        {
            lock(locker)
            {
                for (int i = 2; i < 100; i+=2)
                {
                    Console.WriteLine(i);
                    Thread.Sleep(50);
                }
            }
        }
        public static void noteven()
        {
            lock (locker)
            {
                for (int i = 1; i < 100; i += 2)
                {
                    Console.WriteLine(i);
                    Thread.Sleep(50);
                }
            }
        }*/
        static Mutex mutex = new Mutex();
        /*public static void even()
        {
            for (int i = 2; i < 100; i += 2)
            {
                mutex.WaitOne();
                {
                    Console.WriteLine(i);
                }
                mutex.ReleaseMutex();
                Thread.Sleep(50);
            }
        }
        public static void noteven()
        {
            for (int i = 1; i < 100; i += 2)
            {
                mutex.WaitOne();
                {
                    Console.WriteLine(i);
                }
                mutex.ReleaseMutex();
                Thread.Sleep(50);
            }
        }*/
        public static void Count(object obj)
        {
            DateTime x = (DateTime)obj;
            Console.WriteLine(x.Day + "." + x.Month + "." + x.Year);
        }
    }
}