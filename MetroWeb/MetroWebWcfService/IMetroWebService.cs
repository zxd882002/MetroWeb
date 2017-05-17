using System.ServiceModel;
using System.ServiceModel.Web;

namespace MetroWebWcfService
{
    [ServiceContract]
    public interface IMetroWebService
    {
        [OperationContract]
        [WebInvoke(RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        StationInfo[] GetStationInfos();

        [OperationContract]
        [WebInvoke(RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        LineInfo[] GetLineInfos();
        
        [OperationContract]
        [WebInvoke(RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        StationInfo[] GetNearestRoute(string fromStationName, int fromLine, string toStationName, int toLine);
    }
}
