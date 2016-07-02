using System;
using System.Collections.Generic;
using DatabaseAccessLibrary.Interface;
using DatabaseAccessLibrary.Model;

namespace DatabaseAccessLibrary.Table
{
    public class OuterChangeTable : ITable<OuterChange>
    {
        public List<OuterChange> Select()
        {
            throw new NotImplementedException();
        }

        public List<OuterChange> Select(OuterChange searchCriteria)
        {
            throw new NotImplementedException();
        }

        public bool Insert(OuterChange tableRow)
        {
            throw new NotImplementedException();
        }

        public bool Delete(OuterChange searchCriteria)
        {
            throw new NotImplementedException();
        }

        public bool Update(OuterChange searchCriteria, OuterChange newTableRow)
        {
            throw new NotImplementedException();
        }
    }
}
