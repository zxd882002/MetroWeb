using MetroWebLibrary;

namespace MetroWebWcfService
{
    public class NameGraphAdapter : IAdapter<NameGraph>
    {
        private StationEntity stationEntity;

        public NameGraphAdapter(StationEntity stationEntity)
        {
            this.stationEntity = stationEntity;
        }

        public NameGraph ToObject()
        {
            return new NameGraph
            {
                x = stationEntity.StationNameX,
                y = stationEntity.StationNameY,
                text = stationEntity.StationName
            };
        }
    }
}