using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using DatabaseAccessLibrary.Interface;

namespace DatabaseAccessLibrary
{
    public class StationTable : ITable<Station>
    {
        private IConnector connector;
        private const string SelectQuery = "SELECT * FROM Station";
        private const string InsertQuery = "INSERT INTO Station VALUES (@StationId, @StationName)";
        private const string DeleteQuery = "DELETE FROM Station";
        private const string UpdateQuery = "UPDATE Station";
        private const string WhereStationId = "Station_Id = @StationId";
        private const string WhereStationName = "Station_Name = @StationName";
        private const string SetStationId = "Station_Id = @newStationId";
        private const string SetStationName = "Station_Name = @newStationName";

        public StationTable(IConnector connector)
        {
            this.connector = connector;
        }

        public List<Station> Select()
        {
            return Select(new Station());
        }

        public List<Station> Select(Station searchCriteria)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            string whereClause = GenerateWhereClause(searchCriteria, ref parameters);
            string query = SelectQuery + whereClause;
            List<Station> stationList = new List<Station>();
            connector.ExecuteReader(query, parameters,
                () =>
                {
                    IDataReader reader = connector.Reader;
                    while (reader.Read())
                    {
                        int stationId = Convert.ToInt32(reader["Station_Id"]);
                        string stationName = Convert.ToString(reader["Station_Name"]);
                        stationList.Add(new Station { StationId = stationId, StationName = stationName });
                    }
                });
            return stationList;
        }

        public bool Insert(Station tableRow)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@StationId", tableRow.StationId);
            parameters.Add("@StationName", tableRow.StationName);
            int affectedRowCount = connector.ExecuteNonQuery(InsertQuery, parameters);
            return affectedRowCount == 1;
        }

        public bool Delete(Station searchCriteria)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            string whereClause = GenerateWhereClause(searchCriteria, ref parameters);
            string query = DeleteQuery + whereClause;
            int affectedRowCount = connector.ExecuteNonQuery(query, parameters);
            return affectedRowCount > 0;
        }

        public bool Update(Station searchCriteria, Station newTableRow)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            string setClause = GenerateSetClause(newTableRow, ref parameters);
            string whereClause = GenerateWhereClause(searchCriteria, ref parameters);
            string query = UpdateQuery + setClause + whereClause;
            int affectedRowCount = connector.ExecuteNonQuery(query, parameters);
            return affectedRowCount > 0;
        }

        private string GenerateSetClause(Station newTableRow, ref Dictionary<string, object> parameters)
        {
            StringBuilder setClause = new StringBuilder();
            bool needAnd = false;
            if (newTableRow.StationId != default(int))
            {
                setClause.Append(" SET ");
                setClause.Append(SetStationId);
                parameters.Add("@newStationId", newTableRow.StationId);
                needAnd = true;
            }
            if (newTableRow.StationName != default(string))
            {
                if (needAnd)
                    setClause.Append(" , ");
                else
                    setClause.Append(" SET ");
                setClause.Append(SetStationName);
                parameters.Add("@newStationName", newTableRow.StationName);
            }
            return setClause.ToString();
        }

        private string GenerateWhereClause(Station searchCriteria, ref Dictionary<string, object> parameters)
        {
            StringBuilder whereClause = new StringBuilder();
            bool needAnd = false;
            if (searchCriteria.StationId != default(int))
            {
                whereClause.Append(" WHERE ");
                whereClause.Append(WhereStationId);
                parameters.Add("@StationId", searchCriteria.StationId);
                needAnd = true;
            }
            if (searchCriteria.StationName != default(string))
            {
                if (needAnd)
                    whereClause.Append(" AND ");
                else
                    whereClause.Append(" WHERE ");
                whereClause.Append(WhereStationName);
                parameters.Add("@StationName", searchCriteria.StationName);
            }
            return whereClause.ToString();
        }
    }
}
