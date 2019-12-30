using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ООП5
{
    class Printer
    {
        public virtual void iAmPrinting(Engine obj)
        {
            if (obj is Train)
                if (obj as Express != null)
                    Console.WriteLine("[Экспресс]");
                else
                    Console.WriteLine("[Поезд]");
            else if (obj is Car)
                Console.WriteLine("[Автомобиль]");
            else 
                Console.WriteLine("[Двигатель]");
            Console.WriteLine(obj.ToString());
        }
    }
}
