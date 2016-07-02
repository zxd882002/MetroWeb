using System;
using DatabaseAccessLibrary.Interface;
using DatabaseAccessLibrary.Table;

namespace DatabaseAccessLibrary.Model
{
    public class InterChange : ITableRow
    {
        public long InterChangeId { get; set; }
        public StationLine FromStationLine { get; set; }
        public StationLine ToStationLine { get; set; }
        public TimeSpan Cost { get; set; }
    }
}
