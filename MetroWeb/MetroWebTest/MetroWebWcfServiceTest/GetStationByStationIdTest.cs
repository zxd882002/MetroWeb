using System.IO;
using System.Net;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MetroWebTest.MetroWebWcfServiceTest
{
    [TestClass]
    public class GetStationByStationIdTest
    {
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
            Assert.AreEqual(
                @"{""d"":{""__type"":""StationInfo:#MetroWebWcfService"",""NameGraph"":{""__type"":""NameGraph:#MetroWebWcfService"",""text"":""莘庄"",""x"":0,""y"":0},""StationGraph"":{""__type"":""StationGraph:#MetroWebWcfService"",""x"":0,""y"":0},""StationId"":101}}",
                responseString);
        }
    }
}
