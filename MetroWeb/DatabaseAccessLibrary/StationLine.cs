using System;
using DatabaseAccessLibrary.Interface;

namespace DatabaseAccessLibrary
{
    public class StationLine :ITableRow
    {
        public int StationLineId { get; set; }
        public Line Line { get; set; }
        public Station Station { get; set; }
        public int IndexNumber { get; set; }
        public TimeSpan Duration { get; set; }
        public TimeSpan CostArrived { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}
