using System.ServiceModel;

namespace MetroWebWCFService
{
    [ServiceContract]
    public interface IMetroWebService
    {
        [OperationContract]
        StationInfo GetStationInformation(int value);

        [OperationContract]
        RouteAndPrice GetTwoStationsRouteAndPrice(int value);
    }
}
