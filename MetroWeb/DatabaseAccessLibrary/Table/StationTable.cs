using System;
using System.Collections.Generic;
using System.Data;
using DatabaseAccessLibrary.Interface;
using DatabaseAccessLibrary.Model;

namespace DatabaseAccessLibrary.Table
{
    public class StationTable : TableBase<Station>
    {
        public StationTable(IConnector connector)
            : base(connector)
        {
            SelectQuery = "SELECT * FROM Station";
            InsertQuery = "INSERT INTO Station VALUES (@Station_Id, @Station_Name)";
            DeleteQuery = "DELETE FROM Station";
            UpdateQuery = "UPDATE Station";
            DataReaderHandler = () =>
            {
                List<Station> stationList = new List<Station>();
                IDataReader reader = connector.Reader;
                while (reader.Read())
                {
                    int stationId = Convert.ToInt32(reader["Station_Id"]);
                    string stationName = Convert.ToString(reader["Station_Name"]);
                    stationList.Add(new Station { StationId = stationId, StationName = stationName });
                }
                return stationList;
            };
        }

        protected override Dictionary<string, object> SetParameters(Station tableRow)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@Station_Id", tableRow.StationId);
            parameters.Add("@Station_Name", tableRow.StationName);
            return parameters;
        }
    }
}
