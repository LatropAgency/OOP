using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ООП5
{
    sealed class Express : Train
    {
        private bool express;
        public bool Exp
        {
            get
            {
                return express;
            }
            set
            {
                express = value;
            }
        }
        public override void Move()
        {
            if (this.Status == 0)
                Console.WriteLine("Я экспресс и я стою");
            else
                Console.WriteLine("Я экспресс и я еду");
        }
        public Express(int p=50,int pr=3000, string dir="Minsk", string col="blue", int am=5, bool t=true) : base(p,pr, dir, col, am)
        {
            Exp = t;
        }
        public override string ToString()
        {
            return "[Экспресс]" + base.ToString();
        }
    }
}
