using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ООП5
{
    partial class VehicleAgency:Printer
    {
        private int size = 0;
        public Engine[] arr = new Engine[10];
        public int Size
        {
            get
            {
                return size;
            }
            private set
            {
                size = value;
            }
        }
        public void Add(Engine obj)
        {
            this[Size] = obj;
            Size++;
        }
        public Engine get(int i)
        {
            return arr[i];
        }
        public void set(int i, Engine obj)
        {
            arr[i] = obj;
        }
        public void Del(int k)
        {
            for (int i = k; i < Size-1; i++)
            {
                arr[i] = arr[i + 1];
            }
            Console.WriteLine("Элемент: " + k + " удалён");
        }
        public Engine this[int i]
        {
            get
            {
                return arr[i];
            }
            set
            {
                arr[i] = value;
            }
        }
    }
}
