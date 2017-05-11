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
                LineGraph = new LineGraphAdapter(lineEntity).ToObject(),
                LineId = lineEntity.LineName.Substring(0, 1),
                LineRoute = GetLineRoute()
            };
        }

        private string GetLineRoute()
        {
            if (lineEntity.LineId == 401) // 4号线 外圈 
            {
                return "外圈";
            }
            if (lineEntity.LineId == 402) // 4号线 内圈 
            {
                return "内圈";
            }
            return string.Format("{0} -> {1}", lineEntity.LineFromStation.StationName, lineEntity.LineToStation.StationName);
        }
    }
}