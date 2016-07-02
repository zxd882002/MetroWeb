using System;
using System.Collections.Generic;
using DatabaseAccessLibrary.Database;
using DatabaseAccessLibrary.Interface;
using DatabaseAccessLibrary.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MetroWebTest
{
    [TestClass]
    public class OuterChangeTest
    {
        [TestMethod]
        public void GetLine101()
        {
            IDatabase metroWebDatabase = new MetroWebDatabase();
            List<Line> lineList = metroWebDatabase.Table<Line>().Select(new Line { LineId = 101 });
            Assert.AreEqual(lineList.Count, 1);
            Assert.AreEqual(lineList[0].LineId, 101);
            Assert.AreEqual(lineList[0].LineName, "1号线");
            Assert.AreEqual(lineList[0].LineFromStation.StationId, 128);
            Assert.AreEqual(lineList[0].LineFromStation.StationName, "富锦路");
            Assert.AreEqual(lineList[0].LineToStation.StationId, 101);
            Assert.AreEqual(lineList[0].LineToStation.StationName, "莘庄");
        }

        [TestMethod]
        public void InsertUpdateAndDeleteLine()
        {
            int randomLineId = 990000 + new Random().Next(10000);
            IDatabase metroWebDatabase = new MetroWebDatabase();
            bool inserted = metroWebDatabase.Table<Line>().Insert(
                new Line
                {
                    LineId = randomLineId,
                    LineName = "专线",
                    LineFromStation = new Station { StationId = 128 },
                    LineToStation = new Station { StationId = 101 }
                });
            Assert.IsTrue(inserted);

            List<Line> lineList = metroWebDatabase.Table<Line>().Select(new Line { LineId = randomLineId });
            Assert.AreEqual(lineList.Count, 1);
            Assert.AreEqual(lineList[0].LineId, randomLineId);
            Assert.AreEqual(lineList[0].LineName, "专线");
            Assert.AreEqual(lineList[0].LineFromStation.StationId, 128);
            Assert.AreEqual(lineList[0].LineFromStation.StationName, "富锦路");
            Assert.AreEqual(lineList[0].LineToStation.StationId, 101);
            Assert.AreEqual(lineList[0].LineToStation.StationName, "莘庄");

            bool updated = metroWebDatabase.Table<Line>().Update(
                new Line { LineId = randomLineId },
                new Line { LineName = "不是专线" }
                );
            Assert.IsTrue(updated);

            lineList = metroWebDatabase.Table<Line>().Select(new Line { LineId = randomLineId });
            Assert.AreEqual(lineList.Count, 1);
            Assert.AreEqual(lineList[0].LineId, randomLineId);
            Assert.AreEqual(lineList[0].LineName, "不是专线");
            Assert.AreEqual(lineList[0].LineFromStation.StationId, 128);
            Assert.AreEqual(lineList[0].LineFromStation.StationName, "富锦路");
            Assert.AreEqual(lineList[0].LineToStation.StationId, 101);
            Assert.AreEqual(lineList[0].LineToStation.StationName, "莘庄");

            bool deleted = metroWebDatabase.Table<Line>().Delete(new Line { LineId = randomLineId });
            Assert.IsTrue(deleted);

            lineList = metroWebDatabase.Table<Line>().Select(new Line { LineId = randomLineId });
            Assert.AreEqual(lineList.Count, 0);
        }
    }
}
