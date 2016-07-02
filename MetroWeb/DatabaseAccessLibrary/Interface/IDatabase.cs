namespace DatabaseAccessLibrary.Interface
{
    public interface IDatabase
    {
        string ConnectionString { get; }

        ITable<T> Table<T>() where T : ITableRow;
    }
}
