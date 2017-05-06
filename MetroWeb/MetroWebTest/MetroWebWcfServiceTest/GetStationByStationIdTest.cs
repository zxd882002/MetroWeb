using System.IO;
using System.Net;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MetroWebWcfService;
using System;
using System.Runtime.Serialization.Json;

namespace MetroWebTest.MetroWebWcfServiceTest
{
    [TestClass]
    public class GetStationByStationIdTest
    {
        [TestMethod]
        public void TestFunction()
        {
            IMetroWebService service = new MetroWebService();
            StationInfo stationInfo = service.GetStationByStationId(101);

            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(StationInfo));
            MemoryStream stream1 = new MemoryStream();
            ser.WriteObject(stream1, stationInfo);
            stream1.Position = 0;
            StreamReader sr = new StreamReader(stream1);
            var json = sr.ReadToEnd();

            Assert.AreEqual("莘庄", stationInfo.StationName);
        }

        [TestMethod]
        public void TestAPI()
        {
            string body = @"{""stationId"":""101""}";
            byte[] bodyArray = Encoding.UTF8.GetBytes(body);

            WebRequest request = WebRequest.Create("http://localhost:8732/MetroWebService.svc/GetStationByStationId");
            request.Method = WebRequestMethods.Http.Post;
            request.ContentType = "text/json";
            request.ContentLength = bodyArray.Length;

            Stream dataStream = request.GetRequestStream();
            dataStream.Write(bodyArray, 0, bodyArray.Length);
            dataStream.Close();

            WebResponse response = request.GetResponse();
            dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            string responseString = reader.ReadToEnd();
            Assert.IsTrue(responseString.StartsWith(
                @"{""d"":{""__type"":""StationInfo:#MetroWebWcfService"",""NameGraph"":{""__type"":""NameGraph:#MetroWebWcfService"",""text"":""莘庄"",""x"":205,""y"":595},""StationGraph"":{""__type"":""StationGraph:#MetroWebWcfService"",""x"":180,""y"":590},""StationId"":101"
            ));
        }
    }
}
