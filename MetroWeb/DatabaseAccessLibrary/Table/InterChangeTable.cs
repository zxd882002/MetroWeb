using System;
using System.Collections.Generic;
using System.Data;
using DatabaseAccessLibrary.Interface;
using DatabaseAccessLibrary.Model;

namespace DatabaseAccessLibrary.Table
{
    public class InterChangeTable : TableBase<InterChange>
    {
        public InterChangeTable(IConnector connector)
            : base(connector)
        {
            SelectQuery = "SELECT * FROM InterChange";
            InsertQuery = "INSERT INTO InterChange VALUES (@Inter_Change_Id, @From_Station_Line_Id, @To_Station_Line_Id, @Cost)";
            DeleteQuery = "DELETE FROM InterChange";
            UpdateQuery = "UPDATE InterChange";
            DataReaderHandler = () =>
            {
                List<InterChange> interChangeList = new List<InterChange>();
                IDataReader reader = connector.Reader;
                while (reader.Read())
                {
                    int InterChangeId = Convert.ToInt32(reader["Inter_Change_Id"]);
                    int fromStationLineId = Convert.ToInt32(reader["From_Station_Line_Id"]);
                    int toStationLineId = Convert.ToInt32(reader["To_Station_Line_Id"]);
                    TimeSpan cost = (TimeSpan)reader["Cost"];

                    interChangeList.Add(new InterChange
                    {
                        InterChangeId = InterChangeId,
                        FromStationLineId = fromStationLineId,
                        ToStationLineId = toStationLineId,
                        Cost = cost
                    });
                }
                return interChangeList;
            };
        }

        protected override Dictionary<string, object> SetParameters(InterChange tableRow)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@Inter_Change_Id", tableRow.InterChangeId);
            parameters.Add("@From_Station_Line_Id", tableRow.FromStationLineId);
            parameters.Add("@To_Station_Line_Id", tableRow.ToStationLineId);
            parameters.Add("@Cost", tableRow.Cost);
            return parameters;
        }
    }
}
