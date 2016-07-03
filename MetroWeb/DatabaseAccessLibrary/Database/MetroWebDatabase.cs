using DatabaseAccessLibrary.Connectors;
using DatabaseAccessLibrary.Interface;
using DatabaseAccessLibrary.Model;
using DatabaseAccessLibrary.Table;

namespace DatabaseAccessLibrary.Database
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

        public ITable<T> Table<T>() where T : ITableRow
        {
            ITable<T> table = null;
            IConnector connector = new SqlServerConnector(ConnectionString);
            if (typeof(T) == typeof(Station))
            {
                table = new StationTable(connector) as ITable<T>;
            }
            else if (typeof(T) == typeof(Line))
            {
                table = new LineTable(connector) as ITable<T>;
            }
            else if (typeof (T) == typeof (StationLine))
            {
                table = new StationLineTable(connector) as ITable<T>;
            }
            else if (typeof (T) == typeof (InterChange))
            {
                table = new InterChangeTable(connector) as ITable<T>;
            }
            return table;
        }
    }
}
