using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TransportRobots.Enum;
using TransportRobots.Entities;

namespace TransportRobots.Interfaces
    {
   public interface IRobot
        { 
       void SendRobot(ASubjectStation iStation);
     
       bool ExecuteMovement(ASubjectStation pStaion);
       void ChangeAvailability(int idRobot, bool pOccupy, int NBoxes);
        }
    }
