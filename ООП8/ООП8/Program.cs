using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace OOP8
{
    class Engine : IComparable
    {
        private int power;
        public enum State : int { OFF, ON };
        private State status;
        public State Status
        {
            get
            {
                return status;
            }
            set
            {
                status = value;
            }
        }
        public int Power
        {
            get
            {
                return power;
            }
            set
            {
                if (value > 0)
                    power = value;
                else
                    power = 0;
            }
        }
        public int CompareTo(Object a)
        {
            Engine b = (Engine)a;
            if (this.Power < b.Power)
                return -1;
            else if (this.Power > b.Power)
                return 1;
            else
                return 0;
        }
        public void ChangeStatus()
        {
            if (Status == 0)
                Status = (State)1;
            else
                Status = (State)0;
        }
        public override string ToString()
        {
            return "[Двигатель] Мощность: " + Power + ", ToString() = " + base.ToString();
        }
        public override int GetHashCode()
        {
            return base.GetHashCode() - 10;
        }
        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }
        public Engine(int p)
        {
            Status = 0;
            Power = p;
        }

    }
    interface IWork<T>
    {
        void Show(int i);
        void Add(T n);
        void Del(int n);
    }
    public class Mass<T> : IWork<T> where T : IComparable
    {
        private int size;
        public T[] list;
        public Mass(int i)
        {
            size = i;
            list = new T[size];
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
        public T this[int i]
        {
            get
            {
                return list[i];
            }
            set
            {
                list[i] = value;
            }
        }
        public void Show(int i)
        {
            Console.WriteLine(this[i]);
        }
        public void Add(T n)
        {
            this.list.Append(n);
        }
        public void Del(int n)
        {
            for (int i = n; i < this.Size-1;i++)
            {
                list[i] = list[i + 1];
            }
            Size--;
        }
        public void Print()
        {
            for (int i = 0; i < this.Size; i++)
                Console.WriteLine(this[i]);
        }
        public static Mass<T> operator +(Mass<T> a, T b)
        {
            Mass<T> tmp = new Mass<T>(a.Size + 1);
            tmp[0] = b;
            for (int i = 0; i < a.Size; i++)
                tmp[i + 1] = a[i];
            tmp.Size = a.Size + 1;
            return tmp;
        }
        public static Mass<T> operator --(Mass<T> a)
        {
            Mass<T> tmp = new Mass<T>(a.Size - 1);
            for (int i = 0; i < a.Size - 1; i++)
                tmp[i] = a[i];
            tmp.Size = a.Size - 1;
            return tmp;
        }
        public static bool operator !=(Mass<T> a, Mass<T> b)
        {
            if (a.Size == b.Size)
            {
                for (int i = 0; i < a.Size; i++)
                    if (a[i].Equals(b[i]))
                        return false;
            }
            else
                return false;
            return true;
        }
        public static bool operator ==(Mass<T> a, Mass<T> b)
        {
            if (a.Size == b.Size)
            {
                for (int i = 0; i < a.Size; i++)
                    if (a[i].Equals(b[i]))
                        return false;
            }
            else
                return false;
            return true;
        }
        public static bool operator true(Mass<T> a)
        {
            for (int i = 0; i < a.Size; i++)
                for (int j = i; j < a.Size; j++)
                    if (a[i].CompareTo(a[j])>0)
                        return false;
            return true;
        }
        public static bool operator false(Mass<T> a)
        {
            for (int i = 0; i < a.Size; i++)
                for (int j = i; j < a.Size; j++)
                    if (a[i].CompareTo(a[j]) ==-1)
                        return false;
            return true;
        }
    }
    public static class Serializer<T>
    {
        public static void Save(string path, T data)
        {
            XmlSerializer formatter = new XmlSerializer(typeof(T));

            using (var stream = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.Write))
            {
                formatter.Serialize(stream, data);
            }
        }

        public static T Load(string path)
        {
            Type type = typeof(T);
            T retVal;

            XmlSerializer formatter = new XmlSerializer(type);

            using (var stream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                retVal = (T)formatter.Deserialize(stream);
            }

            return retVal;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                FileInfo f = new FileInfo("f.data");
                Mass<string> a = new Mass<string>(3);
                Mass<Engine> b = new Mass<Engine>(3);
                a.list = Serializer<string[]>.Load("f.data");
                a--;
                if (a)
                    Console.WriteLine("Да");
                b[0] = new Engine(200);
                b[1] = new Engine(100);
                b[2] = new Engine(300);
                if (b)
                    Console.WriteLine("Да");
                else
                {
                    Console.WriteLine("Нет");
                }
                a.Print();
                b.Print();
                Serializer<string[]>.Save("f.data", a.list);
                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            catch
            {
                Console.WriteLine("Ошибка");
            }
            finally
            {
                
            }
        }
    }
}
