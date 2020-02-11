using avianoise.SL.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace avianoise.SL
{
    public static class GeoLatLngHelper
    {
        private static readonly int Extent = 6378137;

        public static int Zoom = 17;

        /// <summary>
        /// ref https://wiki.openstreetmap.org/wiki/Slippy_map_tilenames#C.23
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        public static Location XyToLocation(Point point)
        {
            var tileSize = (Math.PI * Extent * 2) / Math.Pow(2, Zoom);
            var tileY = (point.Y + Math.PI * Extent) / tileSize;
            var tileX = -1 * (point.X - Math.PI * Extent) / tileSize;
            return new Location()
            {
                Lng = -(float)((tileX / Math.Pow(2.0, Zoom) * 360.0) - 180.0),
                Lat = -(float)(180.0 / Math.PI * Math.Atan(Math.Sinh(Math.PI - ((2.0 * Math.PI * tileY) / Math.Pow(2.0, Zoom))))),
            };
        }

        /// <summary>
        /// ref https://wiki.openstreetmap.org/wiki/Slippy_map_tilenames#C.23
        /// </summary>
        /// <param name="location"></param>
        /// <returns></returns>
        public static Point LocationToXy(Location location)
        {
            var tilePoint = new Point
            {
                X = (float)((location.Lng + 180.0) / 360.0 * (1 << Zoom)),
                Y = (float)((1.0 - Math.Log(Math.Tan(location.Lat * Math.PI / 180.0) + 1.0 / Math.Cos(location.Lat * Math.PI / 180.0)) / Math.PI) / 2.0 * (1 << Zoom))
            };
            var tileSize = (Math.PI * Extent * 2) / Math.Pow(2, Zoom);
            return new Point()
            {
                X = Math.PI * Extent - ((tilePoint.Y) * tileSize),
                Y = -1 * Math.PI * Extent + ((tilePoint.X) * tileSize)
            };
        }
    }
}
