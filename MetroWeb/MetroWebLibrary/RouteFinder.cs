using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MetroWebLibrary
{
    public class RouteFinder
    {
        private List<StationEntityExtender> stationEntityExtenderList;

        public Tuple<List<StationEntity>, TimeSpan> GetTheNearestRouteBetween(StationEntity fromStation, StationEntity toStation)
        {
            List<StationEntityExtender> stationExtenderList = new List<StationEntityExtender>();
            StationEntityExtender fromStationExtender = StationEntityExtender.Convert(fromStation, stationExtenderList);
            StationEntityExtender toStationExtender = StationEntityExtender.Convert(toStation, stationExtenderList);

            // Get quick router
            bool found = toStationExtender.QuickGetRouter(fromStationExtender, stationExtenderList, new TimeSpan(TimeSpan.MaxValue.Ticks / 2));
            if (!found)
                throw new Exception("Error");

            // Get all possible router
            int transferLimit = 3;
            while (transferLimit <= 4)
            {
                stationExtenderList.ForEach(stationExtender => stationExtender.MinimumRouteList.Clear());
                stationExtenderList.ForEach(stationExtender => stationExtender.FinalResult = null);
                found = toStationExtender.GetTheMinimumRouter(fromStationExtender, stationExtenderList, toStationExtender.MinimumArrivedTime, transferLimit);
                if (found)
                {
                    // We assume if the we transfer to 3, there is no need to check line 4
                    break;
                }
                transferLimit++;
            }
            if (!found)
                throw new Exception("Error2");

            return new Tuple<List<StationEntity>, TimeSpan>(
                toStationExtender.MinimumRouteList.Select(route => route as StationEntity).ToList(),
                toStationExtender.MinimumArrivedTime);
        }
    }
}
