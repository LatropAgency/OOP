using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ООП5
{
    class Car : Vehicle
    {
        private string stamp;
        public string Stamp
        {
            get
            {
                return stamp;
            }
            set
            {
                if (value != "")
                    stamp = value;
                else
                    stamp = "Unknown";
            }
        }
        public override void Move()
        {
            if (this.Status == 0)
                Console.WriteLine("Я машина и я стою");
            else
                Console.WriteLine("Я машина и я еду");
        }
        public Car(int p, string stm) : base(p)
        {
            Stamp = stm;
        }
        public override string ToString()
        {
            return "[Автомобиль] Марка: " + Stamp + " " + base.ToString();
        }
    }
}
