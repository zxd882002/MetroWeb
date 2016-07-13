using System.ServiceModel;

namespace MetroWebWCFService
{
    [ServiceContract]
    public interface IMetroWebService
    {
        [OperationContract]
        SimpleStationInfo GetSimpleStationInformation(int stationId);

        [OperationContract]
        Route GetTwoStationsRoute(int fromStationId, int toStationId);
    }
}
