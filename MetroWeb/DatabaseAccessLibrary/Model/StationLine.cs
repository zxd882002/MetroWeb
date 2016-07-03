using System;
using DatabaseAccessLibrary.Interface;

namespace DatabaseAccessLibrary.Model
{
    public class StationLine :ITableRow
    {
        public int? StationLineId { get; set; }
        public int? LineId { get; set; }
        public int? StationId { get; set; }
        public int? IndexNumber { get; set; }
        public TimeSpan? TimeWait { get; set; }
        public TimeSpan? TimeArrived { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
    }
}
