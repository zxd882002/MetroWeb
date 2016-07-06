using System;
using System.Collections.Generic;
using DatabaseAccessLibrary.Model;

namespace MetroWebLibrary
{
    public class StationEntity
    {
        private MetroWebEntity metroWeb;
        private int stationId;
        private string stationName;
        private List<StationLineEntity> stationLineList;
        private List<LineEntity> lineList;

        internal StationEntity(MetroWebEntity metroWeb, Station station)
        {
            this.metroWeb = metroWeb;
            this.stationId = station.StationId.Value;
            this.stationName = station.StationName;
        }

        public int StationId
        {
            get { return this.stationId; }
        }

        public String StationName
        {
            get { return this.stationName; }
        }

        public List<StationLineEntity> StationLineList
        {
            get
            {
                if (stationLineList == null)
                {
                    stationLineList = metroWeb.StationLineList[stationId, IDType.StationId];
                }
                return stationLineList;
            }
        }

        public List<LineEntity> LineList
        {
            get
            {
                if (lineList == null)
                {
                    lineList = new List<LineEntity>();
                    foreach (StationLineEntity stationLine in StationLineList)
                    {
                        if (!lineList.Contains(stationLine.Line))
                        {
                            lineList.Add(stationLine.Line);
                        }
                    }
                }
                return lineList;
            }
        }

        public List<StationLineEntity> GetTheNearestWayToTargetStation(StationEntity targetStation)
        {
            throw new NotImplementedException();
        }
    }
}
