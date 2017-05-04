using System;
using System.Collections.Generic;
using System.Linq;
using MetroWebLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MetroWebTest.MetroWebLibraryTest
{
    [TestClass]
    public class StationLineTest
    {
        [TestMethod]
        public void GetAllStationList()
        {
            List<StationLineEntity> allStationLineList = MetroWebEntity.Instance.StationLineList.All;
            Assert.AreEqual(897, allStationLineList.Count);
        }

        [TestMethod]
        public void GetStationLineByStationLineId()
        {
            StationLineEntity yiShangRoad = MetroWebEntity.Instance.StationLineList[40101];

            // StationLineId
            Assert.AreEqual(40101, yiShangRoad.StationLineId);

            // Line
            Assert.AreEqual(401, yiShangRoad.Line.LineId);

            // Station
            Assert.AreEqual(304, yiShangRoad.Station.StationId);

            // TimeWait
            Assert.AreEqual(new TimeSpan(0, 6, 30), yiShangRoad.TimeWait);

            // TimeArrived
            Assert.AreEqual(new TimeSpan(0, 2, 00), yiShangRoad.TimeArrived);

            // StartTime
            Assert.AreEqual(DateTime.Today.Add(new TimeSpan(5, 30, 0)), yiShangRoad.StartTime);

            // EndTime
            Assert.AreEqual(DateTime.Today.Add(new TimeSpan(22, 30, 0)), yiShangRoad.EndTime);

            // TransferToList
            List<MetroTransferEntity> transferToList = yiShangRoad.TransferToList;
            Assert.AreEqual(3, transferToList.Count);
            List<long> expectedTransferToId = new List<long>(new[] { 401030201L, 401090102L, 401090202L });
            List<long> actualTransferToId = transferToList.Select(metroTransfer => metroTransfer.TransferId).ToList();
            actualTransferToId.Sort();
            for (int i = 0; i < transferToList.Count; i++)
            {
                Assert.AreEqual(expectedTransferToId[i], actualTransferToId[i]);
            }

            // TransferFromList
            List<MetroTransferEntity> transferFromList = yiShangRoad.TransferFromList;
            Assert.AreEqual(4, transferFromList.Count);
            List<long> expectedTransferFromId = new List<long>(new[] { 301040101L, 302040101L, 901040102L, 902040102L });
            List<long> actualTransferFromId = transferFromList.Select(metroTransfer => metroTransfer.TransferId).ToList();
            actualTransferFromId.Sort();
            for (int i = 0; i < transferFromList.Count; i++)
            {
                Assert.AreEqual(expectedTransferFromId[i], actualTransferFromId[i]);
            }

            // PreviousStationLine
            StationLineEntity previousStationLine = yiShangRoad.PreviousStationLine;
            Assert.AreEqual(40126, previousStationLine.StationLineId);

            // NextStationLine
            StationLineEntity nextStationLine = yiShangRoad.NextStationLine;
            Assert.AreEqual(40102, nextStationLine.StationLineId);

            // NextStationLine for the previous staiton line
            StationLineEntity nextStationLine2 = previousStationLine.NextStationLine;
            Assert.AreEqual(40101, nextStationLine2.StationLineId);
            Assert.AreEqual(yiShangRoad, nextStationLine2);
        }

        [TestMethod]
        public void GetStationLineListByStationId()
        {
            List<StationLineEntity> centuryAvenueStationLineList = MetroWebEntity.Instance.StationLineList[215, IDType.StationId];
            Assert.AreEqual(8, centuryAvenueStationLineList.Count);

            List<int> expectedStationLineIdList = new List<int>(new[] { 20107, 20216, 40112, 40215, 60117, 60212, 90102, 90225 });
            List<int> actualStationLineIdList = centuryAvenueStationLineList.Select(stationLine => stationLine.StationLineId).ToList();
            for (int i = 0; i < actualStationLineIdList.Count; i++)
            {
                Assert.AreEqual(expectedStationLineIdList[i], actualStationLineIdList[i]);
            }
        }

        [TestMethod]
        public void GetStationLineListByLineId()
        {
            List<StationLineEntity> Line4StationLineList = MetroWebEntity.Instance.StationLineList[401, IDType.LineId];
            Assert.AreEqual(26, Line4StationLineList.Count);

            int exptectedStationLineId = 40101;
            List<int> Lin4StationLineIdList = Line4StationLineList.Select(stationLine => stationLine.StationLineId).ToList();
            for (int i = 0; i < Lin4StationLineIdList.Count; i++)
            {
                Assert.AreEqual(exptectedStationLineId + i, Lin4StationLineIdList[i]);
            }
        }

        [TestMethod]
        public void GetStationLineByStationIdAndLineId()
        {
            StationLineEntity xinZhuang = MetroWebEntity.Instance.StationLineList[101, 501];

            // StationLineId
            Assert.AreEqual(50101, xinZhuang.StationLineId);

            // Line
            Assert.AreEqual(501, xinZhuang.Line.LineId);

            // Station
            Assert.AreEqual(101, xinZhuang.Station.StationId);

            // TimeWait
            Assert.AreEqual(new TimeSpan(0, 5, 00), xinZhuang.TimeWait);

            // TimeArrived
            Assert.AreEqual(new TimeSpan(0, 0, 0), xinZhuang.TimeArrived);

            // StartTime
            Assert.AreEqual(DateTime.Today.Add(new TimeSpan(6, 0, 0)), xinZhuang.StartTime);

            // EndTime
            Assert.AreEqual(DateTime.Today.Add(new TimeSpan(22, 30, 0)), xinZhuang.EndTime);

            // TransferToList
            List<MetroTransferEntity> transferToList = xinZhuang.TransferToList;
            Assert.AreEqual(0, transferToList.Count);

            // TransferFromList
            List<MetroTransferEntity> transferFromList = xinZhuang.TransferFromList;
            Assert.AreEqual(1, transferFromList.Count);
            Assert.AreEqual(101050101, transferFromList[0].TransferId);

            // PreviousStationLine
            StationLineEntity previousStationLine = xinZhuang.PreviousStationLine;
            Assert.AreEqual(null, previousStationLine);

            // NextStationLine
            StationLineEntity nextStationLine = xinZhuang.NextStationLine;
            Assert.AreEqual(50102, nextStationLine.StationLineId);
        }
    }
}
