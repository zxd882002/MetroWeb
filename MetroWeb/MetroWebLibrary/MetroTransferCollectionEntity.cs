using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DatabaseAccessLibrary.Model;

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

        #region Get MetroTransfer list by from station line id
        private List<MetroTransferEntity> GetMetroTransferListByFromStationLineId(int stationLineId)
        {
            if (metroTransferEntityList == null)
                metroTransferEntityList = new List<MetroTransferEntity>();

            List<MetroTransferEntity> matchedMetroTransferList = SearchMetroTransferFromMetroTransferEntityListByFromStationLinenId(stationLineId);

            try
            {
                List<MetroTransferEntity> metroTransferList = SeachMetroTransferByFromStationLineIdQuery(stationLineId);
                matchedMetroTransferList.AddRange(metroTransferList);
                metroTransferEntityList.AddRange(metroTransferList);
            }
            catch (Exception exception)
            {
                throw exception;
            }

            return matchedMetroTransferList;
        }

        private List<MetroTransferEntity> SearchMetroTransferFromMetroTransferEntityListByFromStationLinenId(int stationLineId)
        {
            return metroTransferEntityList.FindAll(metroTransfer => metroTransfer.FromStationLine.StationLineId == stationLineId);
        }

        private List<MetroTransferEntity> SeachMetroTransferByFromStationLineIdQuery(int stationLineId)
        {
            List<MetroTransfer> matchedMetroTransferList =
               metroWeb.MetroWebDatabase.Table<MetroTransfer>().Select(new MetroTransfer { FromStationLineId = stationLineId });

            if (matchedMetroTransferList.Count == 0)
                throw new Exception(string.Format("The from station line id {0} is not found.", stationLineId));

            List<MetroTransferEntity> matchedMetroTransferEntityList = new List<MetroTransferEntity>();
            foreach (MetroTransfer matchedMetroTransfer in matchedMetroTransferList)
            {
                if (!metroTransferEntityList.Exists(metroTransfer => metroTransfer.TransferId == matchedMetroTransfer.TransferId))
                {
                    MetroTransferEntity matchedMetroTransferEntity = new MetroTransferEntity(metroWeb, matchedMetroTransfer);
                    matchedMetroTransferEntityList.Add(matchedMetroTransferEntity);
                }
            }
            return matchedMetroTransferEntityList;
        }
        #endregion

        #region Get MetroTransfer list by to station line id
        private List<MetroTransferEntity> GetMetroTransferListByToStationLineId(int stationLineId)
        {
            if (metroTransferEntityList == null)
                metroTransferEntityList = new List<MetroTransferEntity>();

            List<MetroTransferEntity> matchedMetroTransferList = SearchMetroTransferFromMetroTransferEntityListByToStationLinenId(stationLineId);

            try
            {
                List<MetroTransferEntity> metroTransferList = SeachMetroTransferByToStationLineIdQuery(stationLineId);
                matchedMetroTransferList.AddRange(metroTransferList);
                metroTransferEntityList.AddRange(metroTransferList);
            }
            catch (Exception exception)
            {
                throw exception;
            }

            return matchedMetroTransferList;
        }

        private List<MetroTransferEntity> SearchMetroTransferFromMetroTransferEntityListByToStationLinenId(int stationLineId)
        {
            return metroTransferEntityList.FindAll(metroTransfer => metroTransfer.ToStationLine.StationLineId == stationLineId);
        }

        private List<MetroTransferEntity> SeachMetroTransferByToStationLineIdQuery(int stationLineId)
        {
            List<MetroTransfer> matchedMetroTransferList =
               metroWeb.MetroWebDatabase.Table<MetroTransfer>().Select(new MetroTransfer { ToStationLineId = stationLineId });

            if (matchedMetroTransferList.Count == 0)
                throw new Exception(string.Format("The from station line id {0} is not found.", stationLineId));

            List<MetroTransferEntity> matchedMetroTransferEntityList = new List<MetroTransferEntity>();
            foreach (MetroTransfer matchedMetroTransfer in matchedMetroTransferList)
            {
                if (!metroTransferEntityList.Exists(metroTransfer => metroTransfer.TransferId == matchedMetroTransfer.TransferId))
                {
                    MetroTransferEntity matchedMetroTransferEntity = new MetroTransferEntity(metroWeb, matchedMetroTransfer);
                    matchedMetroTransferEntityList.Add(matchedMetroTransferEntity);
                }
            }
            return matchedMetroTransferEntityList;
        }
        #endregion
    }
}
