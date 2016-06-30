using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using DatabaseAccessLibrary.Interface;

namespace DatabaseAccessLibrary
{
    public class LineTable : ITable<Line>
    {
        private IDatabase metroWebDatabase;
        private IConnector connector;
        private const string SelectQuery = "SELECT * FROM Line";
        private const string InsertQuery = "INSERT INTO Line VALUES (@LineId, @LineName, @LineFromStationId, @LineToStationId)";
        private const string DeleteQuery = "DELETE FROM Line";
        private const string UpdateQuery = "UPDATE Line";
        private const string WhereLineId = "Line_Id = @LineId";
        private const string WhereLineName = "Line_Name = @LineName";
        private const string WhereLineFromStationId = "Line_From_Station_Id = @LineFromStationId";
        private const string WhereLineToStationId = "Line_To_Station_Id = @LineToStationId";
        private const string SetLineId = "Line_Id = @newLineId";
        private const string SetLineName = "Line_Name = @newLineName";
        private const string SetLineFromStationId = "Line_From_Station_Id = @newLineFromStationId";
        private const string SetLineToStationId = "Line_To_Station_Id = @newLineToStationId";

        public LineTable(IDatabase metroWebDatabase, IConnector connector)
        {
            this.metroWebDatabase = metroWebDatabase;
            this.connector = connector;
        }

        public List<Line> Select()
        {
            return Select(new Line());
        }

        public List<Line> Select(Line searchCriteria)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            string whereClause = GenerateWhereClause(searchCriteria, ref parameters);
            string query = SelectQuery + whereClause;
            List<Line> lineList = new List<Line>();
            connector.ExecuteReader(query, parameters,
                () =>
                {
                    IDataReader reader = connector.Reader;
                    while (reader.Read())
                    {
                        int lineId = Convert.ToInt32(reader["Line_Id"]);
                        string lineName = Convert.ToString(reader["Line_Name"]);
                        Station lineFromStation =
                            metroWebDatabase.Table<Station>()
                                .Select(new Station { StationId = Convert.ToInt32(reader["Line_From_Station_Id"]) })[0];
                        Station lineToStation =
                            metroWebDatabase.Table<Station>()
                                .Select(new Station { StationId = Convert.ToInt32(reader["Line_To_Station_Id"]) })[0];
                        lineList.Add(new Line
                        {
                            LineId = lineId,
                            LineName = lineName,
                            LineFromStation = lineFromStation,
                            LineToStation = lineToStation
                        });
                    }
                });
            return lineList;
        }

        public bool Insert(Line tableRow)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@LineId", tableRow.LineId);
            parameters.Add("@LineName", tableRow.LineName);
            parameters.Add("@LineFromStationId", tableRow.LineFromStation.StationId);
            parameters.Add("@LineToStationId", tableRow.LineToStation.StationId);
            int affectedRowCount = connector.ExecuteNonQuery(InsertQuery, parameters);
            return affectedRowCount == 1;
        }

        public bool Delete(Line searchCriteria)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            string whereClause = GenerateWhereClause(searchCriteria, ref parameters);
            string query = DeleteQuery + whereClause;
            int affectedRowCount = connector.ExecuteNonQuery(query, parameters);
            return affectedRowCount > 0;
        }

        public bool Update(Line searchCriteria, Line newTableRow)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            string setClause = GenerateSetClause(newTableRow, ref parameters);
            string whereClause = GenerateWhereClause(searchCriteria, ref parameters);
            string query = UpdateQuery + setClause + whereClause;
            int affectedRowCount = connector.ExecuteNonQuery(query, parameters);
            return affectedRowCount > 0;
        }

        private string GenerateSetClause(Line newTableRow, ref Dictionary<string, object> parameters)
        {
            StringBuilder setClause = new StringBuilder();
            bool needAnd = false;
            if (newTableRow.LineId != default(int))
            {
                setClause.Append(" SET ");
                setClause.Append(SetLineId);
                parameters.Add("@newLineId", newTableRow.LineId);
                needAnd = true;
            }
            if (newTableRow.LineName != default(string))
            {
                if (needAnd)
                    setClause.Append(" , ");
                else
                    setClause.Append(" SET ");
                setClause.Append(SetLineName);
                parameters.Add("@newLineName", newTableRow.LineName);
                needAnd = true;
            }
            if (newTableRow.LineFromStation != default(Station))
            {
                if (needAnd)
                    setClause.Append(" , ");
                else
                    setClause.Append(" SET ");
                setClause.Append(SetLineFromStationId);
                parameters.Add("@newLineFromStationId", newTableRow.LineFromStation.StationId);
                needAnd = true;
            }
            if (newTableRow.LineToStation != default(Station))
            {
                if (needAnd)
                    setClause.Append(" , ");
                else
                    setClause.Append(" SET ");
                setClause.Append(SetLineToStationId);
                parameters.Add("@newLineToStationId", newTableRow.LineToStation.StationId);
            }
            return setClause.ToString();
        }

        private string GenerateWhereClause(Line searchCriteria, ref Dictionary<string, object> parameters)
        {
            StringBuilder whereClause = new StringBuilder();
            bool needAnd = false;
            if (searchCriteria.LineId != default(int))
            {
                whereClause.Append(" WHERE ");
                whereClause.Append(WhereLineId);
                parameters.Add("@LineId", searchCriteria.LineId);
                needAnd = true;
            }
            if (searchCriteria.LineName != default(string))
            {
                if (needAnd)
                    whereClause.Append(" AND ");
                else
                    whereClause.Append(" WHERE ");
                whereClause.Append(WhereLineName);
                parameters.Add("@LineName", searchCriteria.LineName);
                needAnd = true;
            }
            if (searchCriteria.LineFromStation != default(Station))
            {
                if (needAnd)
                    whereClause.Append(" AND ");
                else
                    whereClause.Append(" WHERE ");
                whereClause.Append(WhereLineFromStationId);
                parameters.Add("@LineFromStationId", searchCriteria.LineFromStation.StationId);
                needAnd = true;
            }
            if (searchCriteria.LineToStation != default(Station))
            {
                if (needAnd)
                    whereClause.Append(" AND ");
                else
                    whereClause.Append(" WHERE ");
                whereClause.Append(WhereLineToStationId);
                parameters.Add("@LineToStationId", searchCriteria.LineToStation.StationId);
            }
            return whereClause.ToString();
        }
    }
}
