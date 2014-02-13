using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using TransportRobots;

namespace ConsoleApplication
    {
    class Program
        {
     
        static void Main(string[] args)
            {

            WareHouse WH = new WareHouse(4, 5,2,8, 40, 3);
            ErrorProduccion ER = WH.Start();
           Console.WriteLine(ER.Reason.ToString());
            }

        }
    }
