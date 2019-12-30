using System;
using System.IO;

namespace ООП9
{
    public delegate string StringFormat(ref string str);
    class Program
    {
        delegate void Hello(); 
        static void Main(string[] args)
        {
            User u1 = new User();
            //Hello hello = () => Console.WriteLine("Hello");
            //hello();
            u1.Upgrade += DisplayConsole;
            u1.Update("Готовка");
            u1.Upgrade -= DisplayConsole;
            u1.Upgrade += DisplayFile;
            u1.Update("Учёба");
            u1.Upgrade -= DisplayFile;
            u1.Upgrade += DisplayRedMessage;
            u1.Update("Тестирование");
            u1.Work += Increment;
            u1.TimeWorking(u1.Time);
            u1.TimeWorking(u1.Time);
            u1.TimeWorking(u1.Time);
            u1.Work -= Increment;
            u1.Work += Decrement;
            u1.TimeWorking(u1.Time);
            //Задание 2
            string str = "        vOVa , vova. dima? 2laTrop         ";
            //Console.WriteLine(str);
            //Fixer.Trimmer(ref str);
            //Console.WriteLine(str);
            //Fixer.Lower(ref str);
            //Console.WriteLine(str);
            //Fixer.Replacer(ref str);
            //Console.WriteLine(str);
            //Fixer.GetString(ref str);
            //Console.WriteLine(str);
            StringFormat sf = null;
            sf += Fixer.Trimmer;
            sf += Fixer.Replacer;
            sf += Fixer.Lower;
            sf += Fixer.GetString;
            Console.WriteLine(sf(ref str));
            //Конец задания 2
            Console.Read();
        }
        public static void DisplayConsole(string str)
        {
            Console.WriteLine(str);
        }
        public static void DisplayFile(string str)
        {
            FileStream f = new FileStream("message.txt", FileMode.Create);
            byte[] array = System.Text.Encoding.Default.GetBytes(str);
            f.Write(array, 0, str.Length);
            f.Close();
        }
        private static void DisplayRedMessage(String message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ResetColor();
        }
        private static int Increment(int i)
        {
            return ++i;
        }
        private static int Decrement(int i)
        {
            return --i;
        }
    }
}
