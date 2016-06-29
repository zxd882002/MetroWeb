
using System.Collections.Generic;

namespace DatabaseAccessLibrary.Interface
{
    public interface IDatabase
    {
        string ConnectionString { get; }

        List<T> Table<T>() where T : ITableRow;
        List<T> Table<T>(T searchCriteria) where T : ITableRow;
    }
}
