using System;
using System.Collections.Generic;
using DatabaseAccessLibrary.Database;
using DatabaseAccessLibrary.Interface;
using DatabaseAccessLibrary.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MetroWebTest.DatabaseAccessTest
{
    [TestClass]
    public class MetroTransferTest
    {
        [TestMethod]
        public void GetMetroTransfer101020101()
        {
            IDatabase metroWebDatabase = new MetroWebDatabase();
            List<MetroTransfer> metroTransferList = metroWebDatabase.Table<MetroTransfer>().Select(new MetroTransfer { TransferId = 101020101 });
            Assert.AreEqual(metroTransferList.Count, 1);
            Assert.AreEqual(metroTransferList[0].TransferId, 101020101);
            Assert.AreEqual(metroTransferList[0].FromStationLineId, 10115);
            Assert.AreEqual(metroTransferList[0].ToStationLineId, 20109);
            Assert.AreEqual(metroTransferList[0].TimeTransfer, new TimeSpan(0, 3, 0));
            Assert.AreEqual(metroTransferList[0].InterChange, true);
        }

        [TestMethod]
        public void InsertUpdateAndDeleteMetroTransfer()
        {
            int randomInterChangeId = 990000 + new Random().Next(10000);
            IDatabase metroWebDatabase = new MetroWebDatabase();
            bool inserted = metroWebDatabase.Table<MetroTransfer>().Insert(
                new MetroTransfer
                {
                    TransferId = randomInterChangeId,
                    FromStationLineId = 10115,
                    ToStationLineId = 20109,
                    TimeTransfer = new TimeSpan(1, 0, 0),
                    InterChange = true
                });
            Assert.IsTrue(inserted);

            List<MetroTransfer> metroTransferList = metroWebDatabase.Table<MetroTransfer>().Select(new MetroTransfer { TransferId = randomInterChangeId });
            Assert.AreEqual(metroTransferList.Count, 1);
            Assert.AreEqual(metroTransferList[0].TransferId, randomInterChangeId);
            Assert.AreEqual(metroTransferList[0].FromStationLineId, 10115);
            Assert.AreEqual(metroTransferList[0].ToStationLineId, 20109);
            Assert.AreEqual(metroTransferList[0].TimeTransfer, new TimeSpan(1, 0, 0));
            Assert.AreEqual(metroTransferList[0].InterChange, true);

            bool updated = metroWebDatabase.Table<MetroTransfer>().Update(
                new MetroTransfer { TransferId = randomInterChangeId },
                new MetroTransfer { FromStationLineId = 20109, ToStationLineId = 10115, InterChange = false}
                );
            Assert.IsTrue(updated);

            metroTransferList = metroWebDatabase.Table<MetroTransfer>().Select(new MetroTransfer { TransferId = randomInterChangeId });
            Assert.AreEqual(metroTransferList.Count, 1);
            Assert.AreEqual(metroTransferList[0].TransferId, randomInterChangeId);
            Assert.AreEqual(metroTransferList[0].FromStationLineId, 20109);
            Assert.AreEqual(metroTransferList[0].ToStationLineId, 10115);
            Assert.AreEqual(metroTransferList[0].TimeTransfer, new TimeSpan(1, 0, 0));
            Assert.AreEqual(metroTransferList[0].InterChange, false);

            bool deleted = metroWebDatabase.Table<MetroTransfer>().Delete(new MetroTransfer { TransferId = randomInterChangeId });
            Assert.IsTrue(deleted);

            metroTransferList = metroWebDatabase.Table<MetroTransfer>().Select(new MetroTransfer { TransferId = randomInterChangeId });
            Assert.AreEqual(metroTransferList.Count, 0);
        }
    }
}
