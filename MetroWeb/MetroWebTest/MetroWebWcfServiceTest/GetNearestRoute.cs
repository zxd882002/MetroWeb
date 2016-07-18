using System.IO;
using System.Net;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MetroWebTest.MetroWebWcfServiceTest
{
    [TestClass]
    public class GetNearestRoute
    {
        [TestMethod]
        public void TestAPI()
        {
            string body = @"{""fromStationName"":""上海火车站"",""fromLine"":""1"",""toStationName"":""上海南站"",""toLine"":""1""}";
            byte[] bodyArray = Encoding.UTF8.GetBytes(body);

            WebRequest request = WebRequest.Create("http://localhost:8732/MetroWebService.svc/GetNearestRoute");
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
                @"{""d"":""上海火车站 -> 汉中路 -> 新闸路 -> 人民广场 -> 黄陂南路 -> 陕西南路 -> 常熟路 -> 衡山路 -> 徐家汇 -> 上海体育馆 -> 漕宝路 -> 上海南站""}",
                responseString
                );
        }
    }
}
