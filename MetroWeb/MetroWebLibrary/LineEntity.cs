using System.Collections.Generic;
using DatabaseAccessLibrary.Model;

namespace MetroWebLibrary
{
    public class LineEntity
    {
        private MetroWebEntity metroWeb;
        private int lineId;
        private string lineName;
        private int lineFromStationId;
        private StationEntity lineFromStation;
        private int lineToStationId;
        private StationEntity lineToStation;
        private List<StationLineEntity> stationLineList;
        private List<StationEntity> stationList;

        public LineEntity(MetroWebEntity metroWeb, Line line)
        {
            this.metroWeb = metroWeb;
            this.lineId = line.LineId.Value;
            this.lineName = line.LineName;
            this.lineFromStationId = line.LineFromStationId.Value;
            this.lineToStationId = line.LineToStationId.Value;
        }

        public int LineId
        {
            get { return lineId; }
        }

        public string LineName
        {
            get { return lineName; }
        }

        public StationEntity LineFromStation
        {
            get
            {
                if (lineFromStation == null)
                {
                    lineFromStation = metroWeb.StationList[lineFromStationId];
                }
                return lineFromStation;
            }
        }

        public StationEntity LineToStation
        {
            get
            {
                if (lineToStation == null)
                {
                    lineToStation = metroWeb.StationList[lineToStationId];
                }
                return lineToStation;
            }
        }

        public List<StationLineEntity> StationLineList
        {
            get
            {
                if (stationLineList == null)
                {
                    stationLineList = metroWeb.StationLineList[lineId, IDType.LineId];
                }
                return stationLineList;
            }
        }

        public List<StationEntity> StationList {
            get
            {
                if (stationList == null)
                {
                    stationList = new List<StationEntity>();
                    foreach (StationLineEntity stationLine in StationLineList)
                    {
                        if (!stationList.Contains(stationLine.Station))
                        {
                            stationList.Add(stationLine.Station);
                        }
                    }
                }
                return stationList;
            }
        }
    }
}
