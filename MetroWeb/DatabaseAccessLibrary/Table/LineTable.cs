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
            SelectQuery = "SELECT * FROM Line";
            InsertQuery = "INSERT INTO Line VALUES (@Line_Id, @Line_Name, @Line_From_Station_Id, @Line_To_Station_Id)";
            DeleteQuery = "DELETE FROM Line";
            UpdateQuery = "UPDATE Line";
            DataReaderHandler = () =>
            {
                List<Line> lineList = new List<Line>();
                IDataReader reader = connector.Reader;
                while (reader.Read())
                {
                    int lineId = Convert.ToInt32(reader["Line_Id"]);
                    string lineName = Convert.ToString(reader["Line_Name"]);
                    int lineFromStationId = Convert.ToInt32(reader["Line_From_Station_Id"]);
                    int lineToStationId = Convert.ToInt32(reader["Line_To_Station_Id"]);
                    lineList.Add(new Line
                    {
                        LineId = lineId,
                        LineName = lineName,
                        LineFromStationId = lineFromStationId,
                        LineToStationId = lineToStationId
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
            parameters.Add("@Line_From_Station_Id", tableRow.LineFromStationId);
            parameters.Add("@Line_To_Station_Id", tableRow.LineToStationId);
            return parameters;
        }
    }
}
