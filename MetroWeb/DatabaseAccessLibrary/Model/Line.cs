using DatabaseAccessLibrary.Interface;

namespace DatabaseAccessLibrary.Model
{
    public class Line : ITableRow
    {
        public int? LineId { get; set; }
        public string LineName { get; set; }
        public int? LineFromStationId { get; set; }
        public int? LineToStationId { get; set; }
        public string LineColor { get; set; }
        public string LinePath { get; set; }
    }
}
