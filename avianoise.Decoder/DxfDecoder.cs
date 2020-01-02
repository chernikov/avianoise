using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;

namespace avianoise.Decoder
{
    public class DxfDecoder : IDecoder
    {
        private static Regex PolylineRegex = new Regex("POLYLINE(?<polyline>.*?)SEQEND", RegexOptions.Singleline);

        public List<Line> Decode(string content)
        {
            var list = new List<Line>();
            var matches = PolylineRegex.Matches(content);
            foreach (Match match in matches)
            {
                var group = match.Groups[1];

                var polyline = group.Value;
                var splitByLine = polyline.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
                var line = new Line
                {
                    Name = splitByLine[1]
                };

                var points = Regex.Split(polyline, "VERTEX", RegexOptions.Singleline).ToList();
                points = points.Skip(1).ToList();
                foreach (var point in points)
                {
                    var pointsPart = point.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
                    line.Points.Add(new Point()
                    {
                        X = Convert.ToDouble(pointsPart[3], CultureInfo.InvariantCulture),
                        Y = Convert.ToDouble(pointsPart[5], CultureInfo.InvariantCulture)
                    });
                }
                list.Add(line);
            }
            return list;
        }
    }
}
