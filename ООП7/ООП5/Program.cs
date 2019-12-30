using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace ООП5
{
    partial class VehicleAgency { };
    class UnsignedException : Exception
    {
        private string message;
        public string Message
        {
            get
            {
                return message;
            }
            set
            {
                message = value;
            }
        }
        public UnsignedException(string str)
        {
            Message = str;
        }
    }
    class LimitException : UnsignedException
    {
        private int index;
        public int Index
        {
            get
            {
                return index;
            }
            set
            {
                index = value;
            }
        }
        public LimitException(string str,int i) :base(str)
        {
            Index = i;
        }
    }
    class SolveException : LimitException
    {
        private string solve;
        public string Solve
        {
            get
            {
                return solve;
            }
            set
            {
                solve = value;
            }
        }
        public SolveException(string str, int i, string slv) : base(str,i)
        {
            Solve = slv;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Car c1 = new Car(100, 200, 8);
                c1.Speed = 100;
                Car c2 = new Car(100, 100, 4);
                Car c3 = new Car(100, 300, 5);
                Train tr1 = new Train(600, 10000, "Stolin", "Blue", 3);
                Express exp1 = new Express(500, 200000, "Minsk", "Red", 10, true);
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
                //int c = va[0].Power;
                va.Add(c1);
                va.Add(c2);
                va.Add(c3);
                va.Add(tr1);
                va.Add(eng1);
                va.Add(exp1);
                //Debug.Assert(5!=5,"Стоп");
                Controller.FuelSort(va);
                va.iAmPrinting(va.get(0));
                va.iAmPrinting(va.get(1));
                va.iAmPrinting(va.get(2));
                Console.WriteLine(va.get(3).Status);
                Console.WriteLine(Controller.Sum(va));
                Engine eng2 = new Engine(300);
                eng2 = Controller.SpeedSearch(va, 50, 200);
                p.iAmPrinting(eng2);
                //tr1.Amount = -100;
                //int c = va[100].Power;
                //va[10].Power = 100;
                Console.ReadKey();
            }
            catch (SolveException e)
            {
                Console.WriteLine(e.Message + " [" + e.Index + "] " + "Решение: " + e.Solve);
                Console.ReadKey();
            }
            catch (LimitException e)
            {
                Console.WriteLine(e.Message + " [" + e.Index + "]");
                Console.ReadKey();
            }
            catch (UnsignedException e)
            {
                Console.WriteLine(e.Message + " " + e.Source);
                Console.ReadKey();
            }
            catch
            {
                Console.WriteLine("Неизвестная ошибка");
            }
            finally
            {
                Console.WriteLine("Блок finally");
                Console.ReadKey();
            }
        }
    }
}
