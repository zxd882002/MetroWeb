using MetroWebLibrary;

namespace MetroWebWcfService
{
    public class StationLineInfoAdapter : IAdapter<StationLineInfo>
    {
        private StationLineEntity stationLineEntity;

        public StationLineInfoAdapter(StationLineEntity stationLineEntity)
        {
            this.stationLineEntity = stationLineEntity;
        }

        public StationLineInfo ToObject()
        {
            return new StationLineInfo
            {
                LineInfo = new LineInfoAdapter(stationLineEntity.Line).ToObject(),
                StartEndTime = GetStartEndTime()
            };
        }

        private StartEndTime GetStartEndTime()
        {
            return new StartEndTime
            {
                StartTime = stationLineEntity.StartTime.ToString("t"),
                EndTime = stationLineEntity.EndTime.ToString("t")
            };
        }
    }
}