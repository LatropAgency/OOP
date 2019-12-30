﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ООП14
{
    [Serializable]
    public class Engine
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
        public string name;
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
        public Engine ()
        {
            Status = 0;
            Power = 0;
        }
    }
}
