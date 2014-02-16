using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TransportRobots.Interfaces;

namespace TransportRobots.Entities
    {
    public abstract class ASubjectServus
        {
        public delegate void StatusUpdate(int idRobot, bool pOccupy, int NBoxes);
        public event StatusUpdate OnStatusUpdate = null;

        public void AttachCentral(IObserverServus product)
            { 
            //attach the Dispacher(Observer) to Robot(subject) Observing the Changes of Activity Creating the New Event by a Delegate Function.
            OnStatusUpdate += new StatusUpdate(product.NotifyRobotActivity);
            }
        public void DetachCentral(IObserverServus product)
            {
            OnStatusUpdate -= new StatusUpdate(product.NotifyRobotActivity);
            }

        public void Notify(int idRobot, bool pOccupy, int NBoxes)
            { 
            //Notify the Dispacher with change, executing the Delegate Function declared on the Dispacher.
            if (OnStatusUpdate != null)
                {
                OnStatusUpdate(idRobot, pOccupy, NBoxes);
                }
            }

        }
    }
