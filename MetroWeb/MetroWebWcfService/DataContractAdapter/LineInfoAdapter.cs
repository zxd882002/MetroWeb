using System;
using System.Linq;
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
                LineId = new String(lineEntity.LineName.TakeWhile(Char.IsDigit).ToArray()),
                LineRoute = GetLineRoute(),
                LineColor = lineEntity.LineColor
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