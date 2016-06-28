using System;
using DatabaseAccessLibrary.Interface;

namespace DatabaseAccessLibrary
{
    public class OuterChange : ITableRow
    {
        public int OuterChangeId { get; set; }
        public StationLine FromStationLine { get; set; }
        public StationLine ToStationLine { get; set; }
        public TimeSpan Cost { get; set; }
    }
}
