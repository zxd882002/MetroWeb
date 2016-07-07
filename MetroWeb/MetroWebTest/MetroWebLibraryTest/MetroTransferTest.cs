using System;
using System.Collections.Generic;
using System.Linq;
using MetroWebLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MetroWebTest.MetroWebLibraryTest
{
    [TestClass]
    public class MetroTransferTest
    {
        [TestMethod]
        public void GetMetroTransferListByFromStationLineId()
        {
            List<MetroTransferEntity> metroTransferList = MetroWebEntity.Instance().MetroTransferList[10128, StationLineIdType.FromStationLineId];
            Assert.AreEqual(1, metroTransferList.Count);

            MetroTransferEntity metroTransfer = metroTransferList[0];

            // TransferId
            Assert.AreEqual(101050101L, metroTransfer.TransferId);

            // FromStationLine
            Assert.AreEqual(10128, metroTransfer.FromStationLine.StationLineId);

            // ToStationLine
            Assert.AreEqual(50101, metroTransfer.ToStationLine.StationLineId);

            // TimeTransfer
            Assert.AreEqual(new TimeSpan(0, 3, 0), metroTransfer.TimeTransfer);

            // InterChange
            Assert.AreEqual(true, metroTransfer.InterChange);
        }

        [TestMethod]
        public void GetMetroTransferListByToStationLineId()
        {
            List<MetroTransferEntity> metroTransferList = MetroWebEntity.Instance().MetroTransferList[10216, StationLineIdType.ToStationLineId];
            Assert.AreEqual(4, metroTransferList.Count);
            Assert.IsTrue(metroTransferList.All(metroTransfer => metroTransfer.InterChange == false));
            List<long> expectedMetroTransferIdList = new List<long>(new[] { 301010202L, 302010202L, 401010202L, 402010202L });
            List<long> actualMetroTransferIdList = metroTransferList.Select(metroTransfer => metroTransfer.TransferId).ToList();
            actualMetroTransferIdList.Sort();
            for (int i = 0; i < actualMetroTransferIdList.Count; i++)
            {
                Assert.AreEqual(expectedMetroTransferIdList[i], actualMetroTransferIdList[i]);
            }
        }
    }
}
