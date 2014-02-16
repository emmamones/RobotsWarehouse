using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using TransportRobots.Interfaces;
using TransportRobots.Enum;

namespace TransportRobots.Entities
    {
    public class ContainerStation :ASubjectStation
        {
 
        /// <summary>
        /// creation of Stations
        /// </summary>
        /// <param name="pNBoxes"></param>
        public ContainerStation(int pIdstation, int pMaxNBoxes) { Occupy = false; MaxNBoxes = pMaxNBoxes; idStation = pIdstation; }
        public ContainerStation() { }
 

        public override void StationActivity(int idRobot, bool busy)
            {
              this.Notify(idStation, busy, idRobot, MaxNBoxes); 
            }

        public override void ProccesTask()
            {
            MaxNBoxes--;
            }
        }
    }
