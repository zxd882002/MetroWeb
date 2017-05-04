using System.Collections.Generic;
using MetroWebLibrary;

namespace MetroWebWcfService
{
    public class StationInfoAdapter : StationInfo
    {
        public StationInfoAdapter(StationEntity stationEntity)
        {
            StationId = stationEntity.StationId;
            StationName = stationEntity.StationName;
            StationGraph = new StationGraphAdapter(stationEntity);
            NameGraph = new NameGraphAdapter(stationEntity);

            List<StationLineEntity> stationLineEntityList = stationEntity.StationLineList;
            List<StationLineInfo> stationLineInfoList = new List<StationLineInfo>();
            foreach (var stationLineEntity in stationLineEntityList)
            {
                StationLineInfo stationLineInfo = new StationLineInfoAdapter(stationLineEntity);
                stationLineInfoList.Add(stationLineInfo);
            }
            StationLines = stationLineInfoList.ToArray();
        }
    }
}