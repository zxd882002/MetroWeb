using System;
using System.Collections.Generic;
using System.Data;
using DatabaseAccessLibrary.Interface;
using DatabaseAccessLibrary.Model;

namespace DatabaseAccessLibrary.Table
{
    public class StationLineTable : TableBase<StationLine>
    {
        public StationLineTable(IConnector connector)
            : base(connector)
        {
            SelectQuery = "SELECT * FROM StationLine";
            InsertQuery = "INSERT INTO StationLine VALUES (@Station_Line_Id, @Line_Id, @Station_Id, @Time_Wait, @Time_Arrived, @Start_Time, @End_Time)";
            DeleteQuery = "DELETE FROM StationLine";
            UpdateQuery = "UPDATE StationLine";
            DataReaderHandler = () =>
            {
                List<StationLine> stationLineList = new List<StationLine>();
                IDataReader reader = connector.Reader;
                while (reader.Read())
                {
                    int stationLineId = Convert.ToInt32(reader["Station_Line_Id"]);
                    int lineId = Convert.ToInt32(reader["Line_Id"]);
                    int stationId = Convert.ToInt32(reader["Station_Id"]);
                    TimeSpan timeWait = (TimeSpan)reader["Time_Wait"];
                    TimeSpan timeArrived = (TimeSpan)reader["Time_Arrived"];
                    DateTime startTime = DateTime.Today.Add((TimeSpan)reader["Start_Time"]);
                    DateTime endTime = DateTime.Today.Add((TimeSpan)reader["End_Time"]);

                    stationLineList.Add(new StationLine
                    {
                        StationLineId = stationLineId,
                        LineId = lineId,
                        StationId = stationId,
                        TimeWait = timeWait,
                        TimeArrived = timeArrived,
                        StartTime = startTime,
                        EndTime = endTime
                    });
                }
                return stationLineList;
            };
        }

        protected override Dictionary<string, object> SetParameters(StationLine tableRow)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@Station_Line_Id", tableRow.StationLineId);
            parameters.Add("@Line_Id", tableRow.LineId);
            parameters.Add("@Station_Id", tableRow.StationId);
            parameters.Add("@Time_Wait", tableRow.TimeWait);
            parameters.Add("@Time_Arrived", tableRow.TimeArrived);
            parameters.Add("@Start_Time", tableRow.StartTime);
            parameters.Add("@End_Time", tableRow.EndTime);
            return parameters;
        }
    }
}
