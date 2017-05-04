using MetroWebLibrary;

namespace MetroWebWcfService
{
    public class NameGraphAdapter : NameGraph
    {
        public NameGraphAdapter(StationEntity stationEntity)
        {
            x = stationEntity.StationNameX;
            y = stationEntity.StationNameY;
            text = stationEntity.StationName;
        }
    }
}