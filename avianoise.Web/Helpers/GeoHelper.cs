using avianoise.Domain;
using avianoise.Domain.Enums;
using avianoise.Web.Helpers.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace avianoise.Web.Helpers
{
    public static class GeoHelper
    {
        public static Airport GetNearestAirport(List<Airport> airports, double lat, double lng)
        {
            Airport nearest = null;
            double nearDistance = double.MaxValue;
            foreach (var airport in airports)
            {
                var distance = GetDistance(lat, lng, airport.Lat, airport.Lng);
                if (nearest == null || distance < nearDistance)
                {
                    nearDistance = distance;
                    nearest = airport;
                }
            }
            return nearest;
        }

        private static double GetDistance(double lat, double lng, double lat2, double lng2)
        {
            return Math.Sqrt(Math.Pow((lat2 - lat), 2) + Math.Pow((lng2 - lng), 2));
        }

        public static List<Line> GetNoiseLines(Airport airport, double lat, double lng)
        {
            var point = new PointF((float)lng, (float)lat);

            var totalLines = new List<Line>();
            foreach (var line in airport.Lines)
            {
                var points = line.Points.OrderBy(p => p.Number).Select(p => new PointF((float)p.Lng, (float)p.Lat)).ToList();
                if (IsInPolygon(points, point))
                {
                    totalLines.Add(line);
                }
            }
            var list = new List<Line>();
            FilterNoiseType(totalLines, list, NoiseTypeEnum.Max, DayNightTypeEnum.Day);
            FilterNoiseType(totalLines, list, NoiseTypeEnum.Eq, DayNightTypeEnum.Day);
            FilterNoiseType(totalLines, list, NoiseTypeEnum.Max, DayNightTypeEnum.Night);
            FilterNoiseType(totalLines, list, NoiseTypeEnum.Eq, DayNightTypeEnum.Night);
            return list;
        }


        public static bool IsInPolygon(List<PointF> polygon, PointF point)
        {
            bool isInside = false;
            var length = polygon.Count();
            for (int i = 0, j = length - 1; i < length; j = i++)
            {
                if ((polygon[i].Y > point.Y) != (polygon[j].Y > point.Y) &&
                (point.X < (polygon[j].X - polygon[i].X)
                        * (point.Y - polygon[i].Y) / (polygon[j].Y - polygon[i].Y) + polygon[i].X))
                {
                    isInside = !isInside;
                }
            }
            return isInside;
        }


        private static void FilterNoiseType(List<Line> source, List<Line> dest, NoiseTypeEnum noiseType, DayNightTypeEnum dayNightType)
        {
            var item = source.OrderByDescending(p => p.Level)
                            .Where(p => p.File.NoiseType == noiseType && p.File.DayNightType == dayNightType).FirstOrDefault();

            if (item != null)
            {
                dest.Add(item);
            }
        }
    }
}
