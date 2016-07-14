using System;
using System.Linq;
using System.ServiceModel.Activation;
using System.Web.Script.Serialization;
using MetroWebLibrary;

namespace MetroWebWCFService
{
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]  
    public class MetroWebService : IMetroWebService
    {
        public String GetSimpleStationInformation(int stationId)
        {
            StationEntity stationEntity = MetroWebEntity.Instance().StationList[stationId];
            SimpleStationInfo simpleStationInfo = new SimpleStationInfo();
            simpleStationInfo.StationName = stationEntity.StationName;
            simpleStationInfo.Lines = stationEntity.LineList.Select(line => line.LineName).Distinct().ToArray();
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            return serializer.Serialize(simpleStationInfo);
        }

        public String GetTwoStationsRoute(int fromStationId, int toStationId)
        {
            throw new NotImplementedException();
        }
    }
}
