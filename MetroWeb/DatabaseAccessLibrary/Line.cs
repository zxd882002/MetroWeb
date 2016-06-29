using DatabaseAccessLibrary.Interface;

namespace DatabaseAccessLibrary
{
    public class Line : ITableRow
    {
        public int LineId { get; set; }
        public string LineName { get; set; }
        public Station LineFromStation { get; set; }
        public Station LineToStation { get; set; }
    }
}
