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

        public delegate void delStation(Station iStation,bool pOccupay);
        public event delStation StationActivity;
       /// <summary>
       /// creation of Stations
       /// </summary>
       /// <param name="pNBoxes"></param>
        public Station(int pIdstation, int pMaxNBoxes) { Occupy = false; MaxNBoxes = pMaxNBoxes; idStation = pIdstation; }
        public Station() { }
        public void ArriveRobot(Robot iRobot)
            {
            Console.WriteLine(string.Format(" Robot:{0} ,Arrive on Station!{1}", iRobot.idRobot.ToString(), idStation.ToString()));          
            StationActivity(this, true);
            RobotActivity(iRobot, true); 
            do
                {
                if (MaxNBoxes >= 1)
                    {
                    LeaveBox(iRobot);  
                    }
                } while (iRobot.NBoxes >= 1);

            DepartureRobot(iRobot); 
            }

        public void LeaveBox(Robot iRobot)
            { 
            Console.WriteLine(string.Format(" Robot:{0} , Droping Box on Station:{1}", iRobot.idRobot.ToString(), idStation.ToString())); 
            iRobot.NBoxes = iRobot.NBoxes - 1; 
            MaxNBoxes = MaxNBoxes - 1;
            //Thread.Sleep(2000); 
            }

        public void DepartureRobot(Robot iRobot)
            {
            Console.WriteLine(string.Format(" Robot:{0} , Leaving  Station{1}", iRobot.idRobot.ToString(), idStation.ToString()));
            StationActivity(this,false);
            RobotActivity(iRobot, false);
            Console.WriteLine(string.Format(" Avalible spaces on Station!{0} : {1}", idStation.ToString(), MaxNBoxes.ToString()));            
            } 


        }
    }
