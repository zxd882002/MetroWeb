using MetroWebLibrary;

namespace MetroWebWcfService
{
    public class LineGraphAdapter : LineGraph
    {
        public LineGraphAdapter(LineEntity lineEntity)
        {
            strokeStyle = lineEntity.LineColor;

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
                        p1 = "{" + path + "}";
                    }
                    else if (pathNumber == 2)
                    {
                        p2 = "{" + path + "}";
                    }
                    pathNumber = 0;
                }
            }
        }
    }
}