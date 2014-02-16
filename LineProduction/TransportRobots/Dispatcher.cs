using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using TransportRobots.Entities;
using TransportRobots.Interfaces;

namespace TransportRobots
    {
    public class Dispatcher : IObserverStation, IObserverServus
        {
        private List<int> stock { get; set; }
        private List<Servus> LRobots { get; set; }
        private List<ContainerStation> LStations { get; set; }

        private static int Robots;
        private static int Stations;
        private static int BoxperRobot;
        private static int BoxLimitsStation;
        private static int StockWharehouse;
        private static int LimitMaxonLine;
        private static ErrorProduccion ER;
        public delegate void delWareHouse(int pStations, int pRobots, int PStock, int pAvalibleSpace);
        public event delWareHouse WhareHouseStatusActivity;


        public delegate void delWareHouseNotificaciones(string Mensaje);
        public event delWareHouseNotificaciones WhareHouseNotifyMonitors;

        /// <summary>
        /// Especify all Inputs  for 
        /// </summary>
        /// <param name="nRobots"></param>
        /// <param name="nStations"></param>
        public Dispatcher(int nRobots, int nStations, int nBoxperRobot, int pBoxLimitsStation, int pStockWharehouse, int pLimitMaxonLine)
            {
            Robots = nRobots;
            Stations = nStations;
            BoxperRobot = nBoxperRobot;
            BoxLimitsStation = pBoxLimitsStation;
            StockWharehouse = pStockWharehouse;
            LimitMaxonLine = pLimitMaxonLine;
            ER = CrearProduccion(Robots, Stations, BoxperRobot, BoxLimitsStation, StockWharehouse);
            }
        /// <summary>
        /// Executes Program
        /// </summary>
        /// <returns></returns>
        public ErrorProduccion Start()
            {
          
            // Console.WriteLine(ER.Reason);
            WhareHouseNotifyMonitors(string.Format(ER.Reason.ToString()));

            if (ER.Pass)
                {
                do
                    {

                    WhareHouseStatusActivity(LStations.Where(x => x.Occupy == false && x.MaxNBoxes >= 1).Count()
                               , LRobots.Where(x => x.Busy == false ).Count()
                               , StockWharehouse, LimitMaxonLine);


                    if (LStations.Where(x => x.Occupy == false && x.MaxNBoxes >= 1).Count() >= 1)
                        {
                        foreach (var iStation in LStations.Where(x => x.Occupy == false && x.MaxNBoxes >= 1).ToList())
                            {
                            Servus iRobot = FindRobotAvalible();
                            if (iRobot != null)
                                {
                                Servus tempRob = new Servus(iRobot.idRobot,0);
                                AsignBoxes(tempRob);
                                tempRob.AttachCentral(this); 
                                WhareHouseNotifyMonitors(string.Format("Send Robot:{0} to Station:{1} ", tempRob.idRobot.ToString(),iStation.idStation.ToString()));

                                ContainerStation tempStation = new ContainerStation(iStation.idStation, iStation.MaxNBoxes);
                                tempStation.AttachCentral(this);

                                tempRob.NSiguientePosicion = tempStation.idStation;
                                Thread T = new Thread(() => tempRob.SendRobot(tempStation));
                                T.Start();
                                //T.Join(); //Uncomment it in order to Test the Main Thread waiting for the rest.
                                }
                            else
                                {
                                break;
                                }
                            } Thread.Sleep(1000); //Comment it in order to Test the Main Thread wait for the rest.
                        }
                    else
                        {
                        break;
                        }

                    } while (AvalibleSpace() == true && AvalibleStationsAndRobots() == true);

                }

            //Console.Read();
            WhareHouseStatusActivity(LStations.Where(x => x.Occupy == false && x.MaxNBoxes >= 1).Count()
                            , LRobots.Where(x => x.Busy == false).Count()
                            , StockWharehouse, LimitMaxonLine); 
            return ER;
            }

        private Servus FindRobotAvalible()
            {
            Servus FoundServus;
            FoundServus = LRobots.Where(x => x.Busy == false).FirstOrDefault();
            return FoundServus;
            }


        /// <summary>
        /// Validates free Production spots in Line in order to send another robot
        /// </summary>
        /// <returns></returns>
        private bool AvalibleSpace()
            {
            return LimitMaxonLine >= 1 ? true : false;
            }
        /// <summary>
        /// Validates if the stations are full.
        /// </summary>
        /// <returns></returns>
        private bool AvalibleStationsAndRobots()
            {
            bool S = LStations.Where(x => x.Occupy == false && x.MaxNBoxes >= 1).ToList().Count >= 1 ? true : false;
            if (S == true)
                {
                if (StockWharehouse >= 1)
                    { 
                    return true;
                    }
                else
                    {
                    WhareHouseNotifyMonitors(string.Format("No Stock avalible..."));
                    return false;
                    }
                }
            else
                {
                WhareHouseNotifyMonitors(string.Format("No Stations avalibles..."));
                return false;
                }

            }

        /// <summary>
        /// Add more Boxes to  Avalible Robots if there is Avaliable Stock.
        /// </summary>
        private void AsignBoxes(Servus tempRob)
            {
            do
                {
                if (StockWharehouse >= 1)
                    {
                    tempRob.NBoxes = tempRob.NBoxes + 1;
                    StockWharehouse = StockWharehouse - 1;
                    }
                else { break; }
                } while (tempRob.NBoxes<BoxperRobot);
            }

        /// <summary>
        /// Process info in order to create the Production.
        /// </summary>
        /// <param name="nRobots"></param>
        /// <param name="nStations"></param>
        /// <param name="nBoxperRobot"></param>
        /// <param name="pBoxLimitsStation"></param>
        /// <param name="StockWharehouse"></param>
        /// <returns></returns>
        private ErrorProduccion CrearProduccion(int nRobots, int nStations, int nBoxperRobot, int pBoxLimitsStation, int StockWharehouse)
            {
            ErrorProduccion ER = new ErrorProduccion("No Pass", false);
            LRobots = new List<Servus>();
            stock = new List<int>();
            LStations = new List<ContainerStation>();
            try
                {

                if (StockWharehouse >= 1)
                    {
                    ER.Reason = "Execution Production"; ER.Pass = true;

                    if (nRobots < 1)
                        {
                        ER.Reason = "No Robots, create a Robot"; ER.Pass = false;
                        }
                    if (nStations < 1)
                        {
                        ER.Reason = "No Stations,No reason to move robots"; ER.Pass = false;
                        }

                    if (ER.Pass == true)
                        {
                        stock = new List<int>();
                        for (int i = 1; i < StockWharehouse; i++)
                            {
                            stock.Add(i);
                            }

                        LRobots = new List<Servus>();
                        for (int i = 0; i < nRobots; i++)
                            {
                            Servus Robot = new Servus(i, 0); 
                            LRobots.Add(Robot);
                            }

                        LStations = new List<ContainerStation>();
                        for (int i = 0; i < nStations; i++)
                            {
                            ContainerStation CS = new ContainerStation(i, pBoxLimitsStation); 
                            LStations.Add(CS);
                            }
                        }
                    }
                else
                    {
                    ER.Reason = "No Stock,No reason to Start"; ER.Pass = false;
                    }
                }
            catch (Exception ex)
                {
                ER.Reason = ex.ToString(); ER.Pass = false;
                }
            return ER;

            }

        /// <summary>
        ///  Subscribed Event Answer Station Disponibility
        ///  Fires the Event to Notify the Monitor.
        /// </summary>
        /// <param name="pOccupy"></param>
        public void NotificarStacionAvalible(int idStation, bool pOccupy, int idRobot, int MaxNBoxes)
            {
            ContainerStation Sin = LStations.Where(x => x.idStation == idStation).FirstOrDefault();
            Sin.Occupy = pOccupy;
            Sin.MaxNBoxes = MaxNBoxes;
            if (pOccupy == true)
                {
                WhareHouseNotifyMonitors(string.Format("                       Robot:{0} Arrive, Station {1}: Busy, ", idRobot.ToString(), Sin.idStation.ToString()));              
                LimitMaxonLine = LimitMaxonLine - 1; 
                }
            else
                {
                WhareHouseNotifyMonitors(string.Format("                       Robot:{0} Leaving Station {1}: Free", idRobot.ToString(), Sin.idStation.ToString()));
                LimitMaxonLine = LimitMaxonLine + 1; 
                }

            }

        /// <summary>
        /// Subscribed Event of The Robots Disponibility.
        /// Fires the Event to Notify the Monitor.
        /// </summary>
        /// <param name="idRobot"></param>
        /// <param name="pOccupy"></param>
        /// <param name="NBoxes"></param>
        public void NotifyRobotActivity(int idRobot, bool pOccupy, int NBoxes)
            {
            Servus Rin = LRobots.Where(x => x.idRobot == idRobot).FirstOrDefault();
            Rin.Busy = pOccupy;
            Rin.NBoxes = NBoxes;
            if (pOccupy == true)
                {
                //Console.WriteLine(string.Format(" Robot:{0} Bussy!", Rin.idRobot.ToString()));
                WhareHouseNotifyMonitors(string.Format(" + Robot {0}: Bussy!", Rin.idRobot.ToString()));
                }
            else
                {
                //Console.WriteLine(string.Format(" Robot:{0} Free!", Rin.idRobot.ToString()));
                WhareHouseNotifyMonitors(string.Format("    + Robot {0}: Free!", Rin.idRobot.ToString()));
                }

            WhareHouseStatusActivity(LStations.Where(x => x.Occupy == false && x.MaxNBoxes >= 1).Count()
                , LRobots.Where(x => x.Busy == false && x.NBoxes >= 1).Count()
                , StockWharehouse, LimitMaxonLine);
            }

        }
    }
