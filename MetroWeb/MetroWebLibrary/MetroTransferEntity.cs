using System;
using DatabaseAccessLibrary.Model;

namespace MetroWebLibrary
{
    public class MetroTransferEntity
    {
        private MetroWebEntity metroWeb;
        private int transferId;
        private int fromStationLineId;
        private StationLineEntity fromStationLine;
        private int toStationLineId;
        private StationLineEntity toStationLine;
        private TimeSpan timeTransfer;
        private bool interChange;

        internal MetroTransferEntity(MetroWebEntity metroWeb, MetroTransfer metroTransfer)
        {
            this.metroWeb = metroWeb;
        }

        //public int TranferId { get; }

        //public StationLineEntity FromStationLine { get; }

        //public StationLineEntity ToStationLine { get; }

        //public TimeSpan TimeTransfer { get; }

        //public bool InterChange { get; }
    }
}
