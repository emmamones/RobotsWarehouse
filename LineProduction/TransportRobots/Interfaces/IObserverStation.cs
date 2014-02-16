using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TransportRobots.Interfaces
    {
  public  interface IObserverStation
        {
      void NotifyStacionActivity(int idStation, bool pOccupy, int idRobot, int MaxNBoxes);
        }
    }
