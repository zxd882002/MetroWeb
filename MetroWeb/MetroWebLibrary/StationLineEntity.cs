using System;
using System.Collections.Generic;
using System.Linq;
using DatabaseAccessLibrary.Model;

namespace MetroWebLibrary
{
    public class StationLineEntity
    {
        private MetroWebEntity metroWeb;
        private StationLine stationLine;
        private int stationLineId;
        private int lineId;
        private LineEntity line;
        private int stationId;
        private StationEntity station;
        private TimeSpan timeWait;
        private TimeSpan timeArrived;
        private DateTime startTime;
        private DateTime endTime;
        private List<MetroTransferEntity> transferToList;
        private List<MetroTransferEntity> transferFromList;
        private StationLineEntity previousStationLine;
        private List<StationLineEntity> previousStationLineList;
        private StationLineEntity nextStationLine;
        private List<StationLineEntity> nextStationLineList;

        internal StationLineEntity(MetroWebEntity metroWeb, StationLine stationLine)
        {
            this.metroWeb = metroWeb;
            this.stationLine = stationLine;
            this.stationLineId = stationLine.StationLineId.Value;
            this.lineId = stationLine.LineId.Value;
            this.stationId = stationLine.StationId.Value;
            this.timeWait = stationLine.TimeWait.Value;
            this.timeArrived = stationLine.TimeArrived.Value;
            this.startTime = stationLine.StartTime.Value;
            this.endTime = stationLine.EndTime.Value;
        }

        public MetroWebEntity MetroWeb
        {
            get { return this.metroWeb; }
        }

        public StationLine StationLine
        {
            get { return this.stationLine; }
        }

        public int StationLineId
        {
            get { return this.stationLineId; }
        }

        public LineEntity Line
        {
            get
            {
                if (line == null)
                {
                    line = metroWeb.LineList[lineId];
                }
                return line;
            }
        }

        public StationEntity Station
        {
            get
            {
                if (station == null)
                {
                    station = metroWeb.StationList[stationId];
                }
                return station;
            }
        }

        public TimeSpan TimeWait
        {
            get { return timeWait; }
        }

        public TimeSpan TimeArrived
        {
            get { return timeArrived; }
        }

        public DateTime StartTime
        {
            get { return startTime; }
        }

        public DateTime EndTime
        {
            get { return endTime; }
        }

        public List<MetroTransferEntity> TransferToList
        {
            get
            {
                if (transferToList == null)
                {
                    transferToList = new List<MetroTransferEntity>();

                    try
                    {
                        transferToList = metroWeb.MetroTransferList[stationLineId, StationLineIdType.FromStationLineId];
                    }
                    catch
                    {
                        transferToList = new List<MetroTransferEntity>();
                    }

                }
                return transferToList;
            }
        }

        public List<MetroTransferEntity> TransferFromList
        {
            get
            {
                if (transferFromList == null)
                {
                    transferFromList = new List<MetroTransferEntity>();

                    try
                    {
                        transferFromList = metroWeb.MetroTransferList[stationLineId, StationLineIdType.ToStationLineId];
                    }
                    catch
                    {
                        transferFromList = new List<MetroTransferEntity>();
                    }
                }
                return transferFromList;
            }
        }

        public StationLineEntity PreviousStationLine
        {
            get
            {
                if (previousStationLine == null)
                {
                    if (StationLineId % 100 == 1 && timeArrived != new TimeSpan(0, 0, 0)) // cycle line
                    {
                        List<StationLineEntity> allStationLineList = metroWeb.StationLineList[lineId, IDType.LineId];
                        int maxStationLineId = allStationLineList.Max(stationLine => stationLine.StationLineId);
                        previousStationLine = allStationLineList.Find(stationLine => stationLine.stationLineId == maxStationLineId);
                    }
                    else if (timeArrived != new TimeSpan(0, 0, 0))
                    {
                        previousStationLine = metroWeb.StationLineList[stationLineId - 1];
                    }

                }
                return previousStationLine;
            }
        }

        public List<StationLineEntity> PreviousStationLineList // todo ut
        {
            get
            {
                if (previousStationLineList == null)
                {
                    previousStationLineList = new List<StationLineEntity>();
                    StationLineEntity currentPreviousStationLine = PreviousStationLine;
                    while (currentPreviousStationLine != null && !previousStationLineList.Contains(currentPreviousStationLine))
                    {
                        previousStationLineList.Add(currentPreviousStationLine);
                        currentPreviousStationLine = currentPreviousStationLine.PreviousStationLine;
                    }
                }
                return previousStationLineList;
            }
        }

        public StationLineEntity NextStationLine
        {
            get
            {
                if (nextStationLine == null)
                {
                    List<StationLineEntity> allStationLineList = metroWeb.StationLineList[lineId, IDType.LineId];
                    int maxStationLineId = allStationLineList.Max(stationLine => stationLine.StationLineId);

                    if (stationLineId != maxStationLineId)
                    {
                        nextStationLine = metroWeb.StationLineList[stationLineId + 1];
                    }
                    else // cycle line
                    {
                        int minStationLineId = allStationLineList.Min(stationLine => stationLine.StationLineId);
                        StationLineEntity firstStationLine = allStationLineList.Find(stationLine => stationLine.stationLineId == minStationLineId);
                        if (firstStationLine.timeArrived != new TimeSpan(0, 0, 0))
                        {
                            nextStationLine = firstStationLine;
                        }
                    }
                }
                return nextStationLine;
            }
        }

        public List<StationLineEntity> NextStationLineList // todo ut
        {
            get
            {
                if (nextStationLineList == null)
                {
                    nextStationLineList = new List<StationLineEntity>();
                    StationLineEntity currentNextStationLine = NextStationLine;
                    while (currentNextStationLine != null && !nextStationLineList.Contains(currentNextStationLine))
                    {
                        nextStationLineList.Add(currentNextStationLine);
                        currentNextStationLine = currentNextStationLine.NextStationLine;
                    }
                }
                return nextStationLineList;
            }
        }
    }
}
