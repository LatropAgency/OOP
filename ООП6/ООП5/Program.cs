using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ООП5
{
    partial class VehicleAgency { };
    class Program
    {
        static void Main(string[] args)
        {
            Car c1 = new Car(100,200,8);
            c1.Speed = 100;
            Car c2 = new Car(100, 100, 4);
            Car c3 = new Car(100, 300, 5);
            Train tr1 = new Train(600,10000,"Stolin","Blue",3);
            Express exp1 = new Express(500,200000, "Minsk", "Red", 10, true);
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
            VehicleAgency va = new VehicleAgency();
            va.Add(c1);
            va.Add(c2);
            va.Add(c3);
            va.Add(tr1);
            va.Add(eng1);
            va.Add(exp1);
            Controller.FuelSort(va);
            va.iAmPrinting(va.get(0));
            va.iAmPrinting(va.get(1));
            va.iAmPrinting(va.get(2));
            Console.WriteLine(va.get(3).Status);
            Console.WriteLine(Controller.Sum(va));
            Engine eng2 = new Engine(300);
            eng2 = Controller.SpeedSearch(va, 50, 200);
            p.iAmPrinting(eng2);
            Console.ReadKey();
        }
    }
}
