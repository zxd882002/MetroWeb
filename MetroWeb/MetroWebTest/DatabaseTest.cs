using System.Collections.Generic;
using DatabaseAccessLibrary;
using DatabaseAccessLibrary.Interface;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MetroWebTest
{
    [TestClass]
    public class DatabaseTest
    {
        [TestMethod]
        public void GetAllStation()
        {
            IDatabase metroWebDatabase = new MetroWebDatabase();
            List<Station> stationList = metroWebDatabase.Table<Station>();
            Assert.AreEqual(stationList.Find(station => station.StationId == 101).StationName, "莘庄");
        }

        [TestMethod]
        public void GetStation101()
        {
            IDatabase metroWebDatabase = new MetroWebDatabase();
            List<Station> stationList = metroWebDatabase.Table(new Station { StationId = 101 });
            Assert.AreEqual(stationList.Count, 1);
            Assert.AreEqual(stationList[0].StationId, 101);
            Assert.AreEqual(stationList[0].StationName, "莘庄");
        }

        [TestMethod]
        public void GetStation莘庄()
        {
            IDatabase metroWebDatabase = new MetroWebDatabase();
            List<Station> stationList = metroWebDatabase.Table(new Station { StationName = "莘庄" });
            Assert.AreEqual(stationList.Count, 1);
            Assert.AreEqual(stationList[0].StationId, 101);
            Assert.AreEqual(stationList[0].StationName, "莘庄");
        }

        [TestMethod]
        public void GetStation101莘庄()
        {
            IDatabase metroWebDatabase = new MetroWebDatabase();
            List<Station> stationList = metroWebDatabase.Table(new Station { StationId = 101, StationName = "莘庄" });
            Assert.AreEqual(stationList.Count, 1);
            Assert.AreEqual(stationList[0].StationId, 101);
            Assert.AreEqual(stationList[0].StationName, "莘庄");
        }
    }
}
