using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Activation;
using MetroWebLibrary;

namespace MetroWebWcfService
{
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class MetroWebService : IMetroWebService
    {
        public StationInfo[] GetStationInfos()
        {
            List<StationEntity> stationEntityList = MetroWebEntity.Instance.StationList.All;
            List<StationInfo> stationInfoList = new List<StationInfo>();
            foreach (StationEntity stationEntity in stationEntityList)
            {
                StationInfo stationInfo = new StationInfoAdapter(stationEntity).ToObject();
                stationInfoList.Add(stationInfo);
            }
            return stationInfoList.ToArray();
        }

        public LineInfo[] GetLineInfos()
        {
            List<LineEntity> lineEntityList = MetroWebEntity.Instance.LineList.All;
            List<LineInfo> lineInfoList = new List<LineInfo>();
            foreach (LineEntity lineEntity in lineEntityList)
            {
                if (!string.IsNullOrEmpty(lineEntity.LinePath))
                {
                    LineInfo lineInfo = new LineInfoAdapter(lineEntity).ToObject();
                    lineInfoList.Add(lineInfo);
                }
            }
            return lineInfoList.ToArray();
        }

        public string GetNearestRoute(string fromStationName, int fromLine, string toStationName, int toLine)
        {
            StationEntity fromStationEntity;
            try
            {
                fromStationEntity = MetroWebEntity.Instance.StationList[fromStationName, string.Format("{0}号线", fromLine)];
            }
            catch
            {
                return "From Station is invalid!";
            }

            StationEntity toStationEntity;
            try
            {
                toStationEntity = MetroWebEntity.Instance.StationList[toStationName, string.Format("{0}号线", toLine)];
            }
            catch (Exception)
            {
                return "To Station is invalid!";
            }

            RouteFinder finder = new RouteFinder();
            var stationNameList = finder.GetTheNearestRouteBetween(fromStationEntity, toStationEntity).Item1.Select(stationLine => stationLine.Station.StationName);
            return string.Join(" -> ", stationNameList);
        }
    }
}
