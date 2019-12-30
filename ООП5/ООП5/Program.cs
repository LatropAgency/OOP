using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ООП5
{
    class Program
    {
        static void Main(string[] args)
        {
            Car c1 = new Car(100,"Geely");
            Train tr1 = new Train(600,"Stolin","Blue",3);
            Express exp1 = new Express(500, "Minsk", "Red", 10, true);
            Engine eng1 = new Engine(200);
            Console.WriteLine(c1.ToString());
            Console.WriteLine(tr1.ToString());
            Console.WriteLine(exp1.ToString());
            Console.WriteLine(eng1.ToString());
            Printer p = new Printer();
            c1.Move();
            Console.WriteLine(c1.Status);
            c1.ChangeStatus();
            c1.Move();
            Console.WriteLine(c1.Status);
            exp1.Move();
            Console.WriteLine(exp1.Speed);
            Engine[] eng = new Engine[4];
            eng[0] = c1;
            eng[1] = tr1;
            eng[2] = exp1;
            eng[3] = eng1;
            for (int i = 0; i < 4; i++)
                p.iAmPrinting(eng[i]);
            Console.ReadKey();
        }
    }
}
