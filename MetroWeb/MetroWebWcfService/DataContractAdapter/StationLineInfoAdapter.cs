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

        private string GetStartEndTime()
        {
            return string.Format("{0} - {1}", stationLineEntity.StartTime, stationLineEntity.EndTime);
        }
    }
}