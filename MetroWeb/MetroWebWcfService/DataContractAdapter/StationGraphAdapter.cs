using MetroWebLibrary;

namespace MetroWebWcfService
{
    public class StationGraphAdapter : IAdapter<StationGraph>
    {
        private StationEntity stationEntity;

        public StationGraphAdapter(StationEntity stationEntity)
        {
            this.stationEntity = stationEntity;

        }

        public StationGraph ToObject()
        {
            return new StationGraph
            {
                x = stationEntity.StationX,
                y = stationEntity.StationY
            };
        }
    }
}