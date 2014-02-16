using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TransportRobots.Interfaces
    {
  public  interface IObserverServus
        {
      void NotificarRobotvalible(int idRobot, bool pOccupy,int NBoxes);
        }
    }
