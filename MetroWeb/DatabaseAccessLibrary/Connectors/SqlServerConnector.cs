using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using DatabaseAccessLibrary.Interface;

namespace DatabaseAccessLibrary.Connectors
{
    internal class SqlServerConnector : IConnector
    {
        public IDataReader Reader { get; set; }

        public string ConnectionString { get; set; }

        public SqlServerConnector(string connectionString)
        {
            ConnectionString = connectionString;
        }

        public void ExecuteReader(string query, Dictionary<string, object> parameter, DataReaderHandler dataReaderHandler)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    foreach (var nameValue in parameter)
                    {
                        command.Parameters.Add(new SqlParameter(nameValue.Key, nameValue.Value));
                    }

                    connection.Open();
                    Reader = command.ExecuteReader();
                    dataReaderHandler();
                    connection.Close();
                }
            }
        }
    }
}
