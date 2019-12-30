using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ООП5
{
    class Car : Vehicle
    {
        public struct info
        {
            public int mileage;
            public string wincode;
            public int year;
        };
        private int fuel;
        public int Fuel
        {
            get
            {
                return fuel;
            }
            set
            {
                fuel = value;
            }
        }
        public override void Move()
        {
            if (this.Status == 0)
                Console.WriteLine("Я машина и я стою");
            else
                Console.WriteLine("Я машина и я еду");
        }
        public Car(int p=0, int pr=0, int f=0) : base(p,pr)
        {
            Fuel = f;
        }
        public override string ToString()
        {
            return "[Автомобиль] Расход топлива: " + Fuel + " " + base.ToString();
        }
    }
}
