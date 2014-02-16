using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TransportRobots.Enum;
using TransportRobots.Interfaces;

namespace TransportRobots.Entities
    {
    public class Servus : ASubjectServus, IRobot
        {
        #region Declarations
        public int idRobot { get; set; }
        public int CantidadDescarga { get; set; }
        public int NBoxes { get; set; }
        public int NSiguientePosicion { get; set; }
        public bool Busy { get; set; }
        public EAccion Activity { get; set; }
        public List<ASubjectStation> ListStations { get; set; }

        #endregion

        #region Constructores
        /// <summary>
        /// Empty COnstructor
        /// </summary>
        public Servus() { }
        /// <summary>
        /// Constructor process Begin.
        /// </summary>
        /// <param name="pidRobot"></param>
        /// <param name="pNBoxes"></param>
        public Servus(int pidRobot, int pNBoxes)
            {
            Busy = false;
            CantidadDescarga = 1;
            NBoxes = pNBoxes;
            NSiguientePosicion = 0;
            idRobot = pidRobot;
            ListStations = new List<ASubjectStation>();
            }

        #endregion


        public void SendRobot(ASubjectStation iStation)
            {
            if (Activity == EAccion.DropItems)
                {
                ExecuteMovement(iStation);
                }
            }

        public bool ExecuteMovement(ASubjectStation pStaion)
            {
            bool executedSuccess = false;
            ChangeAvailability(idRobot, true, NBoxes); 
            pStaion.StationActivity(idRobot, true);
            //pStaion.Notify(pStaion.idStation, true, idRobot, pStaion.MaxNBoxes); 
            if (Activity == EAccion.DropItems)
                {
                do
                    {
                    if (NBoxes >= 1)
                        {
                        if (LeaveBox())
                            {
                            pStaion.ProccesTask();
                            ///Are there More Stations Close?
                            }
                        }
                    else
                        {
                        //No more Boxes
                        executedSuccess = true;
                        break;
                        }
                    } while (pStaion.MaxNBoxes >= 1);

                }

         
            ChangeAvailability(idRobot, false, NBoxes);
            // pStaion.Notify(pStaion.idStation, false, idRobot, pStaion.MaxNBoxes); 
            pStaion.StationActivity(idRobot, false);
            return executedSuccess;
            }


        public bool LeaveBox()
            {
            //Console.WriteLine(string.Format(" Robot:{0} , Droping Box on Station:{1}", iRobot.idRobot.ToString(), idStation.ToString()));
            try
                {
                NBoxes = NBoxes - CantidadDescarga;
                return true;
                }
            catch (Exception)
                {
                return false;
                }
            }




        public void ChangeAvailability(int idRobot, bool pOccupy, int NBoxes)
            {
            this.Notify(idRobot, pOccupy, NBoxes);
            }
        }
    }
