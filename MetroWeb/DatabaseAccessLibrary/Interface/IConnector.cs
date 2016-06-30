using System.Collections.Generic;
using System.Data;

namespace DatabaseAccessLibrary.Interface
{
    public delegate void DataReaderHandler();

    public interface IConnector
    {
        IDataReader Reader { get; set; }
        string ConnectionString { set; get; }

        void ExecuteReader(string query, Dictionary<string, object> parameters, DataReaderHandler dataReaderHandler);

        int ExecuteNonQuery(string query, Dictionary<string, object> parameters);
    }
}
