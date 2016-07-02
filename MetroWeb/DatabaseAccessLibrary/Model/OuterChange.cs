using System;
using DatabaseAccessLibrary.Interface;
using DatabaseAccessLibrary.Table;

namespace DatabaseAccessLibrary.Model
{
    public class OuterChange : ITableRow
    {
        public long OuterChangeId { get; set; }
        public StationLine FromStationLine { get; set; }
        public StationLine ToStationLine { get; set; }
        public TimeSpan Cost { get; set; }
    }
}
