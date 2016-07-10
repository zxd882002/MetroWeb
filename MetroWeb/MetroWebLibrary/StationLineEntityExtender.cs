using System;
using System.Collections.Generic;
using System.Linq;

namespace MetroWebLibrary
{
    internal class StationLineEntityExtender : StationLineEntity
    {
        public TimeSpan MinimumTime { get; set; }
        public int TransferTimes { get; set; }
        public List<StationLineEntity> MinimumRoute { get; set; }

        internal StationLineEntityExtender(StationLineEntity stationLine)
            : base(stationLine.MetroWeb, stationLine.StationLine)
        {
            Initialize();
        }

        internal static List<StationLineEntityExtender> Convert(StationEntity station, List<StationLineEntityExtender> stationLineListCache)
        {
            List<StationLineEntity> stationLineList = station.StationLineList;
            List<StationLineEntityExtender> stationLineExtenderList = new List<StationLineEntityExtender>();
            foreach (StationLineEntity stationLine in stationLineList)
            {
                stationLineExtenderList.Add(Convert(stationLine, stationLineListCache));
            }

            return stationLineExtenderList;
        }

        internal static StationLineEntityExtender Convert(StationLineEntity stationLine, List<StationLineEntityExtender> stationLineListCache)
        {
            StationLineEntityExtender stationLineExtender = stationLineListCache.Find(stationLineCache => stationLineCache.StationLineId == stationLine.StationLineId);
            if (stationLineExtender != null)
            {
                return stationLineExtender;
            }
            else
            {
                stationLineExtender = new StationLineEntityExtender(stationLine);
                stationLineListCache.Add(stationLineExtender);
                return stationLineExtender;
            }
        }

        internal void Initialize()
        {
            MinimumTime = new TimeSpan(TimeSpan.MaxValue.Ticks / 2);
            TransferTimes = 0;
            MinimumRoute = new List<StationLineEntity>();
        }

        internal bool QuickGetRoute(StationEntity fromStation, List<StationLineEntityExtender> stationLineListCache)
        {
            List<Tuple<StationLineEntityExtender, int>> routeTree = new List<Tuple<StationLineEntityExtender, int>>();
            routeTree.Add(new Tuple<StationLineEntityExtender, int>(this, -1));

            bool found = GenerateRouteTree(fromStation, stationLineListCache, routeTree);
            if (!found)
            {
                return false;
            }

            List<StationLineEntityExtender> route = GenerateRoute(routeTree);

            // calculate the time
            int index = 0;
            TimeSpan totalCost = new TimeSpan(route[0].TimeWait.Ticks / 2);
            while (index + 1 < route.Count)
            {
                TimeSpan cost = CalculateTimeCost(route[index], route[index + 1], stationLineListCache);
                totalCost += cost;
                index++;
            }
            this.MinimumTime = totalCost;

            return true;
        }

        private bool GenerateRouteTree(StationEntity fromStation, List<StationLineEntityExtender> stationLineListCache, List<Tuple<StationLineEntityExtender, int>> routeTree)
        {
            int index = 0;
            while (index < routeTree.Count)
            {
                StationLineEntityExtender currentStationLineExtender = routeTree[index].Item1;
                List<StationLineEntity> currentStationLinePreviousStationLineList = currentStationLineExtender.PreviousStationLineList;

                StationLineEntity fromStationLine = currentStationLinePreviousStationLineList.Find(
                    currentStationLinePreviousStationLine => currentStationLinePreviousStationLine.Station == fromStation);

                if (fromStationLine != null)
                {
                    // found
                    StationLineEntityExtender fromStationLineExtender = Convert(fromStationLine, stationLineListCache);
                    routeTree.Add(new Tuple<StationLineEntityExtender, int>(fromStationLineExtender, index));
                    return true;
                }
                else
                {
                    // not found
                    foreach (StationLineEntity currentStationLinePreviousStationLine in currentStationLinePreviousStationLineList)
                    {
                        if (currentStationLinePreviousStationLine.Station.StationId == 101)
                        {
                        }

                        List<MetroTransferEntity> transferFromList = currentStationLinePreviousStationLine.TransferFromList;
                        foreach (MetroTransferEntity transferFrom in transferFromList)
                        {
                            StationLineEntity transferFromStationLine = transferFrom.FromStationLine;
                            StationLineEntityExtender transferFromStationLineExtender = Convert(transferFromStationLine, stationLineListCache);
                            if (!routeTree.Exists(stationLine => stationLine.Item1 == transferFromStationLineExtender))
                            {
                                routeTree.Add(new Tuple<StationLineEntityExtender, int>(transferFromStationLineExtender, index));
                            }
                        }
                    }
                }

                index++;
            }
            return false;
        }

        private List<StationLineEntityExtender> GenerateRoute(List<Tuple<StationLineEntityExtender, int>> routeTree)
        {
            List<StationLineEntityExtender> route = new List<StationLineEntityExtender>();
            int index = routeTree.Count - 1;
            while (index != -1)
            {
                route.Add(routeTree[index].Item1);
                index = routeTree[index].Item2;
            }
            return route;
        }

        internal bool FullyGetRoute(StationEntity fromStation, List<StationLineEntityExtender> stationLineListCache, TimeSpan arrivedTimeLimit)
        {
            throw new NotImplementedException();
        }

        private TimeSpan CalculateTimeCost(StationLineEntityExtender from, StationLineEntityExtender to, List<StationLineEntityExtender> stationLineListCache)
        {
            // Get 'to' previous station lines, and find the station which is the same as the 'from'
            List<StationLineEntityExtender> toPreviousStationLineList = to.PreviousStationLineList.Select(sl => Convert(sl, stationLineListCache)).ToList();
            Stack<StationLineEntityExtender> fromFromToToStationLineStack = new Stack<StationLineEntityExtender>();
            foreach (StationLineEntityExtender toPreviousStationLine in toPreviousStationLineList)
            {
                if (toPreviousStationLine.Station != from.Station)
                {
                    fromFromToToStationLineStack.Push(toPreviousStationLine);
                }
                else
                {
                    fromFromToToStationLineStack.Push(toPreviousStationLine);
                    break;
                }
            }

            if (from.Station != fromFromToToStationLineStack.Peek().Station)
            {
                throw new Exception("From 'from' to 'to' is not in the same line");
            }

            // Calculate the time from 'from' to 'to'
            StationLineEntityExtender transferedLine = fromFromToToStationLineStack.Peek();
            bool isTransfered = (from != transferedLine);
            TimeSpan transferTimeCost = new TimeSpan();
            if (isTransfered)
            {
                List<MetroTransferEntity> toMetroTransferList = from.TransferToList;
                MetroTransferEntity metroTransfer = toMetroTransferList.Find(mt => Convert(mt.ToStationLine, stationLineListCache) == transferedLine);
                if (metroTransfer == null)
                {
                    throw new Exception("Cannot find the transfer data");
                }
                transferTimeCost = metroTransfer.TimeTransfer + new TimeSpan(transferedLine.TimeWait.Ticks / 2);
            }

            TimeSpan arrivedTimeCost = new TimeSpan();
            fromFromToToStationLineStack.Pop(); // no need to check the first line, if it is transfered, we have already calculated. if not, the arrive time is zero.
            while (fromFromToToStationLineStack.Count > 0)
            {
                StationLineEntity stationline = fromFromToToStationLineStack.Pop();
                arrivedTimeCost += stationline.TimeArrived;
            }

            return transferTimeCost + arrivedTimeCost;
        }
    }
}
