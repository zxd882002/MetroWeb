using MetroWebLibrary;

namespace MetroWebWcfService
{
    public class LineInfoAdapter : LineInfo
    {
        public LineInfoAdapter(LineEntity lineEntity)
        {
            LineGraph = new LineGraphAdapter(lineEntity);
        }
    }
}