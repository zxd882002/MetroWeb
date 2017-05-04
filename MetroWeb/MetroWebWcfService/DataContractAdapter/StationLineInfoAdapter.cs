using MetroWebLibrary;

namespace MetroWebWcfService
{
    public class StationLineInfoAdapter : StationLineInfo
    {
        public StationLineInfoAdapter(StationLineEntity stationLineEntity)
        {
            LineInfo = new LineInfoAdapter(stationLineEntity.Line);
            StartTime = stationLineEntity.StartTime;
            EndTime = stationLineEntity.EndTime;
        }
    }
}