using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TransportRobots.Interfaces;

namespace TransportRobots.Entities
    {
    public class DeliverStation : ASubjectStation
        {

        public override void StationActivity(int idRobot, bool busy)
            {
            throw new NotImplementedException();
            }

        public override void ProccesTask()
            {
            throw new NotImplementedException();
            }
        }
    }
