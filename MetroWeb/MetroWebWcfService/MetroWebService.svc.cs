using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Activation;
using MetroWebLibrary;

namespace MetroWebWcfService
{
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class MetroWebService : IMetroWebService
    {
        public StationInfo[] GetStationInfos()
        {
            List<StationEntity> stationEntityList = MetroWebEntity.Instance().StationList.All;
            StationInfo[] stationInfos = new StationInfo[stationEntityList.Count];
            for (int i = 0; i < stationEntityList.Count; i++)
            {
                StationEntity stationEntity = stationEntityList[i];
                StationInfo stationInfo = new StationInfo
                {
                    StationId = stationEntity.StationId,
                    StationGraph = new StationGraph
                    {
                        x = stationEntity.StationX,
                        y = stationEntity.StationY
                    },
                    NameGraph = new NameGraph
                    {
                        x = stationEntity.StationNameX,
                        y = stationEntity.StationNameY,
                        text = stationEntity.StationName
                    }
                };
                stationInfos[i] = stationInfo;
            }
            return stationInfos;
        }

        public LineInfo[] GetLineInfos()
        {
            List<LineEntity> lineEntityList = MetroWebEntity.Instance().LineList.All;
            List<LineInfo> lineInfoList = new List<LineInfo>();
            foreach (LineEntity lineEntity in lineEntityList)
            {
                if (string.IsNullOrEmpty(lineEntity.LineColor))
                    continue;

                LineInfo lineInfo = new LineInfo();
                lineInfo.LineGraph = new LineGraph();
                lineInfo.LineGraph.strokeStyle = lineEntity.LineColor;

                char startChar = 'p';
                char leftQuote = '{';
                char rightQuote = '}';
                int leftIndex = -1;
                int rightIndex = -1;
                int pathNumber = 0;
                string linePath = lineEntity.LinePath;
                for (int index = 0; index < linePath.Length; index++)
                {
                    if (linePath[index] == startChar && pathNumber == 0)
                    {
                        pathNumber = linePath[index + 1] - '0';
                        continue;
                    }

                    if (linePath[index] == leftQuote && pathNumber != 0)
                    {
                        leftIndex = index + 1;
                        continue;
                    }

                    if (linePath[index] == rightQuote && pathNumber != 0)
                    {
                        rightIndex = index - 1;
                        string path = linePath.Substring(leftIndex, rightIndex - leftIndex + 1);
                        if (pathNumber == 1)
                        {
                            lineInfo.LineGraph.p1 = "{" + path + "}";
                        }
                        else if (pathNumber == 2)
                        {
                            lineInfo.LineGraph.p2 = "{" + path + "}";
                        }
                        pathNumber = 0;
                    }
                }
                lineInfoList.Add(lineInfo);
            }

            return lineInfoList.ToArray();
        }

        public StationInfo GetStationByStationId(int stationId)
        {
            StationEntity stationEntity = MetroWebEntity.Instance().StationList[stationId];
            StationInfo stationInfo = new StationInfo
            {
                StationId = stationEntity.StationId,
                StationGraph = new StationGraph
                {
                    x = stationEntity.StationX,
                    y = stationEntity.StationY
                },
                NameGraph = new NameGraph
                {
                    x = stationEntity.StationNameX,
                    y = stationEntity.StationNameY,
                    text = stationEntity.StationName
                }
            };
            return stationInfo;
        }

        public string GetNearestRoute(string fromStationName, int fromLine, string toStationName, int toLine)
        {
            StationEntity fromStationEntity;
            try
            {
                fromStationEntity = MetroWebEntity.Instance().StationList[fromStationName, string.Format("{0}号线", fromLine)];
            }
            catch
            {
                return "From Station is invalid!";
            }

            StationEntity toStationEntity;
            try
            {
                toStationEntity = MetroWebEntity.Instance().StationList[toStationName, string.Format("{0}号线", toLine)];
            }
            catch (Exception)
            {
                return "To Station is invalid!";
            }

            RouteFinder finder = new RouteFinder();
            var stationNameList = finder.GetTheNearestRouteBetween(fromStationEntity, toStationEntity).Item1.Select(stationLine => stationLine.Station.StationName);
            return string.Join(" -> ", stationNameList);
        }
    }
}
