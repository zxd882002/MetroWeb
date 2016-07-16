using System.ServiceModel.Activation;
using MetroWebLibrary;

namespace MetroWebWcfService
{
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class MetroWebService : IMetroWebService
    {
        public StationInfo GetStationNameByStationId(int stationId)
        {
            StationEntity stationEntity = MetroWebEntity.Instance().StationList[stationId];
            StationInfo stationInfo = new StationInfo();
            stationInfo.StationId = stationEntity.StationId;
            stationInfo.StationName = stationEntity.StationName;
            return stationInfo;
        }
    }
}
