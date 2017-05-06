using System.Collections.Generic;
using MetroWebLibrary;

namespace MetroWebWcfService
{
    public class StationInfoAdapter : IAdapter<StationInfo>
    {
        private StationEntity stationEntity;

        public StationInfoAdapter(StationEntity stationEntity)
        {
            this.stationEntity = stationEntity;
        }

        public StationInfo ToObject()
        {
            StationInfo stationInfo = new StationInfo();

            stationInfo.StationId = stationEntity.StationId;
            stationInfo.StationName = stationEntity.StationName;
            stationInfo.StationGraph = new StationGraphAdapter(stationEntity).ToObject();
            stationInfo.NameGraph = new NameGraphAdapter(stationEntity).ToObject();

            List<StationLineEntity> stationLineEntityList = stationEntity.StationLineList;
            List<StationLineInfo> stationLineInfoList = new List<StationLineInfo>();
            foreach (var stationLineEntity in stationLineEntityList)
            {
                StationLineInfo stationLineInfo = new StationLineInfoAdapter(stationLineEntity).ToObject();
                stationLineInfoList.Add(stationLineInfo);
            }
            stationInfo.StationLines = stationLineInfoList.ToArray();

            return stationInfo;
        }
    }
}