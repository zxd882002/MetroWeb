using System.Collections.Generic;

namespace DatabaseAccessLibrary.Interface
{
    public interface ITable<T> where T:ITableRow
    {
        List<T> Select();
        List<T> Select(T searchCriteria);
        bool Insert(T tableRow);
        bool Delete(T searchCriteria);
        bool Update(T searchCriteria, T tableRow);
    }
}
