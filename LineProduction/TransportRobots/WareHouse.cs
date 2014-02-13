using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace TransportRobots
    {
    public class WareHouse
        {
        private List<int> stock { get; set; }
        private List<Robot> LRobots { get; set; }
        private List<Station> LStations { get; set; }
        private static int BoxLimits;
        private static int Robots;
        private static int Stations;
        private static int BoxperRobot;
        private static int BoxLimitsStation;
        private static int StockWharehouse;
        private static int LimitMaxonLine;

        /// <summary>
        /// Especify all Inputs  for 
        /// </summary>
        /// <param name="nRobots"></param>
        /// <param name="nStations"></param>
        public WareHouse(int nRobots, int nStations, int nBoxperRobot, int pBoxLimitsStation, int pStockWharehouse, int pLimitMaxonLine)
            {
            Robots = nRobots;
            Stations = nStations;
            BoxperRobot = nBoxperRobot;
            BoxLimitsStation = pBoxLimitsStation;
            StockWharehouse = pStockWharehouse;
            LimitMaxonLine = pLimitMaxonLine;
            }
        /// <summary>
        /// Executes Program
        /// </summary>
        /// <returns></returns>
        public ErrorProduccion Start()
            {

            ErrorProduccion ER = CrearProduccion(Robots, Stations, BoxperRobot, BoxLimitsStation, StockWharehouse);

            Console.WriteLine(ER.Reason);
            if (ER.Pass)
                {
                do
                    {
                    //Console.WriteLine(string.Format("Number of Boxes {0}", StockWharehouse.ToString()));
                    //Console.WriteLine(string.Format("Number of Avalible Robots {0}", LRobots.Where(x => x.Busy == false && x.NBoxes >= 1).Count().ToString()));
                    //Console.WriteLine(string.Format("Number of Avalible Stations {0} ", LStations.Where(x => x.Occupy == false && x.MaxNBoxes >= 1).Count().ToString()));
                    //Console.WriteLine(string.Format("Number of Avalible Lines {0}", LimitMaxonLine.ToString()));
                   
                    if (LRobots.Where(x => x.Busy == false && x.NBoxes >= 1).ToList().Count >= 1 ? true : false)
                        {
                        foreach (var iRobot in LRobots.Where(x => x.Busy == false && x.NBoxes >= 1).ToList())
                            {
                            Robot tempRob = new Robot() { Busy = iRobot.Busy, idRobot = iRobot.idRobot, NBoxes = iRobot.NBoxes, NSiguientePosicion = iRobot.NSiguientePosicion };

                            Console.WriteLine(string.Format("Send Robot:{0} ", tempRob.idRobot.ToString()));
                            ///Code SendRobot
                            Station iStation = LStations.Where(x => x.Occupy == false && x.MaxNBoxes >= 1).FirstOrDefault();
                            Station tempStation = new Station() { Occupy = iStation.Occupy, idStation = iStation.idStation, MaxNBoxes = iStation.MaxNBoxes };

                            iRobot.NSiguientePosicion = tempStation.idStation;
                            tempStation.RobotActivity += new Station.delRobot(NotificarArriveRobot);
                            tempStation.StationActivity += new Station.delStation(NotificarSpotAvalible); 
                            ///
                            Thread T = new Thread(() =>  tempStation.ArriveRobot(iRobot));
                            T.Start();
                           T.Join();
                            }
                        }// Thread.Sleep(2000); 
                    } while (AvalibleSpace() == true && AvalibleStationsAndRobots() == true);
                }

            //Thread.Sleep(2000); 
            Console.WriteLine(string.Format("Number of Avalible Stock {0}", StockWharehouse.ToString()));
            Console.WriteLine(string.Format("Number of Avalible Robots {0}", LRobots.Where(x => x.Busy == false && x.NBoxes >= 1).Count().ToString()));
            Console.WriteLine(string.Format("Number of Avalible Stations {0} ", LStations.Where(x => x.Occupy == false && x.MaxNBoxes >= 1).Count().ToString()));
            Console.WriteLine(string.Format("Number of Avalible Lines {0}", LimitMaxonLine.ToString()));
            Console.WriteLine(string.Format("Process Finished, Total Emty spaces on Stations {0}.", LStations.Select(x => x.MaxNBoxes).Sum().ToString()));
            Console.Read();
            return ER;
            }


        /// <summary>
        /// Validates spaces to send another robot
        /// </summary>
        /// <returns></returns>
        private bool AvalibleSpace()
            {
            return LimitMaxonLine >= 1 ? true : false;
            }
        /// <summary>
        /// Validates if the stations ar full and if they are Not look to asign more Boxes.
        /// </summary>
        /// <returns></returns>
        private bool AvalibleStationsAndRobots()
            {
            bool S = LStations.Where(x => x.Occupy == false && x.MaxNBoxes >= 1).ToList().Count >= 1 ? true : false;
            if (S == true)
                {
                // && LRobots.Where(x => x.Busy == false && x.NBoxes <= 0).ToList().Count >= 1
                if (StockWharehouse >= 2)
                        {
                      AsignarCajas();
                        return true;
                        }
                    else
                        {
                        Console.WriteLine(string.Format("No Stock avalible..."));
                        return false;
                        }
             
                }
            else
                {// NO Stations Avalible
                Console.WriteLine(string.Format("No stations avalibles..."));
                return false;
                }

            }

        /// <summary>
        /// Add more Boxes to  Avalible Robots if there is Avaliable Stock.
        /// </summary>
        private void AsignarCajas()
            {
            if (StockWharehouse >= 2 && LRobots.Where(x => x.Busy == false && x.NBoxes <= 0).ToList().Count >= 1)
                { 
                Console.WriteLine(string.Format("Asignando Cajas..."));
                foreach (var iRobot in LRobots.Where(x => x.Busy == false && x.NBoxes <= 0).ToList())
                    {
                    iRobot.NBoxes = 2;
                    StockWharehouse = StockWharehouse - iRobot.NBoxes;
                    if (!(StockWharehouse >= 2))
                        break; 
                    }
                }
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
            try
                {

                if (StockWharehouse >= 1)
                    {
                    ER.Reason = "Execution Production"; ER.Pass = true;

                    if (nRobots <= 1)
                        {
                        ER.Reason = "No Robots, create a Robot"; ER.Pass = false;
                        }
                    if (nStations <= 1)
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

                        LRobots = new List<Robot>();
                        for (int i = 0; i < nRobots; i++)
                            {
                            LRobots.Add(new Robot(i, nBoxperRobot));
                            }

                        LStations = new List<Station>();
                        for (int i = 0; i < nStations; i++)
                            {
                            LStations.Add(new Station(i, pBoxLimitsStation));
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
        /// Send CUrrent Robot to look For an avalible Station.
        /// </summary>
        /// <param name="iRobot"></param>
        private void SendNewRobot(Robot iRobot)
            { 

            do
                {
                Station iStation = LStations.Where(x => x.Occupy == false && x.MaxNBoxes >= 1).FirstOrDefault();
                Station tempStation = new Station() { Occupy = iStation.Occupy, idStation = iStation.idStation, MaxNBoxes = iStation.MaxNBoxes };

                iRobot.NSiguientePosicion = tempStation.idStation;
                tempStation.RobotActivity += new Station.delRobot(NotificarArriveRobot);
                tempStation.StationActivity += new Station.delStation(NotificarSpotAvalible);
                tempStation.ArriveRobot(iRobot);
                } while (AvalibleBoxes(iRobot));
            }
        /// <summary>
        /// return if the Robot Contains more Boxes
        /// </summary>
        /// <param name="iRobot"></param>
        /// <returns></returns>
        private bool AvalibleBoxes(Robot iRobot)
            {
            return iRobot.NBoxes >= 1 ? true : false;
            }

        /// <summary>
        /// wait event answer Robot Disponibility
        /// </summary>
        /// <param name="iRobot"></param>
        /// <param name="pOccupy"></param>
        private void NotificarArriveRobot(Robot iRobot, bool pOccupy)
            {
            Robot Rin = LRobots.Where(x => x.idRobot == iRobot.idRobot).FirstOrDefault();
            Rin.Busy = pOccupy;
            Rin.NBoxes = iRobot.NBoxes;
            if (pOccupy == true)
                {
                Console.WriteLine(string.Format(" Robot:{0} Bussy!", Rin.idRobot.ToString()));
                }
            else
                {
                Console.WriteLine(string.Format(" Robot:{0} Free!", Rin.idRobot.ToString()));
                }

            }

        /// <summary>
        /// Waits Event Answer Station Disponibility
        /// </summary>
        /// <param name="pOccupy"></param>
        private void NotificarSpotAvalible(Station istation, bool pOccupy)
            {
            Station Sin = LStations.Where(x => x.idStation == istation.idStation).FirstOrDefault();
            Sin.Occupy = pOccupy;
            Sin.MaxNBoxes = istation.MaxNBoxes;

            if (pOccupy == true)
                {
                LimitMaxonLine = LimitMaxonLine - 1;
                Console.WriteLine(string.Format(" Station:{0} Bussy!", Sin.idStation.ToString()));
                }
            else
                {
                LimitMaxonLine = LimitMaxonLine + 1;
                Console.WriteLine(string.Format(" Station:{0} Free!", Sin.idStation.ToString()));
                }
            }


        }
    }
