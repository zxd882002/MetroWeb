using System;
using System.Collections.Generic;
using System.Linq;
using DatabaseAccessLibrary.Model;

namespace MetroWebLibrary
{
    internal class StationEntityExtender : StationEntity
    {
        internal List<StationLineEntity> PossibleCurrentStationLineList { get; set; }
        internal TimeSpan MinimumArrivedTime { get; set; }
        internal Queue<StationEntityExtender> MinimumRouteList { get; set; }

        internal StationEntityExtender(StationEntity station)
            : base(station.MetroWeb, station.Station)
        {
            PossibleCurrentStationLineList = new List<StationLineEntity>();
            MinimumRouteList = new Queue<StationEntityExtender>();
        }

        internal static StationEntityExtender Convert(StationEntity station, List<StationEntityExtender> stationExterderCacheList)
        {
            StationEntityExtender stationExtender = stationExterderCacheList.Find(stationExterderCache => stationExterderCache.StationId == station.StationId);
            if (stationExtender == null)
            {
                stationExtender = new StationEntityExtender(station);
                stationExterderCacheList.Add(stationExtender);
            }
            return stationExtender;
        }

        internal void GetTheMinimumRouter(StationEntityExtender fromStationExtender, Stack<StationEntityExtender> StationStack, List<StationEntityExtender> stationExtenderCacheList)
        {
            if(this.StationId == 106)
            {}//debug

            // if the station has already been in the stack, exlude it
            if (StationStack.Contains(this))
            {
                MinimumArrivedTime = new TimeSpan(TimeSpan.MaxValue.Ticks / 2);
                MinimumRouteList = null;
                return;
            }

            // if the StationStack count is greater than 50, this route is definitly not a nearest route
            if(StationStack.Count >= 50)
            {
                MinimumArrivedTime = new TimeSpan(TimeSpan.MaxValue.Ticks / 2);
                MinimumRouteList = null;
                return;
            }

            // get current stationLine
            if (StationStack.Count > 0)
            {
                List<StationLineEntity> currentStationLineList = this.StationLineList;
                foreach (StationLineEntity currentStationLine in currentStationLineList)
                {
                    if (currentStationLine.NextStationLine != null && currentStationLine.NextStationLine.Station.StationId == StationStack.Peek().StationId)
                    {
                        PossibleCurrentStationLineList.Add(currentStationLine);
                    }
                }
            }

            // find one route
            if (this == fromStationExtender)
            {
                MinimumArrivedTime = new TimeSpan((PossibleCurrentStationLineList.Min(stationLine => stationLine.TimeWait).Ticks) / 2); // average time
                MinimumRouteList.Enqueue(this);
                return;
            }

            // get previous station list
            List<StationLineEntity> previousStationLineList = GetPreviousStationList();
            List<StationLineEntity> transferStationLineList = GetTransferStattionList();

            // this way is not correct
            if (previousStationLineList.Count == 0 && transferStationLineList.Count == 0)
            {
                MinimumArrivedTime = new TimeSpan(TimeSpan.MaxValue.Ticks / 2);
                MinimumRouteList = null;
                return;
            }

            // find the minimum route from previous station line list
            MinimumArrivedTime = new TimeSpan(TimeSpan.MaxValue.Ticks / 2);
            foreach (StationLineEntity previousStationLine in previousStationLineList)
            {
                StationStack.Push(this);
                StationEntityExtender previousStationExtender = Convert(previousStationLine.Station, stationExtenderCacheList);
                previousStationExtender.GetTheMinimumRouter(fromStationExtender, StationStack, stationExtenderCacheList);
                StationStack.Pop();

                // get current route arrived time
                TimeSpan timeArrivedToCurrentStation = previousStationExtender.MinimumArrivedTime + GetTimeArrived(previousStationLine.NextStationLine, false);

                // if is minimum then
                if (timeArrivedToCurrentStation < MinimumArrivedTime)
                {
                    // log time
                    MinimumArrivedTime = timeArrivedToCurrentStation;

                    // log route
                    MinimumRouteList = previousStationExtender.MinimumRouteList;
                    MinimumRouteList.Enqueue(this);
                }
            }

            // find the minimum route from transfer station line list
            foreach (StationLineEntity transferStationLine in transferStationLineList)
            {
                StationStack.Push(this);
                StationEntityExtender transferStationExtender = Convert(transferStationLine.Station, stationExtenderCacheList);
                transferStationExtender.GetTheMinimumRouter(fromStationExtender, StationStack, stationExtenderCacheList);
                StationStack.Pop();

                // get current route arrived time
                TimeSpan timeArrivedToCurrentStation = transferStationExtender.MinimumArrivedTime + GetTimeArrived(transferStationLine.NextStationLine, true);

                // if is minimum then
                if (timeArrivedToCurrentStation < MinimumArrivedTime)
                {
                    // log time
                    MinimumArrivedTime = timeArrivedToCurrentStation;

                    // log route
                    MinimumRouteList = transferStationExtender.MinimumRouteList;
                    MinimumRouteList.Enqueue(this);
                }
            }
        }

