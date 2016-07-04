using System;
using System.Collections.Generic;
using DatabaseAccessLibrary.Model;

namespace MetroWebLibrary
{
    public class StationLineEntity
    {
        private MetroWebEntity metroWeb;
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
        private StationLineEntity nextStationLine;

        internal StationLineEntity(MetroWebEntity metroWeb, StationLine stationLine)
        {
            this.metroWeb = metroWeb;
            this.stationLineId = stationLine.StationId.Value;
            this.lineId = stationLine.LineId.Value;
            this.stationId = stationLine.StationId.Value;
            this.timeWait = stationLine.TimeWait.Value;
            this.timeArrived = stationLine.TimeArrived.Value;
            this.startTime = stationLine.StartTime.Value;
            this.endTime = stationLine.EndTime.Value;
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
                
            }
        }

        public List<MetroTransferEntity> TransferFromList
        {
            get
            {
                
            }
        }

        public StationLineEntity PreviousStationLine
        {
            get
            {
                
            }
        }

        public StationLineEntity NextStationLine
        {
            get
            {
                
            }
        }
    }
}
