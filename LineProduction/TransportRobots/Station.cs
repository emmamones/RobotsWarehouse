using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace TransportRobots
    {
   public class Station
        {
        public int MaxNBoxes { get; set; }
        public int idStation { get; set; }
        public bool Occupy { get; set; }
        public delegate void delRobot(Robot iRobot,bool pOccupay);
        public event delRobot RobotActivity;

        public delegate void delStation(Station iStation,bool pOccupay,int idRobot);
        public event delStation StationActivity;
       /// <summary>
       /// creation of Stations
       /// </summary>
       /// <param name="pNBoxes"></param>
        public Station(int pIdstation, int pMaxNBoxes) { Occupy = false; MaxNBoxes = pMaxNBoxes; idStation = pIdstation; }
        public Station() { }
        public void ArriveRobot(Robot iRobot)
            { 
            StationActivity(this, true,iRobot.idRobot);
            RobotActivity(iRobot, true);  
            do
                {
                if (iRobot.NBoxes >= 1)
                    {
                    LeaveBox(iRobot);
                    }
                else { break; }
                } while (MaxNBoxes >= 1);

            DepartureRobot(iRobot); 
            }

        public void LeaveBox(Robot iRobot)
            {
            //Thread.Sleep(1000);
            Console.WriteLine(string.Format(" Robot:{0} , Droping Box on Station:{1}", iRobot.idRobot.ToString(), idStation.ToString())); 
            iRobot.NBoxes = iRobot.NBoxes - 1; 
            MaxNBoxes = MaxNBoxes - 1;
            
            }

        public void DepartureRobot(Robot iRobot)
            {
            StationActivity(this, false, iRobot.idRobot);
            RobotActivity(iRobot, false); 
            } 


        }
    }
