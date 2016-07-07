using System;
using System.Collections.Generic;
using System.Linq;
using DatabaseAccessLibrary.Model;

namespace MetroWebLibrary
{
    public class StationCollectionEntity
    {
        private List<StationEntity> stationList;
        private MetroWebEntity metroWeb;

        public StationCollectionEntity(MetroWebEntity metroWeb)
        {
            this.metroWeb = metroWeb;
        }

        #region Get all station list
        public List<StationEntity> All
        {
            get
            {
                if (stationList == null)
                    stationList = new List<StationEntity>();

                stationList.AddRange(SeachStationByQuery());
                return stationList;
            }
        }

        private List<StationEntity> SeachStationByQuery()
        {
            List<Station> matchedStationList =
                metroWeb.MetroWebDatabase.Table<Station>().Select();

            List<StationEntity> matchedStationEntityList = new List<StationEntity>();
            foreach (Station matchedStation in matchedStationList)
            {
                if (!stationList.Exists(station => station.StationId == matchedStation.StationId))
                {
                    StationEntity stationEntity = new StationEntity(metroWeb, matchedStation);
                    matchedStationEntityList.Add(stationEntity);
                }
            }
            return matchedStationEntityList;
        }
        #endregion

        #region Get Station List By Station Name
        public List<StationEntity> this[string stationName]
        {
            get
            {
                if (stationList == null)
                    stationList = new List<StationEntity>();

                List<StationEntity> matchedStationList = SearchStationFromStationList(stationName);

                try
                {
                    List<StationEntity> matchedStationFromQueryList = SeachStationByQuery(stationName);
                    matchedStationList.AddRange(matchedStationFromQueryList);
                    stationList.AddRange(matchedStationFromQueryList);
                }
                catch (Exception exception)
                {
                    throw exception;
                }

                return matchedStationList;
            }
        }

        private List<StationEntity> SearchStationFromStationList(string stationName)
        {
            return stationList.FindAll(station => station.StationName == stationName);
        }

        private List<StationEntity> SeachStationByQuery(string stationName)
        {
            List<Station> matchedStationList =
                metroWeb.MetroWebDatabase.Table<Station>().Select(new Station { StationName = stationName });
            List<StationEntity> matchedStationEntityList = new List<StationEntity>();
            foreach (Station matchedStation in matchedStationList)
            {
                if (!stationList.Exists(station => station.StationId == matchedStation.StationId))
                {
                    StationEntity stationEntity = new StationEntity(metroWeb, matchedStation);
                    matchedStationEntityList.Add(stationEntity);
                }
            }
            return matchedStationEntityList;
        }
        #endregion

        #region Get Station By Station Id
        public StationEntity this[int stationId]
        {
            get
            {
                if (stationList == null)
                    stationList = new List<StationEntity>();

                StationEntity matchedStation = SearchStationFromStationList(stationId);

                if (matchedStation == null)
                {
                    try
                    {
                        matchedStation = SeachStationByQuery(stationId);
                        stationList.Add(matchedStation);
                    }
                    catch (Exception exception)
                    {
                        throw exception;
                    }
                }
                return matchedStation;
            }
        }

        private StationEntity SearchStationFromStationList(int stationId)
        {
            return stationList.Find(station => station.StationId == stationId);
        }

        private StationEntity SeachStationByQuery(int stationId)
        {
            List<Station> matchedStationList =
                metroWeb.MetroWebDatabase.Table<Station>().Select(new Station { StationId = stationId });

            if (matchedStationList.Count == 0)
                throw new Exception(string.Format("The station id {0} is not found.", stationId));

            StationEntity matchedStationEntity = new StationEntity(metroWeb, matchedStationList[0]);
            return matchedStationEntity;
        }
        #endregion

        #region Get Station By Station Name and line name
        public StationEntity this[string stationName, string lineName]
        {
            get
            {
                if (stationList == null)
                    stationList = new List<StationEntity>();

                StationEntity matchedStation = SearchStationFromStationList(stationName, lineName);

                if (matchedStation == null)
                {
                    try
                    {
                        matchedStation = SeachStationByQuery(stationName, lineName);
                        stationList.Add(matchedStation);
                    }
                    catch (Exception exception)
                    {
                        throw exception;
                    }
                }
                return matchedStation;
            }
        }

        private StationEntity SearchStationFromStationList(string stationName, string lineName)
        {
            return
                stationList.Find(
                    station =>
                        station.StationName == stationName &&
                        station.LineList.Exists(line => line.LineName == lineName));
        }

        private StationEntity SeachStationByQuery(string stationName, string lineName)
        {
            // get all matched stations
            List<StationEntity> matchedStationList = metroWeb.StationList[stationName];
            if (matchedStationList.Count == 0)
                throw new Exception(string.Format("The station {0} is not found.", stationName));

            // get all matched lines
            List<LineEntity> matchedlineList = metroWeb.LineList[lineName];

            if (matchedlineList.Count == 0)
                throw new Exception(string.Format("The line {0} is not found.", lineName));

            // combine them
            List<StationLineEntity> stationLines = new List<StationLineEntity>();
            foreach (StationEntity station in matchedStationList)
            {
                foreach (LineEntity line in matchedlineList)
                {
                    stationLines.Add(metroWeb.StationLineList[station.StationId, line.LineId]);
                }
            }

            if (stationLines.Count == 0)
                throw new Exception(string.Format("The station {0} in line {1} is not found.", stationName, lineName));

            int searchedStationId = stationLines[0].Station.StationId;

            if (stationLines.Any(stationLine => stationLine.Station.StationId != searchedStationId))
            {
                throw new Exception(string.Format("The station {0} in line {1} is ambiguous. Please choose other way to identify.", stationName, lineName));
            }

            // find it
            StationEntity searchedStation = matchedStationList.Find(station => station.StationId == searchedStationId);
            return searchedStation;
        }
        #endregion
    }
}
