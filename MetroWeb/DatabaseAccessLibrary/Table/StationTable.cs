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
            InsertQuery = "INSERT INTO Station VALUES (@Station_Id, @Station_Name, @Station_X, @Station_Y, @Station_Name_X, @Station_Name_Y)";
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
                    int stationX = Convert.ToInt32(reader["Station_X"]);
                    int stationY = Convert.ToInt32(reader["Station_Y"]);
                    int stationNameX = Convert.ToInt32(reader["Station_Name_X"]);
                    int stationNameY = Convert.ToInt32(reader["Station_Name_Y"]);
                    stationList.Add(new Station
                    {
                        StationId = stationId, 
                        StationName = stationName,
                        StationX = stationX,
                        StationY = stationY,
                        StationNameX = stationNameX,
                        StationNameY = stationNameY
                    });
                }
                return stationList;
            };
        }

        protected override Dictionary<string, object> SetParameters(Station tableRow)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@Station_Id", tableRow.StationId);
            parameters.Add("@Station_Name", tableRow.StationName);
            parameters.Add("@Station_X", tableRow.StationX);
            parameters.Add("@Station_Y", tableRow.StationY);
            parameters.Add("@Station_Name_X", tableRow.StationNameX);
            parameters.Add("@Station_Name_Y", tableRow.StationNameY);
            return parameters;
        }
    }
}
