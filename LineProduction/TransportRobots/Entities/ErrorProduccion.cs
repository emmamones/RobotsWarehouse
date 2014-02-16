using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TransportRobots.Entities
    {
    public class ErrorProduccion
        {
        public string Reason { get; set; }
        public bool Pass { get; set; }
        public ErrorProduccion(string pReason,bool pPass) { 
            Reason=pReason;
            Pass = pPass;
            }
        }
    }
