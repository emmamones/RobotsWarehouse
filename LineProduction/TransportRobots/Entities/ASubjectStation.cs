using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TransportRobots.Interfaces;

namespace TransportRobots.Entities
    {
   public abstract class ASubjectStation
        {
        public int MaxNBoxes { get; set; }
        public int idStation { get; set; }
        public bool Occupy { get; set; }

       public delegate void StatusUpdate(int idStation, bool pOccupy, int idRobot, int MaxNBoxes);
        public event StatusUpdate OnStatusUpdate = null;

        public void AttachCentral(IObserverStation product)
            { 
            //attach the Dispacher(Observer) to Station(subject) Observing the Changes of Activity Creating the New Event by a Delegate Function.
            OnStatusUpdate += new StatusUpdate(product.NotificarStacionAvalible);
            }
        public void DetachCentral(IObserverStation product)
            { 
            OnStatusUpdate -= new StatusUpdate(product.NotificarStacionAvalible);
            }
        public abstract void StationActivity(int idRobot, bool busy);
        public abstract void ProccesTask();
        public void Notify(int idStation, bool pOccupy, int idRobot, int MaxNBoxes)
            { 
            //Notify the Dispacher with change, executing the Delegate Function declared on the Dispacher.
            if (OnStatusUpdate != null)
                {
                OnStatusUpdate(idStation, pOccupy, idRobot, MaxNBoxes);
                }
            }

        }
    }
