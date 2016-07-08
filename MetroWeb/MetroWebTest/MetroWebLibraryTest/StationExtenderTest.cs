using System;
using System.Collections.Generic;
using MetroWebLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MetroWebTest.MetroWebLibraryTest
{
    [TestClass]
    public class StationExtenderTest
    {
        [TestMethod]
        public void GetTwoStationsNearBy()
        {
            StationEntity fromStation = MetroWebEntity.Instance().StationList["临港大道", "16号线"];
            StationEntity toStation = MetroWebEntity.Instance().StationList["滴水湖", "16号线"];
            StationEntityHelper helper = new StationEntityHelper();
            //Tuple<List<StationEntity>, TimeSpan> result1 = helper.GetTheNearestRouteBetween(fromStation, toStation);
            //Assert.AreEqual(2, result1.Item1.Count);

            Tuple<List<StationEntity>, TimeSpan> result2 = helper.GetTheNearestRouteBetween(toStation, fromStation);
            Assert.AreEqual(2, result2.Item1.Count);
        }

        [TestMethod]
        public void GetTwoStationsALittleFar()
        { }

        [TestMethod]
        public void TwoStationNeedTransfer()
        { }

        [TestMethod]
        public void SameLineNeedTransfer()
        { }

        [TestMethod]
        public void SameStations()
        { }

        [TestMethod]
        public void CycleStations()
        { }

        [TestMethod]
        public void ComplexTransfer()
        { }
    }
}
