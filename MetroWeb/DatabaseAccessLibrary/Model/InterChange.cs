using System;
using DatabaseAccessLibrary.Interface;

namespace DatabaseAccessLibrary.Model
{
    public class InterChange : ITableRow
    {
        public long InterChangeId { get; set; }
        public int FromStationLineId { get; set; }
        public int ToStationLineId { get; set; }
        public TimeSpan Cost { get; set; }
    }
}
