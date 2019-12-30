using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ООП5
{
    abstract class Vehicle : Engine, iMovable
    {
        private int speed;
        public int Speed
        {
            get
            {
                return speed;
            }
            set
            {
                speed = value;
            }
        }
        public virtual void Move()
        {
            Console.WriteLine("Я транспортное средство и моя скорость: " + Speed);
        }
        public Vehicle(int p) : base(p)
        {
            Speed = 0;
        }
        public override string ToString()
        {
            return "[ТС] Скорость: " + Speed + " " + base.ToString();
        }
    }
}
