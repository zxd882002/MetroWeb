using System;
using System.Collections.Generic;
using DatabaseAccessLibrary.Interface;

namespace DatabaseAccessLibrary
{
    public class InterChangeTable : ITable<InterChange>
    {
        public List<InterChange> Select()
        {
            throw new NotImplementedException();
        }

        public List<InterChange> Select(InterChange searchCriteria)
        {
            throw new NotImplementedException();
        }

        public bool Insert(InterChange tableRow)
        {
            throw new NotImplementedException();
        }

        public bool Delete(InterChange searchCriteria)
        {
            throw new NotImplementedException();
        }

        public bool Update(InterChange searchCriteria, InterChange newTableRow)
        {
            throw new NotImplementedException();
        }
    }
}
