using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Collections.ObjectModel;

namespace ООП10
{
    class Student
    {
        private string name;
        public string Name { get { return name; } set { name = value; } }
        public Student(string str)
        {
            Name = str;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            //Задание 1
            ArrayList arr = new ArrayList();
            Student s1 = new Student("Вова");
            for (int i = 0; i < 5; i++)
                arr.Add(i);
            arr.Add("строка");
            arr.Add(s1);
            arr.Remove(s1);
            Console.WriteLine(arr.Count);
            foreach (object s in arr)
                Console.WriteLine(s.ToString());
            if (arr.Contains(0))
                Console.WriteLine("Да");
            //Задание 2
            SortedList<int, char> sort = new SortedList<int, char>();
            sort.Add(0, 'a');
            sort.Add(1, 'v');
            sort.Add(5, ' ');
            sort.Add(99, '9');
            sort.Add(-10, '-');
            foreach (int a in sort.Keys)
                Console.WriteLine("Ключ: ["+a+"], Значение: "+sort[a]);
            int n = 3;
            for (int i = 0; i < n; i++)
                sort.Remove(sort.Keys[i]);
            sort.Add(2, '2');
            sort.Add(3, 'q');
            List<char> lst = new List<char>();
            foreach (int a in sort.Keys)
                lst.Add(sort[a]);
            foreach (char a in lst)
                Console.WriteLine("Значение: " + a);
            if(lst.Contains(' '))
                Console.WriteLine("Да");
            //Задание 3
            SortedList<int, Engine> srt = new SortedList<int, Engine>();
            Engine e1 = new Engine("Audi", 300);
            Engine e2 = new Engine("Reno", 100);
            Engine e3 = new Engine("BMV", 400);
            Engine e4 = new Engine("Tesla", 300);
            srt.Add(1,e1);
            srt.Add(2, e2);
            srt.Add(3, e3);
            srt.Add(4, e4);
            n = 2;
            for (int i = 0; i < n; i++)
                sort.Remove(srt.Keys[i]);
            srt.Add(6, e1);
            srt.Add(9, e2);
            List<Engine> l = new List<Engine>();
            foreach (int a in srt.Keys)
                l.Add(srt[a]);
            foreach (Engine a in l)
                Console.WriteLine("Значение: " + a.ToString());
            if (l.Contains(e1))
                Console.WriteLine("Да");
            //Задание 4
            ObservableCollection<Engine> eng = new ObservableCollection<Engine>();
            eng.CollectionChanged += EngineChange;
            eng.Add(e1);
            eng.Add(e2);
            eng.Add(e3);
            eng.Add(e4);
            eng.Remove(e3);

        }
        private static void EngineChange(object obj, NotifyCollectionChangedEventArgs e)
        {
            switch(e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    Console.WriteLine($"Добавлен {e.NewItems[0].ToString()}");
                    break;
                case NotifyCollectionChangedAction.Remove:
                    Console.WriteLine($"Удалён {e.OldItems[0].ToString()}");
                    break;
            }
        }
        public void Message(string str)
        {
            Console.WriteLine(str);
        }
        public void RedMessage(string str)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(str);
            Console.ResetColor();
        }
    }
}
