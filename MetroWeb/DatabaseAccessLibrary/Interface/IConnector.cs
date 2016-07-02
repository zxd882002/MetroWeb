﻿using System.Collections.Generic;
using System.Data;

namespace DatabaseAccessLibrary.Interface
{
    public delegate List<ITableRow> DataReaderHandler();

    public interface IConnector
    {
        IDataReader Reader { get; set; }
        string ConnectionString { set; get; }

        List<T> ExecuteReader<T>(string query, Dictionary<string, object> parameters, DataReaderHandler dataReaderHandler) where T:ITableRow;

        int ExecuteNonQuery(string query, Dictionary<string, object> parameters);
    }
}
