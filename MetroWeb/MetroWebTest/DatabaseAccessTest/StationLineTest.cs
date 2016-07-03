using System;
using System.Collections.Generic;
using DatabaseAccessLibrary.Database;
using DatabaseAccessLibrary.Interface;
using DatabaseAccessLibrary.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MetroWebTest.DatabaseAccessTest
{
    [TestClass]
    public class StationLineTest
    {
        [TestMethod]
        public void GetStationLine10101()
        {
            IDatabase metroWebDatabase = new MetroWebDatabase();
            List<StationLine> stationLineList = metroWebDatabase.Table<StationLine>().Select(new StationLine { StationLineId = 10101 });
            Assert.AreEqual(stationLineList.Count, 1);
            Assert.AreEqual(stationLineList[0].StationLineId, 10101);
            Assert.AreEqual(stationLineList[0].StationId, 128);
            Assert.AreEqual(stationLineList[0].LineId, 101);
            Assert.AreEqual(stationLineList[0].TimeWait, new TimeSpan(0, 4, 5));
            Assert.AreEqual(stationLineList[0].TimeArrived, new TimeSpan(0, 0, 0));
            Assert.AreEqual(stationLineList[0].StartTime, DateTime.Today.Add(new TimeSpan(5, 30, 0)));
            Assert.AreEqual(stationLineList[0].EndTime, DateTime.Today.Add(new TimeSpan(22, 30, 0)));
        }

        [TestMethod]
        public void InsertUpdateAndDeleteStationLine()
        {
            int randomStationLineId = 990000 + new Random().Next(10000);
            IDatabase metroWebDatabase = new MetroWebDatabase();
            bool inserted = metroWebDatabase.Table<StationLine>().Insert(
                new StationLine
                {
                    StationLineId = randomStationLineId,
                    StationId = 128,
                    LineId = 101,
                    TimeWait = new TimeSpan(1, 0, 0),
                    TimeArrived = new TimeSpan(2, 0, 0),
                    StartTime = DateTime.Today.Add(new TimeSpan(1, 00, 0)),
                    EndTime = DateTime.Today.Add(new TimeSpan(3, 0, 0))
                });
            Assert.IsTrue(inserted);

            List<StationLine> stationLineList = metroWebDatabase.Table<StationLine>().Select(new StationLine { StationLineId = randomStationLineId });
            Assert.AreEqual(stationLineList.Count, 1);
            Assert.AreEqual(stationLineList[0].StationLineId, randomStationLineId);
            Assert.AreEqual(stationLineList[0].StationId, 128);
            Assert.AreEqual(stationLineList[0].LineId, 101);
            Assert.AreEqual(stationLineList[0].TimeWait, new TimeSpan(1, 0, 0));
            Assert.AreEqual(stationLineList[0].TimeArrived, new TimeSpan(2, 0, 0));
            Assert.AreEqual(stationLineList[0].StartTime, DateTime.Today.Add(new TimeSpan(1, 00, 0)));
            Assert.AreEqual(stationLineList[0].EndTime, DateTime.Today.Add(new TimeSpan(3, 0, 0)));

            bool updated = metroWebDatabase.Table<StationLine>().Update(
                new StationLine { StationLineId = randomStationLineId },
                new StationLine { EndTime = DateTime.Today.Add(new TimeSpan(23, 0, 0)) }
                );
            Assert.IsTrue(updated);

            stationLineList = metroWebDatabase.Table<StationLine>().Select(new StationLine { StationLineId = randomStationLineId });
            Assert.AreEqual(stationLineList.Count, 1);
            Assert.AreEqual(stationLineList[0].StationLineId, randomStationLineId);
            Assert.AreEqual(stationLineList[0].StationId, 128);
            Assert.AreEqual(stationLineList[0].LineId, 101);
            Assert.AreEqual(stationLineList[0].TimeWait, new TimeSpan(1, 0, 0));
            Assert.AreEqual(stationLineList[0].TimeArrived, new TimeSpan(2, 0, 0));
            Assert.AreEqual(stationLineList[0].StartTime, DateTime.Today.Add(new TimeSpan(1, 00, 0)));
            Assert.AreEqual(stationLineList[0].EndTime, DateTime.Today.Add(new TimeSpan(23, 0, 0)));

            bool deleted = metroWebDatabase.Table<StationLine>().Delete(new StationLine { StationLineId = randomStationLineId });
            Assert.IsTrue(deleted);

            stationLineList = metroWebDatabase.Table<StationLine>().Select(new StationLine { StationLineId = randomStationLineId });
            Assert.AreEqual(stationLineList.Count, 0);
        }
    }
}
