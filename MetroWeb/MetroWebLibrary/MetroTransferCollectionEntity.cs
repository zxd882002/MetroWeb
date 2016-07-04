using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MetroWebLibrary
{
    public enum StationLineIdType
    {
        FromStationLineId,
        ToStationLineId
    }

    public class MetroTransferCollectionEntity
    {
        private MetroWebEntity metroWeb;
        private List<MetroTransferEntity> metroTransferEntityList;

        internal MetroTransferCollectionEntity(MetroWebEntity metroWeb)
        {
            this.metroWeb = metroWeb;
        }

        #region Get MetroTransfer list by FromTransferLine or ToTransferLine
        public List<MetroTransferEntity> this[int stationLineId, StationLineIdType stationLineType]
        {
            get
            {
                switch (stationLineType)
                {
                    case StationLineIdType.FromStationLineId:
                        return GetMetroTransferListByFromStationLineId(stationLineId);
                    case StationLineIdType.ToStationLineId:
                        return GetMetroTransferListByToStationLineId(stationLineId);
                }
                throw new Exception("Unknown station line id type");
            }
        }
        #endregion

        private List<MetroTransferEntity> GetMetroTransferListByFromStationLineId(int stationLineId)
        {
            throw new NotImplementedException();
        }

        private List<MetroTransferEntity> GetMetroTransferListByToStationLineId(int stationLineId)
        {
            throw new NotImplementedException();
        }
    }
}
