using System;
using System.Collections.Generic;
using System.Linq;

namespace MetroWebLibrary
{
    internal class StationLineEntityExtender : StationLineEntity
    {
        public TimeSpan MinimumTime { get; set; }
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
            StationLineEntityExtender stationLineExtender = stationLineListCache.Find(cache => cache.StationLineId == stationLine.StationLineId);
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

        private TimeSpan CalculateTimeCost(StationLineEntityExtender from, StationLineEntityExtender to, List<StationLineEntityExtender> stationLineListCache)
        {
            // Get 'to' previous station lines, and find the station which is the same as the 'from'
            List<StationLineEntityExtender> toPreviousStationLineList = new List<StationLineEntityExtender>();
            toPreviousStationLineList.Add(to);
            toPreviousStationLineList.AddRange(to.PreviousStationLineList.Select(sl => Convert(sl, stationLineListCache)).ToList());
            
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

        internal bool FullyGetRoute(StationEntity fromStation, List<StationLineEntityExtender> stationLineListCache, TimeSpan arrivedTimeLimit, Stack<StationLineEntityExtender> stationLineExtenderStatck)
        {
            // if current StationLine is the from staiton, return true
            if (this.Station == fromStation)
            {
                MinimumTime = new TimeSpan(TimeWait.Ticks / 2);
                MinimumRoute.Add(this);
                return true;
            }

            // if current stationline is the end station, return false
            StationLineEntityExtender previousStationLineExtender = null;
            if (this.PreviousStationLine != null)
            {
                previousStationLineExtender = Convert(this.PreviousStationLine, stationLineListCache);
                if (stationLineExtenderStatck.Contains(previousStationLineExtender)) // avoid death loop
                    previousStationLineExtender = null;
            }

            List<StationLineEntityExtender> transferStationLineExtenderList = this.TransferFromList.Select(
                metroTransfer => Convert(metroTransfer.FromStationLine, stationLineListCache)).ToList();
            for (int i = transferStationLineExtenderList.Count - 1; i >= 0; i--) // avoid death loop
            {
                if (stationLineExtenderStatck.Contains(transferStationLineExtenderList[i]))
                    transferStationLineExtenderList.RemoveAt(i);
            }

            if (previousStationLineExtender == null && transferStationLineExtenderList.Count == 0)
            {
                return false;
            }

            // if the previouStationLine is not the 'from' station, and the minmimum arrived time is greater than newArrivedTimeLimit, so we don't need to go further
            bool finalResult = false;
            if (previousStationLineExtender != null)
            {
                TimeSpan newArrivedTimeLimit = arrivedTimeLimit - this.TimeArrived;
                TimeSpan previousStationLineArrivedMin = previousStationLineExtender.TimeArrived;

                foreach (MetroTransferEntity metroTransfer in previousStationLineExtender.TransferFromList)
                {
                    if (Convert(metroTransfer.ToStationLine, stationLineListCache) == previousStationLineExtender)
                    {
                        TimeSpan transferCost = metroTransfer.TimeTransfer + new TimeSpan(previousStationLineExtender.TimeWait.Ticks / 2);
                        previousStationLineArrivedMin = previousStationLineArrivedMin > transferCost ? transferCost : previousStationLineArrivedMin;
                    }
                }


                if (previousStationLineExtender.Station == fromStation || previousStationLineArrivedMin <= newArrivedTimeLimit)
                {
                    // get previous station FullyGetRoute
                    stationLineExtenderStatck.Push(this);
                    bool found = previousStationLineExtender.FullyGetRoute(fromStation, stationLineListCache, newArrivedTimeLimit, stationLineExtenderStatck);
                    stationLineExtenderStatck.Pop();

                    if (found)
                    {
                        // compare whether current route is the minimum route
                        TimeSpan arriveTimeCost = previousStationLineExtender.MinimumTime + TimeArrived;
                        if (arriveTimeCost < MinimumTime)
                        {
                            MinimumTime = arriveTimeCost;
                            MinimumRoute = previousStationLineExtender.MinimumRoute;
                            MinimumRoute.Add(this);
                        }
                        finalResult = true;
                    }
                }
            }

            // if the transferStation is not the 'from' station, and the minmimum arrived time is greater than newArrivedTimeLimit, so we don't need to go further
            foreach (StationLineEntityExtender transferStationLine in transferStationLineExtenderList)
            {
                List<MetroTransferEntity> toMetroTransferList = transferStationLine.TransferToList;
                MetroTransferEntity metroTransfer = toMetroTransferList.Find(mt => Convert(mt.ToStationLine, stationLineListCache) == this);
                if (metroTransfer == null)
                {
                    throw new Exception("Cannot find the transfer data, something wrong?!");
                }
                TimeSpan transferTimeCost = metroTransfer.TimeTransfer + new TimeSpan(this.TimeWait.Ticks / 2);
                TimeSpan newArrivedTimeLimit = arrivedTimeLimit - transferTimeCost;
                TimeSpan transferStationLineArrivedMin = transferStationLine.TimeArrived;

                foreach (MetroTransferEntity transferMetroTransfer in transferStationLine.TransferFromList)
                {
                    if (Convert(metroTransfer.ToStationLine, stationLineListCache) == transferStationLine)
                    {
                        TimeSpan transferCost = transferMetroTransfer.TimeTransfer + new TimeSpan(transferStationLine.TimeWait.Ticks / 2);
                        transferStationLineArrivedMin = transferStationLineArrivedMin > transferCost ? transferCost : transferStationLineArrivedMin;
                    }
                }

                if (transferStationLine.Station == fromStation || transferStationLineArrivedMin <= newArrivedTimeLimit)
                {
                    // get transfer station
                    stationLineExtenderStatck.Push(this);
                    bool found = transferStationLine.FullyGetRoute(fromStation, stationLineListCache, newArrivedTimeLimit, stationLineExtenderStatck);
                    stationLineExtenderStatck.Pop();

                    if (found)
                    {
                        // compare whether current route is the minimum route
                        TimeSpan arriveTimeCost = transferStationLine.MinimumTime + TimeArrived + transferTimeCost;
                        if (arriveTimeCost < MinimumTime)
                        {
                            MinimumTime = arriveTimeCost;
                            MinimumRoute = transferStationLine.MinimumRoute;
                            MinimumRoute.Add(this);
                        }
                        finalResult = true;
                    }
                }
            }

            return finalResult;
        }
    }
}
