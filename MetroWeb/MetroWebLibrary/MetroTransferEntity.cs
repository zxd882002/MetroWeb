using System;
using DatabaseAccessLibrary.Model;

namespace MetroWebLibrary
{
    public class MetroTransferEntity
    {
        private MetroWebEntity metroWeb;
        private long transferId;
        private int fromStationLineId;
        private StationLineEntity fromStationLine;
        private int toStationLineId;
        private StationLineEntity toStationLine;
        private TimeSpan timeTransfer;
        private bool interChange;

        internal MetroTransferEntity(MetroWebEntity metroWeb, MetroTransfer metroTransfer)
        {
            this.metroWeb = metroWeb;
            this.transferId = metroTransfer.TransferId.Value;
            this.fromStationLineId = metroTransfer.FromStationLineId.Value;
            this.toStationLineId = metroTransfer.ToStationLineId.Value;
            this.timeTransfer = metroTransfer.TimeTransfer.Value;
            this.interChange = metroTransfer.InterChange.Value;
        }

        public long TransferId
        {
            get { return this.transferId; }
        }

        public StationLineEntity FromStationLine
        {
            get
            {
                if (fromStationLine == null)
                {
                    fromStationLine = metroWeb.StationLineList[fromStationLineId];
                }
                return fromStationLine;
            }
        }

        public StationLineEntity ToStationLine
        {
            get
            {
                if (toStationLine == null)
                {
                    toStationLine = metroWeb.StationLineList[toStationLineId];
                }
                return toStationLine;
            }
        }

        public TimeSpan TimeTransfer
        {
            get { return this.timeTransfer; }
        }

        public bool InterChange
        {
            get { return this.interChange; }
        }
    }
}
