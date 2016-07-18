using System.ServiceModel;
using System.ServiceModel.Web;

namespace MetroWebWcfService
{
    [ServiceContract]
    public interface IMetroWebService
    {
        [OperationContract]
        [WebInvoke(RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        StationInfo GetStationByStationId(int stationId);

        [OperationContract]
        [WebInvoke(RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        string GetNearestRoute(string fromStationName, int fromLine, string toStationName, int toLine);
    }
}
