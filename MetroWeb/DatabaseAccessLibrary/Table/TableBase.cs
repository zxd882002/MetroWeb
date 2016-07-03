using System;
using System.Collections.Generic;
using System.Text;
using DatabaseAccessLibrary.Interface;

namespace DatabaseAccessLibrary.Table
{
    public abstract class TableBase<T> : ITable<T> where T : ITableRow, new()
    {
        protected IConnector Connector { get; set; }
        protected string SelectQuery { get; set; }
        protected string InsertQuery { get; set; }
        protected string DeleteQuery { get; set; }
        protected string UpdateQuery { get; set; }
        protected DataReaderHandler<T> DataReaderHandler { get; set; }

        public TableBase(IConnector connector)
        {
            Connector = connector;
        }

        public List<T> Select()
        {
            return Select(new T());
        }

        public List<T> Select(T searchCriteria)
        {
            Dictionary<string, object> queryParameters = new Dictionary<string, object>();
            Dictionary<string, object> parameters = SetParameters(searchCriteria);
            string whereClause = GenerateWhereClause(parameters, ref queryParameters);
            string query = SelectQuery + whereClause;
            List<T> tableList = Connector.ExecuteReader(query, queryParameters, DataReaderHandler);
            return tableList;
        }

        public bool Insert(T tableRow)
        {
            Dictionary<string, object> parameters = SetParameters(tableRow);
            int affectedRowCount = Connector.ExecuteNonQuery(InsertQuery, parameters);
            return affectedRowCount == 1;
        }

        public bool Delete(T searchCriteria)
        {
            Dictionary<string, object> queryParameters = new Dictionary<string, object>();
            Dictionary<string, object> parameters = SetParameters(searchCriteria);
            string whereClause = GenerateWhereClause(parameters, ref queryParameters);
            string query = DeleteQuery + whereClause;
            int affectedRowCount = Connector.ExecuteNonQuery(query, queryParameters);
            return affectedRowCount > 0;
        }

        public bool Update(T searchCriteria, T newTableRow)
        {
            Dictionary<string, object> queryParameters = new Dictionary<string, object>();

            Dictionary<string, object> setParameters = SetParameters(newTableRow);
            string setClause = GenerateSetClause(setParameters, ref queryParameters);

            Dictionary<string, object> whereParameters = SetParameters(searchCriteria);
            string whereClause = GenerateWhereClause(whereParameters, ref queryParameters);

            string query = UpdateQuery + setClause + whereClause;
            int affectedRowCount = Connector.ExecuteNonQuery(query, queryParameters);
            return affectedRowCount > 0;
        }

        protected abstract Dictionary<string, object> SetParameters(T tableRow);

        private string GenerateWhereClause(Dictionary<string, object> searchCriteria, ref Dictionary<string, object> parameters)
        {
            StringBuilder whereClause = new StringBuilder();
            bool needAnd = false;
            foreach (KeyValuePair<string, object> oneCriteria in searchCriteria)
            {
                if (oneCriteria.Value != null)
                {
                    if (needAnd)
                        whereClause.Append(" AND ");
                    else
                        whereClause.Append(" WHERE ");
                    whereClause.Append(oneCriteria.Key.Substring(1) + " = " + oneCriteria.Key);
                    parameters.Add(oneCriteria.Key, oneCriteria.Value);
                    needAnd = true;
                }
            }
            return whereClause.ToString();
        }

        private string GenerateSetClause(Dictionary<string, object> newTableRow, ref Dictionary<string, object> parameters)
        {
            StringBuilder setClause = new StringBuilder();
            bool needAnd = false;
            foreach (KeyValuePair<string, object> oneParameter in newTableRow)
            {
                if (oneParameter.Value != null)
                {
                    string newKey = oneParameter.Key.Replace("@", "@new_");

                    if (needAnd)
                        setClause.Append(" , ");
                    else
                        setClause.Append(" SET ");
                    setClause.Append(oneParameter.Key.Substring(1) + " = " + newKey);
                    parameters.Add(newKey, oneParameter.Value);
                    needAnd = true;
                }
            }
            return setClause.ToString();
        }
    }
}
