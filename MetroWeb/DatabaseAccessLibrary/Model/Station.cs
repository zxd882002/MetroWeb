using DatabaseAccessLibrary.Interface;

namespace DatabaseAccessLibrary.Model
{
    public class Station : ITableRow
    {
        public int StationId { get; set; }
        public string StationName { get; set; }
    }
}
