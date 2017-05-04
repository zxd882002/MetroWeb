using MetroWebLibrary;

namespace MetroWebWcfService
{
    public class StationGraphAdapter : StationGraph
    {
        public StationGraphAdapter(StationEntity stationEntity)
        {
            x = stationEntity.StationX;
            y = stationEntity.StationY;
        }
    }
}