using System;
using DatabaseAccessLibrary.Interface;

namespace DatabaseAccessLibrary
{
    public class InterChange : ITableRow
    {
        public int InterChangeId { get; set; }
        public StationLine FromStationLine { get; set; }
        public StationLine ToStationLine { get; set; }
        public TimeSpan Cost { get; set; }
    }
}
