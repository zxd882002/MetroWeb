using System;
using System.Collections.Generic;
using DatabaseAccessLibrary.Database;
using DatabaseAccessLibrary.Interface;
using DatabaseAccessLibrary.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MetroWebTest
{
    [TestClass]
    public class StationTest
    {
        [TestMethod]
        public void GetAllStation()
        {
            IDatabase metroWebDatabase = new MetroWebDatabase();
            List<Station> stationList = metroWebDatabase.Table<Station>().Select();
            Assert.AreEqual(stationList.Find(station => station.StationId == 101).StationName, "莘庄");
        }

        [TestMethod]
        public void GetStation101()
        {
            IDatabase metroWebDatabase = new MetroWebDatabase();
            List<Station> stationList = metroWebDatabase.Table<Station>().Select(new Station { StationId = 101 });
            Assert.AreEqual(stationList.Count, 1);
            Assert.AreEqual(stationList[0].StationId, 101);
            Assert.AreEqual(stationList[0].StationName, "莘庄");
        }

        [TestMethod]
        public void GetStation莘庄()
        {
            IDatabase metroWebDatabase = new MetroWebDatabase();
            List<Station> stationList = metroWebDatabase.Table<Station>().Select(new Station { StationName = "莘庄" });
            Assert.AreEqual(stationList.Count, 1);
            Assert.AreEqual(stationList[0].StationId, 101);
            Assert.AreEqual(stationList[0].StationName, "莘庄");
        }

        [TestMethod]
        public void GetStation101莘庄()
        {
            IDatabase metroWebDatabase = new MetroWebDatabase();
            List<Station> stationList = metroWebDatabase.Table<Station>().Select(new Station { StationId = 101, StationName = "莘庄" });
            Assert.AreEqual(stationList.Count, 1);
            Assert.AreEqual(stationList[0].StationId, 101);
            Assert.AreEqual(stationList[0].StationName, "莘庄");
        }

        [TestMethod]
        public void InsertUpdateAndDeleteStation()
        {
            int randomStationId = 990000 + new Random().Next(10000);
            IDatabase metroWebDatabase = new MetroWebDatabase();
            bool inserted = metroWebDatabase.Table<Station>().Insert(new Station { StationId = randomStationId, StationName = "我家" });
            Assert.IsTrue(inserted);

            List<Station> stationList = metroWebDatabase.Table<Station>().Select(new Station { StationId = randomStationId });
            Assert.AreEqual(stationList.Count, 1);
            Assert.AreEqual(stationList[0].StationId, randomStationId);
            Assert.AreEqual(stationList[0].StationName, "我家");

            bool updated = metroWebDatabase.Table<Station>().Update(
                new Station { StationId = randomStationId },
                new Station { StationId = randomStationId + 1, StationName = "不是我家" }
                );
            Assert.IsTrue(updated);

            stationList = metroWebDatabase.Table<Station>().Select(new Station { StationId = randomStationId + 1 });
            Assert.AreEqual(stationList.Count, 1);
            Assert.AreEqual(stationList[0].StationId, randomStationId + 1);
            Assert.AreEqual(stationList[0].StationName, "不是我家");

            bool deleted = metroWebDatabase.Table<Station>().Delete(new Station { StationId = randomStationId + 1 });
            Assert.IsTrue(deleted);

            stationList = metroWebDatabase.Table<Station>().Select(new Station { StationId = randomStationId + 1 });
            Assert.AreEqual(stationList.Count, 0);
        }
    }
}
