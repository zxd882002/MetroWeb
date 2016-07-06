using System.Collections.Generic;
using System.Linq;
using MetroWebLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MetroWebTest.MetroWebLibraryTest
{
    [TestClass]
    public class LineTest
    {
        [TestMethod]
        public void GetAllLineList()
        {
            List<LineEntity> allLineList = MetroWebEntity.Instance().LineList.All;
            Assert.AreEqual(36, allLineList.Count);
        }

        [TestMethod]
        public void GetLineListByLineName()
        {
            List<LineEntity> line4List = MetroWebEntity.Instance().LineList["4号线"];
            Assert.AreEqual(2, line4List.Count);
            List<int> lin4IdList = line4List.Select(line => line.LineId).ToList();
            lin4IdList.Sort();
            List<int> expectedLineIdList = new List<int>(new[] { 401, 402 });
            for (int i = 0; i < lin4IdList.Count; i++)
            {
                Assert.AreEqual(expectedLineIdList[i], lin4IdList[i]);
            }
        }

        [TestMethod]
        public void GetLineByLineId()
        {
            LineEntity line = MetroWebEntity.Instance().LineList[401];

            // LineId
            Assert.AreEqual(401, line.LineId);

            // LineName
            Assert.AreEqual("4号线", line.LineName);

            // LineFromStation
            Assert.AreEqual(304, line.LineFromStation.StationId);

            // LineToStation
            Assert.AreEqual(305, line.LineToStation.StationId);

            // StationLineList
            Assert.AreEqual(26, line.StationLineList.Count);
            List<int> exptectedStationIdList = new List<int>(new[] { 107, 116, 208, 215, 304, 305, 306, 307, 308, 309, 310, 311, 401, 402, 403, 404, 405, 406, 407, 408, 409, 410, 411, 412, 413, 414 });
            List<int> actualStationIdList = line.StationLineList.Select(stationLine => stationLine.Station.StationId).ToList();
            actualStationIdList.Sort();
            for (int i = 0; i < actualStationIdList.Count; i++)
            {
                Assert.AreEqual(exptectedStationIdList[i], actualStationIdList[i]);
            }

            // StationList
            Assert.AreEqual(26, line.StationList.Count);
            actualStationIdList = line.StationList.Select(station => station.StationId).ToList();
            actualStationIdList.Sort();
            for (int i = 0; i < actualStationIdList.Count; i++)
            {
                Assert.AreEqual(exptectedStationIdList[i], actualStationIdList[i]);
            }
        }
    }
}
