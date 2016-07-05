using System.Collections.Generic;
using DatabaseAccessLibrary.Database;

namespace MetroWebLibrary
{
    public class MetroWebEntity
    {
        private static MetroWebEntity metroWebInstance;
        private MetroWebDatabase metroWebDatabase;
        private StationCollectionEntity stationList;
        private LineCollectionEntity lineList;
        private StationLineCollectionEntity stationLineList;
        private MetroTransferCollectionEntity metroTransferList;

        internal MetroWebEntity()
        {
            this.metroWebDatabase = new MetroWebDatabase();
        }

        public static MetroWebEntity Instance()
        {
            if (metroWebInstance == null)
            {
                metroWebInstance = new MetroWebEntity();
            }
            return metroWebInstance;
        }

        public MetroWebDatabase MetroWebDatabase
        {
            get { return this.metroWebDatabase; }
        }

        public StationCollectionEntity StationList
        {
            get
            {
                if (stationList == null)
                    stationList = new StationCollectionEntity(this);
                return stationList;
            }
        }

        public LineCollectionEntity LineList
        {
            get
            {
                if (lineList == null)
                    lineList = new LineCollectionEntity(this);
                return lineList;
            }
        }

        public StationLineCollectionEntity StationLineList
        {
            get
            {
                if (stationLineList == null)
                    stationLineList = new StationLineCollectionEntity(this);
                return stationLineList;
            }
        }

        public MetroTransferCollectionEntity MetroTransferList
        {
            get
            {
                if (metroTransferList == null)
                    metroTransferList = new MetroTransferCollectionEntity(this);
                return metroTransferList;
            }
        }
    }
}
