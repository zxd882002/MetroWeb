using System;
using System.Collections.Generic;
using System.Data;
using DatabaseAccessLibrary.Interface;
using DatabaseAccessLibrary.Model;

namespace DatabaseAccessLibrary.Table
{
    public class LineTable : TableBase<Line>
    {
        public LineTable(IConnector connector)
            : base(connector)
        {
            SelectQuery = "SELECT l.Line_Id, l.Line_Name, s1.Station_id AS Line_From_Station_Id, s1.Station_Name AS Line_From_Station_Name, s2.Station_id AS Line_To_Station_Id, s2.Station_Name AS Line_To_Station_Name FROM Line AS l INNER JOIN Station AS s1 ON s1.station_Id = l.Line_From_Station_Id INNER JOIN Station AS s2 ON s2.station_Id = l.Line_From_Station_Id ";
            InsertQuery = "INSERT INTO Line VALUES (@Line_Id, @Line_Name, @Line_From_Station_Id, @Line_To_Station_Id)";
            DeleteQuery = "DELETE FROM Line";
            UpdateQuery = "UPDATE Line";
            DataReaderHandler = () =>
            {
                List<ITableRow> lineList = new List<ITableRow>();
                IDataReader reader = connector.Reader;
                while (reader.Read())
                {
                    int lineId = Convert.ToInt32(reader["Line_Id"]);
                    string lineName = Convert.ToString(reader["Line_Name"]);
                    int lineFromStationId = Convert.ToInt32(reader["Line_From_Station_Id"]);
                    string lineFromStationName = Convert.ToString(reader["Line_From_Station_Name"]);
                    Station lineFromStation = new Station
                    {
                        StationId = lineFromStationId,
                        StationName = lineFromStationName
                    };
                    int lineToStationId = Convert.ToInt32(reader["Line_To_Station_Id"]);
                    string lineToStationName = Convert.ToString(reader["Line_To_Station_Name"]);
                    Station lineToStation = new Station
                    {
                        StationId = lineToStationId,
                        StationName = lineToStationName
                    };
                    lineList.Add(new Line
                    {
                        LineId = lineId,
                        LineName = lineName,
                        LineFromStation = lineFromStation,
                        LineToStation = lineToStation
                    });
                }
                return lineList;
            };
        }

        protected override Dictionary<string, object> SetParameters(Line tableRow)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@Line_Id", tableRow.LineId);
            parameters.Add("@Line_Name", tableRow.LineName);
            parameters.Add("@Line_From_Station_Id", tableRow.LineFromStation.StationId);
            parameters.Add("@Line_To_Station_Id", tableRow.LineToStation.StationId);
            return parameters;
        }
    }
}
