using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using DatabaseAccessLibrary.Interface;

namespace DatabaseAccessLibrary
{
    public class StationCollection : ITable<Station>
    {
        private IConnector connector;
        private string selectQuery = "SELECT * FROM Station";
        private string whereStationId = "Station_Id = @stationId";
        private string whereStationName = "Station_Name = @StationName";

        public StationCollection(IConnector connector)
        {
            this.connector = connector;
        }

        public List<Station> Select()
        {
            return Select(new Station());
        }

        public List<Station> Select(Station searchCriteria)
        {
            StringBuilder whereClause = new StringBuilder();
            bool needAnd = false;
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            if (searchCriteria.StationId != default(int))
            {
                if (needAnd)
                    whereClause.Append(" AND ");
                else
                    whereClause.Append(" WHERE ");
                whereClause.Append(whereStationId);
                parameters.Add("@stationId", searchCriteria.StationId);
                needAnd = true;
            }
            if (searchCriteria.StationName != default(string))
            {
                if (needAnd)
                    whereClause.Append(" AND ");
                else
                    whereClause.Append(" WHERE ");
                whereClause.Append(whereStationName);
                parameters.Add("@StationName", searchCriteria.StationName);
                needAnd = true;
            }
            string query = selectQuery + whereClause.ToString();
            List<Station> stationList = new List<Station>();
            connector.ExecuteReader(query, parameters,
                () =>
                {
                    IDataReader reader = connector.Reader;
                    while (reader.Read())
                    {
                        int stationId = Convert.ToInt32(reader["STATION_ID"]);
                        string stationName = Convert.ToString(reader["STATION_NAME"]);
                        stationList.Add(new Station { StationId = stationId, StationName = stationName });
                    }
                });
            return stationList;
        }

        public bool Insert(Station tableRow)
        {
            throw new System.NotImplementedException();
        }

        public bool Delete(Station searchCriteria)
        {
            throw new System.NotImplementedException();
        }

        public bool Update(Station searchCriteria, Station tableRow)
        {
            throw new System.NotImplementedException();
        }
    }
}
