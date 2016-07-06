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
            List<StationLineEntity> allStationLineList = MetroWebEntity.Instance().StationLineList.All;
            Assert.AreEqual(897, allStationLineList.Count);
        }

        [TestMethod]
        public void GetStationLineByStationLineId()
        {
            StationLineEntity yiShangRoad = MetroWebEntity.Instance().StationLineList[40101];

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
            Assert.AreEqual(4, transferToList.Count);
            List<long> expectedTransferToId = new List<long>(new[] { 401030101L, 401030201L, 401090102L, 401090202L });
            List<long> actualTransferToId = transferToList.Select(metroTransfer => metroTransfer.TranferId).ToList();
            actualTransferToId.Sort();
            for (int i = 0; i < transferToList.Count; i++)
            {
                Assert.AreEqual(expectedTransferToId[i],actualTransferToId[i]);
            }

            // TransferFromList
            List<MetroTransferEntity> transferFromList = yiShangRoad.TransferFromList;
            Assert.AreEqual(4, transferFromList.Count);
            List<long> expectedTransferFromId = new List<long>(new[] { 301040101L,302040101L,901040102L,902040102L });
            List<long> actualTransferFromId = transferFromList.Select(metroTransfer => metroTransfer.TranferId).ToList();
            actualTransferFromId.Sort();
            for (int i = 0; i < transferFromList.Count; i++)
            {
                Assert.AreEqual(expectedTransferFromId[i], actualTransferFromId[i]);
            }

            // PreviousStationLine
            StationLineEntity previousStationLine = yiShangRoad.PreviousStationLine;

            // NextStationLine

            // Get previous station line

            // NextStationLine
        }

        [TestMethod]
        public void GetStationLineListByStationId() { }

        [TestMethod]
        public void GetStationLineListByLineId() { }

        [TestMethod]
        public void GetStationLineByStationIdAndLineId() { }
    }
}
