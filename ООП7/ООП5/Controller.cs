using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ООП5
{
    static class Controller
    {
        public static int Sum(VehicleAgency obj)
        {
            int sum = 0;
            for (int i = 0; i < obj.Size; i++)
                sum += obj[i].Price;
            return sum;
        } 
        public static void FuelSort(VehicleAgency obj)
        {
            Car tmpi,tmpj,buff;
            for (int i = 0; i <  obj.Size;i++)
            {
                if (obj[i] is Car)
                {
                    tmpi = (Car)obj[i];
                    for (int j = i; j < obj.Size;j++)
                    {
                        if (obj[j] is Car)
                        {
                            tmpj = (Car)obj[j];
                            if (tmpi.Fuel > tmpj.Fuel)
                            {
                                buff = tmpi;
                                tmpi = tmpj;
                                tmpj = buff;
                                obj[i] = tmpi;
                                obj[j] = tmpj;
                            }                                
                        }
                    }
                }
            }
        }
        public static Engine SpeedSearch(VehicleAgency obj,int min, int max)
        {
            Engine res = null;
            Car tmpc = new Car();
            Train tmpt = new Train();
            Express tmpe = new Express();
            for (int i = 0; i < obj.Size; i++)
            {
                if (obj[i] is Car)
                {
                    tmpc = (Car)obj[i];
                    if (tmpc.Speed > min && tmpc.Speed < max)
                    {
                        res = (Engine)obj[i];
                        break;
                    }
                }
                else if (obj[i] is Train)
                {
                    tmpt = (Train)obj[i];
                    if (tmpt.Speed > min && tmpt.Speed < max)
                    {
                        res = (Engine)obj[i];
                        break;
                    }
                }
                else if (obj[i] is Express)
                {
                    tmpe = (Express)obj[i];
                    if (tmpe.Speed > min && tmpe.Speed < max)
                    {
                        res = (Engine)obj[i];
                        break;
                    }
                }
            }
            return res;
        }
    }
}
