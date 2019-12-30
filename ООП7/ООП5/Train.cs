using System;
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
                if (value >= 0)
                    amount = value;
                else
                    throw new UnsignedException("Количество вагонов не может быть отрицательным");
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
                    throw new UnsignedException("Цвет не может быть пустой строкой");
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
                    throw new UnsignedException("Направление не может быть пустой строкой");
            }
        }

        public override void Move()
        {
            if (this.Status == 0)
                Console.WriteLine("Я поезд и я стою");
            else
                Console.WriteLine("Я поезд и я еду");
        }
        public Train(int p=50, int pr=3000, string dir="Stolin", string col = "Red", int am=5) : base(p,pr)
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
