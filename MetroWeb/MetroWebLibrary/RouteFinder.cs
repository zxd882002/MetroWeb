using System;
using System.Collections.Generic;
using MetroWebLibrary;

public class RouteFinder
{
    public Tuple<List<StationLineEntity>, TimeSpan> GetTheNearestRouteBetween(StationEntity fromStation, StationEntity toStation)
    {
        List<StationLineEntityExtender> stationLineListCache = new List<StationLineEntityExtender>();
        List<StationLineEntityExtender> toStationlineList = StationLineEntityExtender.Convert(toStation, stationLineListCache);

        // Quick find a route so that the full find will not reach the time limit
        bool found = false;
        TimeSpan arrivedTimeLimit = new TimeSpan();
        foreach (StationLineEntityExtender toStationline in toStationlineList)
        {
            toStationline.Initialize();
            found = toStationline.QuickGetRoute(fromStation, stationLineListCache);
            if (found)
            {
                arrivedTimeLimit = toStationline.MinimumTime;
                break;
            }
        }

        if (!found)
        {
            throw new Exception("Quick get route not found!");
        }

        // Fully find a route so that
        found = false;
        TimeSpan arrivedTime = new TimeSpan();
        List<StationLineEntity> route = new List<StationLineEntity>();
        foreach (StationLineEntityExtender toStationline in toStationlineList)
        {
            toStationline.Initialize();
            found = toStationline.FullyGetRoute(fromStation, stationLineListCache, arrivedTimeLimit);
            if (found)
            {
                arrivedTime = toStationline.MinimumTime;
                route = toStationline.MinimumRoute;
            }
        }

        if (!found)
        {
            throw new Exception("Quick get route not found!");
        }

        Tuple<List<StationLineEntity>, TimeSpan> result = new Tuple<List<StationLineEntity>, TimeSpan>(route, arrivedTime);
        return result;
    }
}


//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;

//namespace MetroWebLibrary
//{
//    public class RouteFinder
//    {
//        private List<StationEntityExtender> stationEntityExtenderList;

//        public Tuple<List<StationEntity>, TimeSpan> GetTheNearestRouteBetween(StationEntity fromStation, StationEntity toStation)
//        {
//            List<StationEntityExtender> stationExtenderList = new List<StationEntityExtender>();
//            StationEntityExtender fromStationExtender = StationEntityExtender.Convert(fromStation, stationExtenderList);
//            StationEntityExtender toStationExtender = StationEntityExtender.Convert(toStation, stationExtenderList);

//            // Get quick router
//            bool found = toStationExtender.QuickGetRouter(fromStationExtender, stationExtenderList, new TimeSpan(TimeSpan.MaxValue.Ticks / 2));
//            if (!found)
//                throw new Exception("Error");

//            // Get all possible router
//            int transferLimit = 3;
//            TimeSpan minimumArrivedTimeLimit = toStationExtender.MinimumArrivedTime;
//            while (transferLimit <= 4)
//            {
//                stationExtenderList.ForEach(stationExtender => stationExtender.MinimumArrivedTime = new TimeSpan(0));
//                stationExtenderList.ForEach(stationExtender => stationExtender.MinimumRouteList.Clear());
//                stationExtenderList.ForEach(stationExtender => stationExtender.FinalResult = null);
//                found = toStationExtender.GetTheMinimumRouter(fromStationExtender, stationExtenderList, minimumArrivedTimeLimit, transferLimit);
//                if (found)
//                {
//                    // We assume if the we transfer to 3, there is no need to check line 4
//                    break;
//                }
//                transferLimit++;
//            }
//            if (!found)
//                throw new Exception("Error2");

//            return new Tuple<List<StationEntity>, TimeSpan>(
//                toStationExtender.MinimumRouteList.Select(route => route as StationEntity).ToList(),
//                toStationExtender.MinimumArrivedTime);
//        }
//    }
//}
