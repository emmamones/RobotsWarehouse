using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TransportRobots
    {
   public class Robot
        {
       public int idRobot { get; set; }
       public int NBoxes { get; set; }
       public int NSiguientePosicion { get; set; }
       public bool Busy { get; set; }
       public Robot() { }
       public Robot(int pidRobot, int pNBoxes) { Busy = false; NBoxes = pNBoxes; NSiguientePosicion = 0; idRobot = pidRobot; }
        }
    }
