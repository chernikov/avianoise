using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace avianoise.Web.Helpers.Classes
{
    public class GeoPoint
    {
        public double Lat { get; set; }

        public double Lng { get; set; }


        public GeoPoint(double lat, double lng)
        {
            Lat = lat;
            Lng = lng;
        }
    }
}
