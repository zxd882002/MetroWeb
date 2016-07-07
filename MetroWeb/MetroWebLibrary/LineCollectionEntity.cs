using System;
using System.Collections.Generic;
using DatabaseAccessLibrary.Model;

namespace MetroWebLibrary
{
    public class LineCollectionEntity
    {
        private List<LineEntity> lineList;
        private MetroWebEntity metroWeb;

        public LineCollectionEntity(MetroWebEntity metroWeb)
        {
            this.metroWeb = metroWeb;
        }

        #region Get all line list
        public List<LineEntity> All
        {
            get
            {
                if (lineList == null)
                    lineList = new List<LineEntity>();

                lineList.AddRange(SeachLineByQuery());
                return lineList;
            }
        }

        private List<LineEntity> SeachLineByQuery()
        {
            List<Line> matchedLineList =
                metroWeb.MetroWebDatabase.Table<Line>().Select();

            List<LineEntity> matchedLineEntityList = new List<LineEntity>();
            foreach (Line matchedLine in matchedLineList)
            {
                if (!lineList.Exists(line => line.LineId == matchedLine.LineId))
                {
                    LineEntity lineEntity = new LineEntity(metroWeb, matchedLine);
                    matchedLineEntityList.Add(lineEntity);
                }
            }
            return matchedLineEntityList;
        }
        #endregion

        #region Get Line list by line name
        public List<LineEntity> this[string lineName]
        {
            get
            {
                if (lineList == null)
                    lineList = new List<LineEntity>();

                List<LineEntity> matchedLineList = SearchLineFromLineList(lineName);

                try
                {
                    List<LineEntity> matchedLineFromQueryList = SeachLineByQuery(lineName);
                    matchedLineList.AddRange(matchedLineFromQueryList);
                    lineList.AddRange(matchedLineFromQueryList);
                }
                catch (Exception exception)
                {
                    throw exception;
                }
                return matchedLineList;
            }
        }

        private List<LineEntity> SearchLineFromLineList(string lineName)
        {
            return lineList.FindAll(line => line.LineName == lineName);
        }

        private List<LineEntity> SeachLineByQuery(string lineName)
        {
            List<Line> matchedLineList =
                metroWeb.MetroWebDatabase.Table<Line>().Select(new Line { LineName = lineName });

            if (matchedLineList.Count == 0)
                throw new Exception(string.Format("line name {0} is not found", lineName));

            List<LineEntity> matchedLineEntityList = new List<LineEntity>();
            foreach (Line matchedLine in matchedLineList)
            {
                if (!lineList.Exists(line => line.LineId == matchedLine.LineId))
                {
                    LineEntity lineEntity = new LineEntity(metroWeb, matchedLine);
                    matchedLineEntityList.Add(lineEntity);
                }
            }
            return matchedLineEntityList;
        }
        #endregion

        #region Get Line by line id

        public LineEntity this[int lineId]
        {
            get
            {
                if (lineList == null)
                    lineList = new List<LineEntity>();

                LineEntity matchedLine = SearchLineFromLineList(lineId);

                if (matchedLine == null)
                {
                    try
                    {
                        matchedLine = SeachLineByQuery(lineId);
                        lineList.Add(matchedLine);
                    }
                    catch (Exception exception)
                    {
                        throw exception;
                    }
                }
                return matchedLine;
            }
        }

        private LineEntity SearchLineFromLineList(int lineId)
        {
            return lineList.Find(line => line.LineId == lineId);
        }

        private LineEntity SeachLineByQuery(int lineId)
        {
            List<Line> matchedLineList =
                metroWeb.MetroWebDatabase.Table<Line>().Select(new Line { LineId = lineId });

            if (matchedLineList.Count == 0)
                throw new Exception(string.Format("line id {0} is not found", lineId));

            LineEntity matchedLineEntity = new LineEntity(metroWeb, matchedLineList[0]);
            return matchedLineEntity;
        }
        #endregion
    }
}
