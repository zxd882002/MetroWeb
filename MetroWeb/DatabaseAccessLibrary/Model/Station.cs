using DatabaseAccessLibrary.Interface;

namespace DatabaseAccessLibrary.Model
{
    public class Station : ITableRow
    {
        public int? StationId { get; set; }
        public string StationName { get; set; }
        public int? StationX { get; set; }
        public int? StationY { get; set; }
        public int? StationNameX { get; set; }
        public int? StationNameY { get; set; }
    }
}
