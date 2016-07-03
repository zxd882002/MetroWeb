using System;
using DatabaseAccessLibrary.Interface;

namespace DatabaseAccessLibrary.Model
{
    public class MetroTransfer : ITableRow
    {
        public long? TransferId { get; set; }
        public int? FromStationLineId { get; set; }
        public int? ToStationLineId { get; set; }
        public TimeSpan? TimeTransfer { get; set; }
        public bool? InterChange { get; set; }
    }
}
