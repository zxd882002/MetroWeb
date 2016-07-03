using System;
using System.Collections.Generic;
using DatabaseAccessLibrary.Database;
using DatabaseAccessLibrary.Interface;
using DatabaseAccessLibrary.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MetroWebTest
{
    [TestClass]
    public class InterChangeTest
    {
        [TestMethod]
        public void GetInterChange101020101()
        {
            IDatabase metroWebDatabase = new MetroWebDatabase();
            List<InterChange> interChangeList = metroWebDatabase.Table<InterChange>().Select(new InterChange { InterChangeId = 101020101 });
            Assert.AreEqual(interChangeList.Count, 1);
            Assert.AreEqual(interChangeList[0].InterChangeId, 101020101);
            Assert.AreEqual(interChangeList[0].FromStationLineId, 10115);
            Assert.AreEqual(interChangeList[0].ToStationLineId, 20109);
            Assert.AreEqual(interChangeList[0].Cost, new TimeSpan(0, 3, 0));
        }

        [TestMethod]
        public void InsertUpdateAndDeleteInterChange()
        {
            int randomInterChangeId = 990000 + new Random().Next(10000);
            IDatabase metroWebDatabase = new MetroWebDatabase();
            bool inserted = metroWebDatabase.Table<InterChange>().Insert(
                new InterChange
                {
                    InterChangeId = randomInterChangeId,
                    FromStationLineId = 10115,
                    ToStationLineId = 20109,
                    Cost = new TimeSpan(1, 0, 0)
                });
            Assert.IsTrue(inserted);

            List<InterChange> interChangeList = metroWebDatabase.Table<InterChange>().Select(new InterChange { InterChangeId = randomInterChangeId });
            Assert.AreEqual(interChangeList.Count, 1);
            Assert.AreEqual(interChangeList[0].InterChangeId, randomInterChangeId);
            Assert.AreEqual(interChangeList[0].FromStationLineId, 10115);
            Assert.AreEqual(interChangeList[0].ToStationLineId, 20109);
            Assert.AreEqual(interChangeList[0].Cost, new TimeSpan(1, 0, 0));

            bool updated = metroWebDatabase.Table<InterChange>().Update(
                new InterChange { InterChangeId = randomInterChangeId },
                new InterChange { FromStationLineId = 20109, ToStationLineId = 10115 }
                );
            Assert.IsTrue(updated);

            interChangeList = metroWebDatabase.Table<InterChange>().Select(new InterChange { InterChangeId = randomInterChangeId });
            Assert.AreEqual(interChangeList.Count, 1);
            Assert.AreEqual(interChangeList[0].InterChangeId, randomInterChangeId);
            Assert.AreEqual(interChangeList[0].FromStationLineId, 20109);
            Assert.AreEqual(interChangeList[0].ToStationLineId, 10115);
            Assert.AreEqual(interChangeList[0].Cost, new TimeSpan(1, 0, 0));

            bool deleted = metroWebDatabase.Table<InterChange>().Delete(new InterChange { InterChangeId = randomInterChangeId });
            Assert.IsTrue(deleted);

            interChangeList = metroWebDatabase.Table<InterChange>().Select(new InterChange { InterChangeId = randomInterChangeId });
            Assert.AreEqual(interChangeList.Count, 0);
        }
    }
}
