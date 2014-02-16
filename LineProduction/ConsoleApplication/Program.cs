using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using TransportRobots;
using TransportRobots.Entities;

namespace ConsoleApplication
    {
    class Program
        {

        static void Main(string[] args)
            {

            Dispatcher WH = new Dispatcher(4, 5, 2, 8, 40, 3);
            ErrorProduccion ER = WH.Start();
            Console.WriteLine(ER.Reason.ToString());
            //NUevos COmentarios
            //mas Comentarios
            }
        public void TestMergeMethod()
        { }
        }
    }
