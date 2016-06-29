using System;
using System.Collections.Generic;
using DatabaseAccessLibrary.Connectors;
using DatabaseAccessLibrary.Interface;

namespace DatabaseAccessLibrary
{
    public class MetroWebDatabase : IDatabase
    {
        public string ConnectionString
        {
            get
            {
                return
                    @"Data Source=.\sqlexpress;Initial Catalog=MetroWeb;Persist Security Info=True;User ID=sa;Pwd=abc123";
            }
        }

        private StationCollection stationTable;

        public List<T> Table<T>() where T : ITableRow
        {
            var table = GetTable<T>();
            if (table == null)
                throw new Exception(string.Format("Type {0} is not found in MetroWebDatabase", typeof(T)));
            return table.Select();
        }

        public List<T> Table<T>(T searchCriteria) where T : ITableRow
        {
            var table = GetTable<T>();
            if (table == null)
                throw new Exception(string.Format("Type {0} is not found in MetroWebDatabase", typeof(T)));

            return table.Select(searchCriteria);
        }

        private ITable<T> GetTable<T>() where T : ITableRow
        {
            ITable<T> table = null;
            IConnector connector = new SqlServerConnector(ConnectionString);
            if (typeof(T) == typeof(Station))
            {
                stationTable = new StationCollection(connector);
                table = stationTable as ITable<T>;
            }
            return table;
        }
    }
}
