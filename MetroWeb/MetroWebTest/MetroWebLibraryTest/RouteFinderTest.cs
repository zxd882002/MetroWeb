using System;
using System.Collections.Generic;
using MetroWebLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MetroWebTest.MetroWebLibraryTest
{
    [TestClass]
    public class RouteFinderTest
    {
        private RouteFinder finder;

        [TestInitialize]
        public void Initialize()
        {
            var stationAll = MetroWebEntity.Instance.StationList.All;
            var lineAll = MetroWebEntity.Instance.LineList.All;
            var staitonLineAll = MetroWebEntity.Instance.StationLineList.All;
            //var transferAll = MetroWebEntity.Instance().MetroTransferList.All;
        }

        [TestMethod]
        public void GetTwoStationsNearBy()
        {
            StationEntity fromStation = MetroWebEntity.Instance.StationList["临港大道", "16号线"];
            StationEntity toStation = MetroWebEntity.Instance.StationList["滴水湖", "16号线"];

            finder = new RouteFinder();
            Tuple<List<StationLineEntity>, TimeSpan> result1 = finder.GetTheNearestRouteBetween(fromStation, toStation);
            Assert.AreEqual(2, result1.Item1.Count);

            finder = new RouteFinder();
            Tuple<List<StationLineEntity>, TimeSpan> result2 = finder.GetTheNearestRouteBetween(toStation, fromStation);
            Assert.AreEqual(2, result2.Item1.Count);
        }

        [TestMethod]
        public void GetTwoStationsALittleFar()
        {
            StationEntity fromStation = MetroWebEntity.Instance.StationList["临港大道", "16号线"];
            StationEntity toStation = MetroWebEntity.Instance.StationList["惠南东", "16号线"];

            finder = new RouteFinder();
            Tuple<List<StationLineEntity>, TimeSpan> result1 = finder.GetTheNearestRouteBetween(fromStation, toStation);
            Assert.AreEqual(3, result1.Item1.Count);

            finder = new RouteFinder();
            Tuple<List<StationLineEntity>, TimeSpan> result2 = finder.GetTheNearestRouteBetween(toStation, fromStation);
            Assert.AreEqual(3, result2.Item1.Count);
        }

        [TestMethod]
        public void TwoStationNeedTransfer()
        {
            StationEntity fromStation = MetroWebEntity.Instance.StationList["杨高中路", "9号线"];
            StationEntity toStation = MetroWebEntity.Instance.StationList["东昌路", "2号线"];

            finder = new RouteFinder();
            Tuple<List<StationLineEntity>, TimeSpan> result1 = finder.GetTheNearestRouteBetween(fromStation, toStation);
            Assert.AreEqual(3, result1.Item1.Count);

            finder = new RouteFinder();
            Tuple<List<StationLineEntity>, TimeSpan> result2 = finder.GetTheNearestRouteBetween(toStation, fromStation);
            Assert.AreEqual(3, result2.Item1.Count);
        }

        [TestMethod]
        public void SameLineNeedTransfer()
        {
            StationEntity fromStation = MetroWebEntity.Instance.StationList["花桥", "11号线"];
            StationEntity toStation = MetroWebEntity.Instance.StationList["嘉定北", "11号线"];

            finder = new RouteFinder();
            Tuple<List<StationLineEntity>, TimeSpan> result1 = finder.GetTheNearestRouteBetween(fromStation, toStation);
            Assert.AreEqual(11, result1.Item1.Count);

            Tuple<List<StationLineEntity>, TimeSpan> result2 = finder.GetTheNearestRouteBetween(toStation, fromStation);
            Assert.AreEqual(11, result2.Item1.Count);
        }

        [TestMethod]
        public void SameStations()
        {
            StationEntity fromStation = MetroWebEntity.Instance.StationList["宜山路", "4号线"];
            StationEntity toStation = MetroWebEntity.Instance.StationList["宝山路", "3号线"];

            finder = new RouteFinder();
            Tuple<List<StationLineEntity>, TimeSpan> result1 = finder.GetTheNearestRouteBetween(fromStation, toStation);
            Assert.AreEqual(10, result1.Item1.Count);

            Tuple<List<StationLineEntity>, TimeSpan> result2 = finder.GetTheNearestRouteBetween(toStation, fromStation);
            Assert.AreEqual(10, result2.Item1.Count);
        }

        [TestMethod]
        public void CycleStations()
        {
            StationEntity fromStation = MetroWebEntity.Instance.StationList["海伦路", "4号线"];
            StationEntity toStation = MetroWebEntity.Instance.StationList["漕溪路", "3号线"];

            finder = new RouteFinder();
            Tuple<List<StationLineEntity>, TimeSpan> result1 = finder.GetTheNearestRouteBetween(fromStation, toStation);
            Assert.AreEqual(12, result1.Item1.Count);

            Tuple<List<StationLineEntity>, TimeSpan> result2 = finder.GetTheNearestRouteBetween(toStation, fromStation);
            Assert.AreEqual(12, result2.Item1.Count);
        }

        [TestMethod]
        public void ComplexTransfer()
        {
            StationEntity fromStation = MetroWebEntity.Instance.StationList["东川路", "5号线"];
            StationEntity toStation = MetroWebEntity.Instance.StationList["北洋泾路", "6号线"];

            finder = new RouteFinder();
            Tuple<List<StationLineEntity>, TimeSpan> result1 = finder.GetTheNearestRouteBetween(fromStation, toStation);
            Assert.AreEqual(26, result1.Item1.Count);

            finder = new RouteFinder();
            Tuple<List<StationLineEntity>, TimeSpan> result2 = finder.GetTheNearestRouteBetween(toStation, fromStation);
            Assert.AreEqual(25, result2.Item1.Count);
        }
    }
}
