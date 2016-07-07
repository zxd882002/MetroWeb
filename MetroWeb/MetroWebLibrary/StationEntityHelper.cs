using System;
using System.Collections.Generic;
using System.Linq;
using DatabaseAccessLibrary.Model;

namespace MetroWebLibrary
{
    internal class StationEntityExtender : StationEntity
    {
        internal TimeSpan MinimumArrivedTime { get; set; }
        internal Stack<StationEntityExtender> MinimumRouteList { get; set; }

        internal StationEntityExtender(MetroWebEntity webEntity, Station station) : base(webEntity, station) { }

        internal void GetTheMinimumRouter(StationEntityExtender fromStationExtender)
        {
            // if the station has already been in the stack, exlude it
            if (MinimumRouteList.Contains(this))
            {
                return;
            }
            else
            {
                MinimumRouteList.Push(this);
            }

            // find one route
            if (this == fromStationExtender)
            {
                return;
            }

            // this way is not correct
            List<StationEntityExtender> previousStationList = GetPreviousStationList();
            List<StationEntityExtender> transferStationList = GetTransferStattionList();
            if (previousStationList.Count == 0 && transferStationList.Count == 0)
            {
                MinimumArrivedTime = TimeSpan.MaxValue;
                MinimumRouteList = null;
                return;
            }

            // other situation
            foreach (StationEntityExtender previousStation in previousStationList)
            {
                // get current route arrived time
                // if is minimum then
                // log time
                // log route
                previousStation.GetTheMinimumRouter(this);
            }
        }

        private List<StationEntityExtender> GetPreviousStationList()
        {
            List<StationEntityExtender> previouStationLineList = new List<StationEntityExtender>();

            List<StationLineEntity> currentStationLineList = this.StationLineList;
            foreach (StationLineEntity currentStationLine in currentStationLineList)
            {
                StationLineEntity previousStationLine = currentStationLine.PreviousStationLine;
                StationEntityExtender previousStationExtender = previousStationLine.Station as StationEntityExtender;

                if (!previouStationLineList.Contains(previousStationExtender))
                    previouStationLineList.Add(previousStationExtender);
            }
            return previouStationLineList;
        }

        private List<StationEntityExtender> GetTransferStattionList()
        {
            List<StationEntityExtender> previouStationLineList = new List<StationEntityExtender>();

            List<StationLineEntity> currentStationLineList = this.StationLineList;
            foreach (StationLineEntity currentStationLine in currentStationLineList)
            {
                List<MetroTransferEntity> transferStationList = currentStationLine.TransferFromList;
                foreach (var transferStation in transferStationList)
                {
                    StationEntityExtender transferStationExtender = transferStation.FromStationLine.Station as StationEntityExtender;
                    if (!previouStationLineList.Contains(transferStationExtender))
                        previouStationLineList.Add(transferStationExtender);
                }
            }
            return previouStationLineList;
        }

        private TimeSpan GetTimeArrived(StationEntityExtender fromStationExtender, StationEntityExtender toStationExtender, bool calculateWaitTime)
        {
            // calculate the possible 
            throw new NotImplementedException();
        }
    }

    public class StationEntityHelper
    {
        private List<StationEntityExtender> stationEntityExtenderList;

        internal Tuple<List<StationEntity>, TimeSpan> GetTheNearestRouteBetween(StationEntity fromStation, StationEntity toStation)
        {
            StationEntityExtender fromStationExtender = fromStation as StationEntityExtender;
            StationEntityExtender toStationExtender = toStation as StationEntityExtender;
            toStationExtender.GetTheMinimumRouter(fromStationExtender);

            return new Tuple<List<StationEntity>, TimeSpan>(
                toStationExtender.MinimumRouteList.Select(route => route as StationEntity).ToList(),
                toStationExtender.MinimumArrivedTime);
        }
    }
}
