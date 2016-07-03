using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MetroWebLibrary;

namespace MetroWebTest.MetroWebLibraryTest
{
    [TestClass]
    public class StationInfoTest
    {
        [TestMethod]
        public void GetStationInfoByName()
        {
            StationEntity peopleSquare = MetroWebEntity.Instance().StationList["人民广场", "1号线"];
        }
    }
}