        private List<StationLineEntity> GetPreviousStationList()
        {
            List<StationLineEntity> previouStationLineList = new List<StationLineEntity>();

            if (PossibleCurrentStationLineList.Count == 0)
            {
                List<StationLineEntity> currentStationLineList = this.StationLineList;
                foreach (StationLineEntity currentStationLine in currentStationLineList)
                {
                    StationLineEntity previousStationLine = currentStationLine.PreviousStationLine;

                    if (previousStationLine != null && !previouStationLineList.Contains(previousStationLine))
                        previouStationLineList.Add(previousStationLine);
                }
            }
            else
            {
                foreach (StationLineEntity possibleCurrentStationLine in PossibleCurrentStationLineList)
                {
                    StationLineEntity previousStationLine = possibleCurrentStationLine.PreviousStationLine;

                    if (previousStationLine != null && !previouStationLineList.Contains(previousStationLine))
                        previouStationLineList.Add(previousStationLine);
                }
            }
            return previouStationLineList;
        }

        private List<StationLineEntity> GetTransferStattionList()
        {
            List<StationLineEntity> transferStationLineList = new List<StationLineEntity>();

            if (PossibleCurrentStationLineList.Count != 0)
            {
                List<StationLineEntity> currentStationLineList = this.StationLineList;
                foreach (StationLineEntity currentStationLine in currentStationLineList)
                {
                    if (PossibleCurrentStationLineList.Contains(currentStationLine))
                    {
                        List<MetroTransferEntity> transferStationList = currentStationLine.TransferFromList;
                        foreach (var transferStation in transferStationList)
                        {
                            StationLineEntity transferStationLine = transferStation.FromStationLine.PreviousStationLine;
                            if (transferStationLine != null && !transferStationLineList.Contains(transferStationLine))
                                transferStationLineList.Add(transferStationLine);
                        }
                    }
                }
            }
            return transferStationLineList;
        }

        private TimeSpan GetTimeArrived(StationLineEntity stationLine, bool calculateWaitTime)
        {
            if (calculateWaitTime)
            {
                TimeSpan minTransferTime = new TimeSpan(TimeSpan.MaxValue.Ticks / 2);

                foreach (MetroTransferEntity transferTo in stationLine.TransferToList)
                {
                    if (PossibleCurrentStationLineList.Contains(transferTo.ToStationLine))
                    {
                        TimeSpan transferTime = transferTo.TimeTransfer;
                        if (transferTime < minTransferTime)
                        {
                            minTransferTime = transferTime;
                        }
                    }
                }

                return stationLine.TimeArrived + minTransferTime + new TimeSpan(stationLine.TimeWait.Ticks / 2);
            }
            else
            {
                return stationLine.TimeArrived;
            }

        }
    }

    public class StationEntityHelper
    {
        private List<StationEntityExtender> stationEntityExtenderList;

        public Tuple<List<StationEntity>, TimeSpan> GetTheNearestRouteBetween(StationEntity fromStation, StationEntity toStation)
        {
            List<StationEntityExtender> stationExtenderList = new List<StationEntityExtender>();
            StationEntityExtender fromStationExtender = StationEntityExtender.Convert(fromStation, stationExtenderList);
            StationEntityExtender toStationExtender = StationEntityExtender.Convert(toStation, stationExtenderList);

            toStationExtender.GetTheMinimumRouter(fromStationExtender, new Stack<StationEntityExtender>(), stationExtenderList);

            return new Tuple<List<StationEntity>, TimeSpan>(
                toStationExtender.MinimumRouteList.Select(route => route as StationEntity).ToList(),
                toStationExtender.MinimumArrivedTime);
        }
    }
}
