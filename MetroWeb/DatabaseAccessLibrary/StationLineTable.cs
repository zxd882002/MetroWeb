using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using DatabaseAccessLibrary.Interface;

namespace DatabaseAccessLibrary
{
    public class StationLineTable : ITable<StationLine>
    {

        public List<StationLine> Select()
        {
            throw new NotImplementedException();
        }

        public List<StationLine> Select(StationLine searchCriteria)
        {
            throw new NotImplementedException();
        }

        public bool Insert(StationLine tableRow)
        {
            throw new NotImplementedException();
        }

        public bool Delete(StationLine searchCriteria)
        {
            throw new NotImplementedException();
        }

        public bool Update(StationLine searchCriteria, StationLine newTableRow)
        {
            throw new NotImplementedException();
        }
    }
}
