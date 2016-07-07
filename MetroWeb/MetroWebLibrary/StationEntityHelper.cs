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

        internal StationEntityExtender(MetroWebEntity webEntity, Station station) : base(webEntity, station) { }

        internal void GetTheMinimumRouter(StationEntityExtender fromStationExtender, Stack<StationEntityExtender> StationStack)
        {
            // if the station has already been in the stack, exlude it
            if (StationStack.Contains(this))
            {
                MinimumArrivedTime = new TimeSpan(TimeSpan.MaxValue.Ticks / 2);
                MinimumRouteList = null;
                return;
            }

            // get current stationLine
            if (StationStack.Count > 0)
            {
                PossibleCurrentStationLineList = new List<StationLineEntity>();
                List<StationLineEntity> currentStationLineList = this.StationLineList;
                foreach (StationLineEntity currentStationLine in currentStationLineList)
                {
                    if (currentStationLine.NextStationLine.Station as StationEntityExtender == StationStack.Peek())
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
                MinimumArrivedTime = TimeSpan.MaxValue;
                MinimumRouteList = null;
                return;
            }

            // find the minimum route from previous station line list
            MinimumArrivedTime = TimeSpan.MaxValue;
            foreach (StationLineEntity previousStationLine in previousStationLineList)
            {
                StationStack.Push(this);
                StationEntityExtender previousStationExtender = previousStationLine.Station as StationEntityExtender;
                previousStationExtender.GetTheMinimumRouter(fromStationExtender, StationStack);
                StationStack.Pop();

                // get current route arrived time
                TimeSpan timeArrivedToCurrentStation = GetTimeArrived(previousStationLine, false);

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
                StationEntityExtender transferStationExtender = transferStationLine.Station as StationEntityExtender;
                transferStationExtender.GetTheMinimumRouter(fromStationExtender, StationStack);
                StationStack.Pop();

                // get current route arrived time
                TimeSpan timeArrivedToCurrentStation = GetTimeArrived(transferStationLine, true);

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

                    if (!previouStationLineList.Contains(previousStationLine))
                        previouStationLineList.Add(previousStationLine);
                }
            }
            else
            {
                foreach (StationLineEntity possibleCurrentStationLine in PossibleCurrentStationLineList)
                {
                    StationLineEntity previousStationLine = possibleCurrentStationLine.PreviousStationLine;

                    if (!previouStationLineList.Contains(previousStationLine))
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
                    if (!PossibleCurrentStationLineList.Contains(currentStationLine))
                    {
                        List<MetroTransferEntity> transferStationList = currentStationLine.TransferFromList;
                        foreach (var transferStation in transferStationList)
                        {
                            StationLineEntity transferStationLine = transferStation.FromStationLine;
                            if (!transferStationLineList.Contains(transferStationLine))
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
                foreach (var possibleCurrentStationLine in PossibleCurrentStationLineList)
                {
                    TimeSpan transferTime = MetroWebEntity.Instance().MetroTransferList[stationLine.StationLineId, possibleCurrentStationLine.StationLineId].TimeTransfer;
                    if (transferTime < minTransferTime)
                    {
                        minTransferTime = transferTime;
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

        internal Tuple<List<StationEntity>, TimeSpan> GetTheNearestRouteBetween(StationEntity fromStation, StationEntity toStation)
        {
            StationEntityExtender fromStationExtender = fromStation as StationEntityExtender;
            StationEntityExtender toStationExtender = toStation as StationEntityExtender;
            toStationExtender.GetTheMinimumRouter(fromStationExtender, new Stack<StationEntityExtender>());

            return new Tuple<List<StationEntity>, TimeSpan>(
                toStationExtender.MinimumRouteList.Select(route => route as StationEntity).ToList(),
                toStationExtender.MinimumArrivedTime);
        }
    }
}
