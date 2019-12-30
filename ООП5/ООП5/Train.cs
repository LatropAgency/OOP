﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ООП5
{
    class Train : Vehicle, ICarriage
    {
        private string direction;
        private string color;
        private int amount;
        public int Amount
        {
            get
            {
                return amount;
            }
            set
            {
                if (value > 0)
                    amount = value;
                else
                    amount = 0;
            }
        }
        public string Color
        {
            get
            {
                return color;
            }
            set
            {
                if (value != "")
                    color = value;
                else
                    color = "Unknown";
            }
        }
        public string Direction
        {
            get
            {
                return direction;
            }
            set
            {
                if (value != "")
                    direction = value;
                else
                    direction = "Unknown";
            }
        }

        public override void Move()
        {
            if (this.Status == 0)
                Console.WriteLine("Я поезд и я стою");
            else
                Console.WriteLine("Я поезд и я еду");
        }
        public Train(int p, string dir, string col, int am) : base(p)
        {
            Direction = dir;
            Amount = am;
            Color = col;
        }
        public override string ToString()
        {
            return "[Поезд] Направление: " + Direction + ", Цвет: " + Color + ", Количество вагонов: " + Amount + " " + base.ToString();
        }
    }
}
