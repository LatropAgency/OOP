using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP4
{
    static class StatisticOperation
    {
        public static int WordCount(this string str)
        {
            int count = 0;
            for (int i = 0; i < str.Length; i++)
                if (str[i] == ' ')
                    count++;
            return count+1;
        }
        private static int Max(Mass m)
        {
            int max = 0;
            for (int i = 0; i < Count(m); i++)
                if (m[i]>m[max])
                    max = i;
            return m[max];
        }
        private static int Min(Mass m)
        {
            int min = 0;
            for (int i = 0; i < Count(m); i++)
                if (m[i] < m[min])
                    min = i;
            return m[min];
        }
        public static int Diff(Mass a)
        {
            return Max(a) - Min(a);
        }
        public static int Sum(Mass a)
        {
            int sum = 0;
            for (int i = 0; i < Count(a); i++)
                sum += a[i];
            return sum;
        }
        public static int Count(Mass a) { 
            return a.Length;
        }
        public static int ZeroCount(this Mass a)
        {
            int count = 0;
            for (int i = 0; i < a.Length; i++)
                if (a[i] == 0)
                    count++;
            return count;
        }
    }
    class Mass
    {
        public class Date
        {
            private int day;
            private int month;
            private int year;
            public int Day
            {
                get
                {
                    return day;
                }
                set
                {
                    day = value;
                }
            }
            public int Month
            {
                get
                {
                    return month;
                }
                set
                {
                    month = value;
                }
            }
            public int Year
            {
                get
                {
                    return year;
                }
                set
                {
                    year = value;
                }
            }
            public Date(int val_day, int val_month, int val_year)
            {
                Day = val_day;
                Month = val_month;
                Year = val_year;
            }
        }
        public class Owner
        {
            private int id;
            private string name;
            private string org;
            public int Id
            {
                get
                {
                    return id;
                }
                set
                {
                    id = value;
                }
            }
            public string Name
            {
                get
                {
                    return name;
                }
                set
                {
                    name = value;
                }
            }
            public string Org
            {
                get
                {
                    return org;
                }
                set
                {
                    org = value;
                }
            }
            public Owner(int val_id,string val_name, string val_org)
            {
                Id = val_id;
                Name = val_name;
                Org = val_org;
            }
        }
        Owner owner = new Owner(11,"Vova","LatropAgeny");
        Date date = new Date(16,10,2019);
        private int size;
        private int[] list;

        public Mass(int i)
        {
            size = i;
            list = new int[size];
        }
        public int Size
        {
            get
            {
                return size;
            }
            set
            {
                size = value;
            }
        }
        public int Length
        {
            get
            {
                return list.Length;
            }
        }
        public int this[int i]
        {
            get {
                return list[i];
            }
            set
            {
                list[i] = value;
            }
        }
        public void Print()
        {
            for ( int i = 0; i < this.Size; i++)
                Console.WriteLine(this[i]);
        }
        public static Mass operator +(Mass a, int b)
        {
            Mass tmp = new Mass(a.Size+1);
            tmp[0] = b;
            for (int i = 0; i < a.Size; i++)
                tmp[i+1] = a[i];
            tmp.Size = a.Size + 1;
            return tmp;
        }
        public static Mass operator --(Mass a)
        {
            Mass tmp = new Mass(a.Size-1);
            for (int i = 0; i < a.Size-1; i++)
                tmp[i] = a[i];
            tmp.Size = a.Size - 1;
            return tmp;
        }
        public static bool operator !=(Mass a, Mass b)
        {
            if (a.Size == b.Size)
            {
                for (int i = 0; i < a.Size; i++)
                    if (a[i] != b[i])
                        return false;
            } 
            else
                return false;
            return true;
        }
        public static bool operator ==(Mass a, Mass b)
        {
            if (a.Size == b.Size)
            {
                for (int i = 0; i < a.Size; i++)
                    if (a[i] != b[i])
                        return false;
            }
            else
                return false;
            return true;
        }
        public static bool operator true(Mass a)
        {
            for (int i = 0; i < a.Size; i++)
                for (int j = i; j < a.Size; j++)
                    if (a[i] > a[j])
                        return false;
            return true;
        }
        public static bool operator false(Mass a)
        {
            for (int i = 0; i < a.Size; i++)
                for (int j = i; j < a.Size; j++)
                    if (a[i] > a[j])
                        return false;
            return true;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Mass a = new Mass(6);
            for (int i = 0; i < 6; i++)
            {
                a[i] = i;
            }
            if (a)
                Console.WriteLine("Да");
            else
                Console.WriteLine("Нет");
            a = a + 4;
            a--;
            if (a)
                Console.WriteLine("Да");
            else
                Console.WriteLine("Нет");
            a.Print();
            string s = "London is the capital of Great Britain";
            Console.WriteLine(StatisticOperation.Diff(a) + " " + StatisticOperation.Sum(a) + " " + StatisticOperation.Count(a) + " " + StatisticOperation.WordCount("London is the capital of Great Britain") + " " + s.WordCount() + " " + StatisticOperation.ZeroCount(a));
            Console.ReadLine();
        }
    }
}
