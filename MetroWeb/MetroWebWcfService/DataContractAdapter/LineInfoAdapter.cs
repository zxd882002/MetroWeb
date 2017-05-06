using MetroWebLibrary;

namespace MetroWebWcfService
{
    public class LineInfoAdapter : IAdapter<LineInfo>
    {
        private LineEntity lineEntity;

        public LineInfoAdapter(LineEntity lineEntity)
        {
            this.lineEntity = lineEntity;
        }

        public LineInfo ToObject()
        {
            return new LineInfo
            {
                LineGraph = new LineGraphAdapter(lineEntity).ToObject()
            };
        }
    }
}