using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Concurrent;

namespace ООП16
{
    class Program
    {
        public static bool isSimple(int N)
        {
            for (int i = 2; i < (int)(N / 2); i++)
            {
                if (N % i == 0)
                    return false;
            }
            return true;
        }

        static void Main(string[] args)
        {
            int n = 10000;
            Stopwatch stopWatch = new Stopwatch();
            CancellationTokenSource cancelTokenSource = new CancellationTokenSource();
            CancellationToken token = cancelTokenSource.Token;
            Task task1 = new Task(() => {

                for (int i = 0; i < n; i++)
                {
                    if (token.IsCancellationRequested)
                    {
                        Console.WriteLine("Операция прервана");
                        return;
                    }
                    if (isSimple(i))
                    {
                        Console.WriteLine(i);
                    }
                }

            });
            stopWatch.Start();
            task1.Start();
            Thread.Sleep(1000);
            //cancelTokenSource.Cancel(); //2
            Console.WriteLine("Status: "+task1.Status);
            Console.WriteLine("isComplited: "+task1.IsCompleted);
            Console.WriteLine("Id: "+task1.Id);
            Task.WaitAll(task1);
            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
            ts.Hours, ts.Minutes, ts.Seconds,
            ts.Milliseconds / 10);
            Console.WriteLine("RunTime " + elapsedTime);

            Task<string> tsk1 = new Task<string>(() => { return "London is the"; });
            Task<string> tsk2 = new Task<string>(() => { return "the capital"; });
            Task<string> tsk3 = new Task<string>(() => { return "of Great Britan"; });
            tsk1.Start();
            tsk2.Start();
            tsk3.Start();
            //Task.WaitAll(tsk1, tsk2, tsk3);
            Task tsk4 = Task.WhenAll(tsk1, tsk2, tsk3).ContinueWith(t => { Console.WriteLine(tsk1.Result + " " + tsk2.Result + " " + tsk3.Result); }); //4
            //Task tsk4 = Task.Run(() => { Console.WriteLine(tsk1.Result + " " + tsk2.Result + " " + tsk3.Result); }); //3

            Task<int> what = Task.Run(() => { return 5; });
            var awaiter = what.GetAwaiter();
            awaiter.OnCompleted(() => { Console.WriteLine("Task complited with result: " + what.Result); }); //4

            Parallel.For(1, 10, sum);//5
            ParallelLoopResult result = Parallel.ForEach<int>(new List<int>() { 1, 3, 5, 8 }, sum);//5

            Parallel.Invoke(()=>sum(100),
                ()=> {
                    int[] mass = new int[n];
                for (int i = 0; i < n; i++) { mass[i] = i;}}
            );

            BlockingCollection<int> blockcoll = new BlockingCollection<int>();
            for (int producer = 0; producer < 5; producer++)
            {
                Thread.Sleep(producer * 100);
                Task.Factory.StartNew(() =>
                {
                    blockcoll.Add(producer);

                    Console.WriteLine("Поставщик " + producer);
                });
            }
            Task consumer = Task.Factory.StartNew(
            () =>
            {
                foreach (var item in blockcoll.GetConsumingEnumerable())
                {
                    Console.WriteLine(" Покупатель взял " + item);
                }
            });

            SumAsync();

            Console.Read();
        }
        static void sum(int n)
        {
            int s = 0;
            for (int i = 0; i < n; i++)
                s += i;
            Console.WriteLine("Sum: " + s);
        }

        static async void SumAsync()
        {
            Console.WriteLine("Начало метода SumAsync"); // выполняется синхронно
            await Task.Run(() => sum(100));                // выполняется асинхронно
            Console.WriteLine("Конец метода SumAsync");
        }

    }
}
