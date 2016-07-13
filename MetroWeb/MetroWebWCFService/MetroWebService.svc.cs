using System;
using System.Collections.Generic;
using System.Linq;
using MetroWebLibrary;

namespace MetroWebWCFService
{
    public class MetroWebService : IMetroWebService
    {
        public SimpleStationInfo GetSimpleStationInformation(int stationId)
        {
            StationEntity stationEntity = MetroWebEntity.Instance().StationList[stationId];
            SimpleStationInfo simpleStationInfo = new SimpleStationInfo();
            simpleStationInfo.StationName = stationEntity.StationName;
            simpleStationInfo.Lines = stationEntity.LineList.Select(line => line.LineName).Distinct().ToArray();
            return simpleStationInfo;
        }

        public Route GetTwoStationsRoute(int fromStationId, int toStationId)
        {
            throw new NotImplementedException();
        }
    }
}
