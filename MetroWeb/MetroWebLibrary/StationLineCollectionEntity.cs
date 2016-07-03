using System;
using System.Collections.Generic;
using DatabaseAccessLibrary.Model;

namespace MetroWebLibrary
{
    public enum IDType
    {
        StationId,
        LineId
    }

    public class StationLineCollectionEntity
    {
        private MetroWebEntity metroWeb;
        private List<StationLineEntity> stationLineList;

        internal StationLineCollectionEntity(MetroWebEntity metroWeb)
        {
            this.metroWeb = metroWeb;
        }

        #region Get StationLine list By station id or line id
        public List<StationLineEntity> this[int id, IDType idType]
        {
            get
            {
                switch (idType)
                {
                    case IDType.StationId:
                        return GetStationLineEntityListByStationId(id);
                    case IDType.LineId:
                        return GetStationLineEntityListByLineId(id);
                }
                throw new Exception("Unknown id type");
            }
        }
        #endregion

        #region Get StationLine list By station id
        private List<StationLineEntity> GetStationLineEntityListByStationId(int stationId)
        {
            if (stationLineList == null)
                stationLineList = new List<StationLineEntity>();

            List<StationLineEntity> matchedStationLineList = SearchStationLineFromStationLineListByStationId(stationId);

            try
            {
                matchedStationLineList.AddRange(SeachStationLineByStationIdQuery(stationId));
                stationLineList.AddRange(matchedStationLineList);
            }
            catch (Exception exception)
            {
                throw exception;
            }

            return matchedStationLineList;
        }

        private List<StationLineEntity> SearchStationLineFromStationLineListByStationId(int stationId)
        {
            return stationLineList.FindAll(stationLine => stationLine.Station.StationId == stationId);
        }

        private List<StationLineEntity> SeachStationLineByStationIdQuery(int stationId)
        {
            List<StationLine> matchedStationLineList =
               metroWeb.MetroWebDatabase.Table<StationLine>().Select(new StationLine { StationId = stationId });

            if (matchedStationLineList.Count == 0)
                throw new Exception(string.Format("The station id {0} is not found.", stationId));

            List<StationLineEntity> matchedStationLineEntityList = new List<StationLineEntity>();
            foreach (StationLine matchedStationLine in matchedStationLineList)
            {
                if (!stationLineList.Exists(stationLine => stationLine.StationLineId == matchedStationLine.StationLineId))
                {
                    StationLineEntity matchedStationLineEntity = new StationLineEntity(metroWeb, matchedStationLine);
                    matchedStationLineEntityList.Add(matchedStationLineEntity);
                }
            }
            return matchedStationLineEntityList;
        }
        #endregion

        #region Get StationLine list By line id
        private List<StationLineEntity> GetStationLineEntityListByLineId(int lineId)
        {
            if (stationLineList == null)
                stationLineList = new List<StationLineEntity>();

            List<StationLineEntity> matchedStationLineList = SearchStationLineFromStationLineListByLineId(lineId);

            try
            {
                matchedStationLineList.AddRange(SeachStationLineByLineIdQuery(lineId));
                stationLineList.AddRange(matchedStationLineList);
            }
            catch (Exception exception)
            {
                throw exception;
            }

            return matchedStationLineList;
        }

        private List<StationLineEntity> SearchStationLineFromStationLineListByLineId(int lineId)
        {
            return stationLineList.FindAll(stationLine => stationLine.Line.LineId == lineId);
        }

        private List<StationLineEntity> SeachStationLineByLineIdQuery(int lineId)
        {
            List<StationLine> matchedStationLineList =
               metroWeb.MetroWebDatabase.Table<StationLine>().Select(new StationLine { LineId = lineId });

            if (matchedStationLineList.Count == 0)
                throw new Exception(string.Format("The line id {0} is not found.", lineId));

            List<StationLineEntity> matchedStationLineEntityList = new List<StationLineEntity>();
            foreach (StationLine matchedStationLine in matchedStationLineList)
            {
                if (
                    !stationLineList.Exists(stationLine => stationLine.StationLineId == matchedStationLine.StationLineId))
                {
                    StationLineEntity matchedStationLineEntity = new StationLineEntity(metroWeb, matchedStationLine);
                    matchedStationLineEntityList.Add(matchedStationLineEntity);
                }
            }
            return matchedStationLineEntityList;
        }
        #endregion

        #region Get StationLine By station id and line id
        public StationLineEntity this[int stationId, int lineId]
        {
            get
            {
                if (stationLineList == null)
                    stationLineList = new List<StationLineEntity>();

                StationLineEntity matchedStationLine = SearchStationLineFromStationLineList(stationId, lineId);

                if (matchedStationLine == null)
                {
                    try
                    {
                        matchedStationLine = SeachStationLineByQuery(stationId, lineId);
                        stationLineList.Add(matchedStationLine);
                    }
                    catch (Exception exception)
                    {
                        throw exception;
                    }
                }

                return matchedStationLine;
            }
        }

        private StationLineEntity SearchStationLineFromStationLineList(int stationId, int lineId)
        {
            return
                stationLineList.Find(
                    stationLine =>
                        stationLine.Station.StationId == stationId &&
                        stationLine.Line.LineId == lineId);
        }

        private StationLineEntity SeachStationLineByQuery(int stationId, int lineId)
        {
            List<StationLine> matchedStationLineList =
               metroWeb.MetroWebDatabase.Table<StationLine>().Select(new StationLine { StationId = stationId, LineId = lineId });

            if (matchedStationLineList.Count == 0)
                throw new Exception(string.Format("The station id {0} with line id {1} is not found.", stationId, lineId));

            StationLineEntity matchedStationLineEntityEntity = new StationLineEntity(metroWeb, matchedStationLineList[0]);
            return matchedStationLineEntityEntity;
        }
        #endregion
    }
}
