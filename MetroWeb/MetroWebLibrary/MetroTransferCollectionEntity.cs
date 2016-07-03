using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MetroWebLibrary
{
    public class MetroTransferCollectionEntity
    {
        private MetroWebEntity metroWeb;
        private List<MetroTransferEntity> metroTransferEntityList;

        internal MetroTransferCollectionEntity(MetroWebEntity metroWeb)
        {
            this.metroWeb = metroWeb;
        }
    }
}
