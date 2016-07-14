using System;
using System.ServiceModel;

namespace MetroWebWCFService
{
    [ServiceContract]
    public interface IMetroWebService
    {
        [OperationContract]
        String GetSimpleStationInformation(int stationId);

        [OperationContract]
        String GetTwoStationsRoute(int fromStationId, int toStationId);
    }
}
