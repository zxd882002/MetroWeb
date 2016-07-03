using System;
using System.Collections.Generic;
using System.Data;
using DatabaseAccessLibrary.Interface;
using DatabaseAccessLibrary.Model;

namespace DatabaseAccessLibrary.Table
{
    public class MetroTransferTable : TableBase<MetroTransfer>
    {
        public MetroTransferTable(IConnector connector)
            : base(connector)
        {
            SelectQuery = "SELECT * FROM MetroTransfer";
            InsertQuery = "INSERT INTO MetroTransfer VALUES (@Transfer_Id, @From_Station_Line_Id, @To_Station_Line_Id, @Time_Transfer, @Inter_Change)";
            DeleteQuery = "DELETE FROM MetroTransfer";
            UpdateQuery = "UPDATE MetroTransfer";
            DataReaderHandler = () =>
            {
                List<MetroTransfer> interChangeList = new List<MetroTransfer>();
                IDataReader reader = connector.Reader;
                while (reader.Read())
                {
                    int transferId = Convert.ToInt32(reader["Transfer_Id"]);
                    int fromStationLineId = Convert.ToInt32(reader["From_Station_Line_Id"]);
                    int toStationLineId = Convert.ToInt32(reader["To_Station_Line_Id"]);
                    TimeSpan timeTransfer = (TimeSpan)reader["Time_Transfer"];
                    bool interChange = Convert.ToBoolean(reader["Inter_Change"]);

                    interChangeList.Add(new MetroTransfer
                    {
                        TransferId = transferId,
                        FromStationLineId = fromStationLineId,
                        ToStationLineId = toStationLineId,
                        TimeTransfer = timeTransfer,
                        InterChange = interChange
                    });
                }
                return interChangeList;
            };
        }

        protected override Dictionary<string, object> SetParameters(MetroTransfer tableRow)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@Transfer_Id", tableRow.TransferId);
            parameters.Add("@From_Station_Line_Id", tableRow.FromStationLineId);
            parameters.Add("@To_Station_Line_Id", tableRow.ToStationLineId);
            parameters.Add("@Time_Transfer", tableRow.TimeTransfer);
            parameters.Add("@Inter_Change", tableRow.InterChange);
            return parameters;
        }
    }
}
