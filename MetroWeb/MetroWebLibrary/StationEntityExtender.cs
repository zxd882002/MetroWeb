using System;
using System.Collections.Generic;
using System.Linq;

namespace MetroWebLibrary
{
    internal class StationEntityExtender : StationEntity
    {
        internal List<StationLineEntity> PossibleCurrentStationLineList { get; set; }
        internal TimeSpan MinimumArrivedTime { get; set; }
        internal Queue<StationEntityExtender> MinimumRouteList { get; set; }
        internal Stack<StationEntityExtender> StationStack { get; set; }
        internal bool? FinalResult { get; set; }
        internal int TransferLineCount { get; set; }

        internal StationEntityExtender(StationEntity station)
            : base(station.MetroWeb, station.Station)
        {
            PossibleCurrentStationLineList = new List<StationLineEntity>();
            MinimumRouteList = new Queue<StationEntityExtender>();
            StationStack = new Stack<StationEntityExtender>();
            FinalResult = null;
            TransferLineCount = 1;
        }

        internal static StationEntityExtender Convert(StationEntity station, List<StationEntityExtender> stationExtenderCacheList)
        {
            StationEntityExtender stationExtender = stationExtenderCacheList.Find(stationExterderCache => stationExterderCache.StationId == station.StationId);
            if (stationExtender == null)
            {
                stationExtender = new StationEntityExtender(station);
                stationExtenderCacheList.Add(stationExtender);
            }
            return stationExtender;
        }

        private List<LineEntity> checkedLineList;
        List<Tuple<StationLineEntity, int>> stationTree;
        internal bool QuickGetRouter(StationEntityExtender fromStationExtender, List<StationEntityExtender> stationExtenderCacheList, TimeSpan minimumArrivedTimeLimit)
        {
            // initialize station list
            int index = -1;
            checkedLineList = new List<LineEntity>();
            stationTree = new List<Tuple<StationLineEntity, int>>();
            foreach (StationLineEntity stationLine in StationLineList)
            {
                stationTree.Add(new Tuple<StationLineEntity, int>(stationLine, index));
            }

            // go through the index
            index = 0;
            while (index < stationTree.Count)
            {
                StationLineEntity currentStationLine = stationTree[index].Item1;

                // check current station line list
                if (checkedLineList.Contains(currentStationLine.Line))
                {
                    index++;
                    continue;
                }
                else
                {
                    checkedLineList.Add(currentStationLine.Line);
                }

                List<StationEntityExtender> stationExtenderList =
                    currentStationLine.Line.StationList.Select(station => Convert(station, stationExtenderCacheList)).ToList();
                if (stationExtenderList.Contains(fromStationExtender))
                {
                    stationTree.Add(new Tuple<StationLineEntity, int>(
                        fromStationExtender.StationLineList.Find(stationline => stationline.Line == stationTree[index].Item1.Line), index));
                    break;
                }
                else
                {
                    // generate inter change stationLines
                    foreach (StationEntityExtender stationExtender in stationExtenderList)
                    {
                        foreach (StationLineEntity stationLine in stationExtender.StationLineList)
                        {
                            foreach (MetroTransferEntity transferFrom in stationLine.TransferFromList)
                            {
                                if (!stationTree.Exists(tuple => tuple.Item1 == transferFrom.FromStationLine))
                                    stationTree.Add(new Tuple<StationLineEntity, int>(transferFrom.FromStationLine, index));
                            }
                        }
                    }
                    index++;
                }
            }

            // get the route by index
            List<StationLineEntity> route = new List<StationLineEntity>();
            index = stationTree.Count - 1;
            while (index != -1)
            {
                route.Add(stationTree[index].Item1);
                index = stationTree[index].Item2;
            }

            // calculate time
            index = 0;
            TimeSpan timeCost = new TimeSpan(0);
            bool firstTime = true;
            while (index + 1 < route.Count)
            {
                StationEntityExtender to = Convert(route[index + 1].Station, stationExtenderCacheList);
                StationEntityExtender from = Convert(route[index].Station, stationExtenderCacheList);

                to.GetTheMinimumRouter(from, stationExtenderCacheList, minimumArrivedTimeLimit, 1);
                timeCost += to.MinimumArrivedTime + route[index].TimeWait;

                if (firstTime)
                {
                    firstTime = false;
                }
                else
                {
                    timeCost += route[index].TransferFromList.Max(transfer => transfer.TimeTransfer);
                }

                index++;
            }

            MinimumArrivedTime = timeCost;
            return true;
        }

