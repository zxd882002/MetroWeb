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
        internal List<StationLine> ExcludedStationLines { get; set; }

        internal StationEntityExtender(MetroWebEntity webEntity, Station station) : base(webEntity, station) { }

        internal void GetTheMinimumRouter(StationEntityExtender fromStationExtender)
        {
            List<StationEntityExtender> previousStationList = GetPreviousStationList();

            // this way is not correct
            if (previousStationList.Count == 0)
            {
                MinimumArrivedTime = TimeSpan.MaxValue;
                MinimumRouteList = null;
                return;
            }

            // find one route
            if (previousStationList.Contains(fromStationExtender))
            {
                MinimumRouteList.Push(fromStationExtender);
                MinimumArrivedTime += GetTimeArrived(this, fromStationExtender);
                return;
            }

            // other situation
            foreach (StationEntityExtender previousStation in previousStationList)
            {
                previousStation.GetTheMinimumRouter(this);
                // get current route arrived time
                // if is minimum then
                // log time
                // log route
            }
        }

        private List<StationEntityExtender> GetPreviousStationList()
        {
            // add exclusion station line here
            throw new NotImplementedException();
        }

        private TimeSpan GetTimeArrived(StationEntityExtender toStationExtender, StationEntityExtender fromStationExtender)
        {
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
