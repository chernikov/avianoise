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
            var point = new GeoPoint(lat, lng);

            var totalLines = new List<Line>();
            foreach (var line in airport.Lines)
            {
                var points = line.Points.Select(p => new GeoPoint(p.Lat, p.Lng)).ToList();
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

        public static bool IsInPolygon(List<GeoPoint> poly, GeoPoint p)
        {
            GeoPoint p1, p2;
            bool inside = false;
            var length = poly.Count;
            if (length < 3)
            {
                return inside;
            }
            var oldPoint = new GeoPoint(poly[length - 1].Lat, poly[length - 1].Lng);
            for (int i = 0; i < length; i++)
            {
                var newPoint = new GeoPoint(poly[i].Lat, poly[i].Lng);
                if (newPoint.Lat > oldPoint.Lat)
                {
                    p1 = oldPoint;
                    p2 = newPoint;
                }
                else
                {
                    p1 = newPoint;
                    p2 = oldPoint;
                }

                if ((newPoint.Lat < p.Lat) == (p.Lat <= oldPoint.Lat)
                    && (p.Lng - (long)p1.Lng) * (p2.Lat - p1.Lat)
                    < (p2.Lng - (long)p1.Lng) * (p.Lat - p1.Lat))
                {
                    inside = !inside;
                }
                oldPoint = newPoint;
            }
            return inside;
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