        internal bool GetTheMinimumRouter(StationEntityExtender fromStationExtender, List<StationEntityExtender> stationExtenderCacheList, TimeSpan minimumArrivedTimeLimit, int tranferLimit)
        {
            if (FinalResult != null)
                return FinalResult.Value;

            // get current stationLine
            PossibleCurrentStationLineList.Clear();
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
                FinalResult = true;
                return true;
            }

            // get previous station list
            List<StationLineEntity> previousStationLineList = GetPreviousStationList();
            List<StationLineEntity> transferStationLineList = GetTransferStattionList();

            // this way is not correct
            if (previousStationLineList.Count == 0 && transferStationLineList.Count == 0)
            {
                MinimumArrivedTime = new TimeSpan(TimeSpan.MaxValue.Ticks / 2);
                FinalResult = false;
                return false;
            }

            // find the minimum route from previous station line list
            MinimumArrivedTime = new TimeSpan(TimeSpan.MaxValue.Ticks / 2);
            FinalResult = false;
            foreach (StationLineEntity previousStationLine in previousStationLineList)
            {
                // if the station count is greater than 50, this route is definitly not a nearest route
                if (StationStack.Count >= 50)
                    continue;

                // if the arrived time is greater than the limit, ignore
                TimeSpan arrivedTime = GetTimeArrived(previousStationLine.NextStationLine, false);
                if (arrivedTime > minimumArrivedTimeLimit)
                {
                    continue;
                }

                StationEntityExtender previousStationExtender = Convert(previousStationLine.Station, stationExtenderCacheList);

                // avoid death loop 
                if (StationStack.Contains(previousStationExtender))
                    continue;

                // get the previous station minimum router
                previousStationExtender.StationStack = StationStack;
                previousStationExtender.StationStack.Push(this);
                previousStationExtender.TransferLineCount = TransferLineCount;
                bool found = previousStationExtender.GetTheMinimumRouter(fromStationExtender, stationExtenderCacheList, minimumArrivedTimeLimit - arrivedTime, tranferLimit);
                previousStationExtender.StationStack.Pop();

                // get current route arrived time
                TimeSpan timeArrivedToCurrentStation = previousStationExtender.MinimumArrivedTime + arrivedTime;

                // if is minimum then
                if (found && timeArrivedToCurrentStation < MinimumArrivedTime)
                {
                    // log time
                    MinimumArrivedTime = timeArrivedToCurrentStation;
                    if (MinimumArrivedTime < minimumArrivedTimeLimit)
                        minimumArrivedTimeLimit = MinimumArrivedTime;

                    // log route
                    MinimumRouteList = previousStationExtender.MinimumRouteList;
                    MinimumRouteList.Enqueue(this);
                    FinalResult = true;
                }
            }


            // find the minimum route from transfer station line list
            foreach (StationLineEntity transferStationLine in transferStationLineList)
            {
                // if TransferLineCount is greater than tranferLimit, this route is definitly not a nearest route
                if (TransferLineCount >= tranferLimit)
                    continue;

                // if the station count is greater than 50, this route is definitly not a nearest route
                if (StationStack.Count >= 50)
                    continue;

                // if the arrived time is greater than the limit, ignore
                TimeSpan arrivedTime = GetTimeArrived(transferStationLine.NextStationLine, true);
                if (arrivedTime > minimumArrivedTimeLimit)
                {
                    continue;
                }

                StationEntityExtender transferStationExtender = Convert(transferStationLine.Station, stationExtenderCacheList);

                // avoid death loop 
                if (StationStack.Contains(transferStationExtender))
                    continue;

                // get the transfer station minimum router
                transferStationExtender.StationStack = StationStack;
                transferStationExtender.StationStack.Push(this);
                transferStationExtender.TransferLineCount = TransferLineCount + 1;
                bool found = transferStationExtender.GetTheMinimumRouter(fromStationExtender, stationExtenderCacheList, minimumArrivedTimeLimit - arrivedTime, tranferLimit);
                transferStationExtender.StationStack.Pop();

                // get current route arrived time
                TimeSpan timeArrivedToCurrentStation = transferStationExtender.MinimumArrivedTime + arrivedTime;

                // if is minimum then
                if (found && timeArrivedToCurrentStation < MinimumArrivedTime)
                {
                    // log time
                    MinimumArrivedTime = timeArrivedToCurrentStation;
                    if (MinimumArrivedTime < minimumArrivedTimeLimit)
                        minimumArrivedTimeLimit = MinimumArrivedTime;

                    // log route
                    MinimumRouteList = transferStationExtender.MinimumRouteList;
                    MinimumRouteList.Enqueue(this);
                    FinalResult = true;
                }
            }

            return FinalResult.Value;
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
}
