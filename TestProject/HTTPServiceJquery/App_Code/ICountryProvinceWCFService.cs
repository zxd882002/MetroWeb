using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.ServiceModel.Web;
using System.IO;


[ServiceContract]
public interface ICountryProvinceWCFService
{
    [OperationContract]
    [WebInvoke(Method = "POST",BodyStyle=WebMessageBodyStyle.Wrapped, ResponseFormat = WebMessageFormat.Json)]    
    string[] GetProvince(string Country);

    [OperationContract]
    [WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped,ResponseFormat = WebMessageFormat.Xml)]
    string[] GetProvinceXML(string Country);

    [OperationContract]
    [WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped, ResponseFormat = WebMessageFormat.Json)]
    CustomData GetProvinceAndBrowser(string Country, string Browser);

    [OperationContract]
    [WebGet(ResponseFormat=WebMessageFormat.Json)]
    string[] GetProvinceGET(string Country);

    [OperationContract]
    [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "GetProvinceREST/{Country}",
        BodyStyle=WebMessageBodyStyle.Bare)]
    string[] GetProvinceREST(string Country);

    [OperationContract]
    [WebInvoke(Method = "GET")]
    Stream GetPicture();

}
