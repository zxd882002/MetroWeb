using System;
using System.Linq;
using System.ServiceModel.Activation;
using MetroWebLibrary;

namespace MetroWebWcfService
{
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class MetroWebService : IMetroWebService
    {
        public StationInfo GetStationByStationId(int stationId)
        {
            StationEntity stationEntity = MetroWebEntity.Instance().StationList[stationId];
            StationInfo stationInfo = new StationInfo
            {
                StationId = stationEntity.StationId,
                StationGraph = new StationGraph
                {
                    x = 0,
                    y = 0
                }, // todo: we will get it from database
                NameGraph = new NameGraph
                {
                    x = 0,
                    y = 0,
                    text = stationEntity.StationName
                } // todo: we will get it from database
            };
            return stationInfo;
        }

        public string GetNearestRoute(string fromStationName, int fromLine, string toStationName, int toLine)
        {
            StationEntity fromStationEntity;
            try
            {
                fromStationEntity = MetroWebEntity.Instance().StationList[fromStationName, string.Format("{0}号线", fromLine)];
            }
            catch
            {
                return "From Station is invalid!";
            }

            StationEntity toStationEntity;
            try
            {
                toStationEntity = MetroWebEntity.Instance().StationList[toStationName, string.Format("{0}号线", toLine)];
            }
            catch (Exception)
            {
                return "To Station is invalid!"; ;
            }

            RouteFinder finder = new RouteFinder();
            var stationNameList = finder.GetTheNearestRouteBetween(fromStationEntity, toStationEntity).Item1.Select(stationLine => stationLine.Station.StationName);
            return string.Join(" -> ", stationNameList);
        }
    }
}
