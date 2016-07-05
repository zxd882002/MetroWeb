using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MetroWebLibrary;

namespace MetroWebTest.MetroWebLibraryTest
{
    [TestClass]
    public class StationInfoTest
    {
        [TestMethod]
        public void GetAllStationList()
        {
            List<StationEntity> allStations = MetroWebEntity.Instance().StationList.All;
            Assert.AreEqual(304, allStations.Count);
        }

        [TestMethod]
        public void GetStationListByStationName()
        {
            List<StationEntity> stationList = MetroWebEntity.Instance().StationList["浦电路"];
            Assert.AreEqual(2, stationList.Count);
            List<int> stationIdList = stationList.Select(station => station.StationId).ToList();
            stationIdList.Sort();
            List<int> expectedStationIdList = new List<int>(new[] { 409, 617 });
            for (int i = 0; i < stationIdList.Count; i++)
            {
                Assert.AreEqual(expectedStationIdList[i], stationIdList[i]);
            }
        }

        [TestMethod]
        public void GetStationByStationId()
        {
            StationEntity peopleSquare = MetroWebEntity.Instance().StationList[113];

            // station id
            Assert.AreEqual(113, peopleSquare.StationId);

            // station name
            Assert.AreEqual("人民广场", peopleSquare.StationName);

            // line list
            Assert.AreEqual(7, peopleSquare.LineList.Count);
            List<int> lineIdList = peopleSquare.LineList.Select(line => line.LineId).ToList();
            List<int> expectedLineIdList = new List<int>(new[] { 101, 102, 103, 201, 202, 801, 802 });
            lineIdList.Sort();
            for (int i = 0; i < lineIdList.Count; i++)
            {
                Assert.AreEqual(expectedLineIdList[i], lineIdList[i]);
            }

            // station line list
            Assert.AreEqual(7, peopleSquare.StationLineList.Count);
            List<int> stationLineIdList = peopleSquare.StationLineList.Select(stationLine => stationLine.StationLineId).ToList();
            List<int> expectedStationLineIdList = new List<int>(new[] { 10116, 10213, 10308, 20111, 20212, 80116, 80215 });
            stationLineIdList.Sort();
            for (int i = 0; i < lineIdList.Count; i++)
            {
                Assert.AreEqual(expectedStationLineIdList[i], stationLineIdList[i]);
            }
        }

        [TestMethod]
        public void GetStationByStationNameAndLineId()
        {
            StationEntity peopleSquare = MetroWebEntity.Instance().StationList["人民广场", "1号线"];

            // station id
            Assert.AreEqual(113, peopleSquare.StationId);

            // station name
            Assert.AreEqual("人民广场", peopleSquare.StationName);

            // line list
            Assert.AreEqual(7, peopleSquare.LineList.Count);
            List<int> lineIdList = peopleSquare.LineList.Select(line => line.LineId).ToList();
            List<int> expectedLineIdList = new List<int>(new[] { 101, 102, 103, 201, 202, 801, 802 });
            lineIdList.Sort();
            for (int i = 0; i < lineIdList.Count; i++)
            {
                Assert.AreEqual(expectedLineIdList[i], lineIdList[i]);
            }

            // station line list
            Assert.AreEqual(7, peopleSquare.StationLineList.Count);
            List<int> stationLineIdList = peopleSquare.StationLineList.Select(stationLine => stationLine.StationLineId).ToList();
            List<int> expectedStationLineIdList = new List<int>(new[] { 10116, 10213, 10308, 20111, 20212, 80116, 80215 });
            stationLineIdList.Sort();
            for (int i = 0; i < lineIdList.Count; i++)
            {
                Assert.AreEqual(expectedStationLineIdList[i], stationLineIdList[i]);
            }
        }
    }
}
