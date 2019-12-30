using System;
using System.Collections.Generic;
using System.Text;

namespace ООП10
{

    class Engine : IComparable, IComparer<Engine>
    {
        private int power;
        private string name;
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
        int IComparer<Engine>.Compare(Engine x, Engine y)
        {
            return string.Compare(x.Name, y.Name);
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
            return "[Двигатель] Производитель: " + Name + ", Мощность: " + Power;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode() - 10;
        }
        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }
        public Engine(string str,int p)
        {
            Name = str;
            Status = 0;
            Power = p;
        }

    }
}
