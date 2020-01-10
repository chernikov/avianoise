using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace avianoise.Decoder
{
    [DebuggerDisplay("Lat: {Lat} Lng: {Lng}")]
    public class Point
    {
        public int Index { get; set; }

        public double Lat { get; set; }

        public double Lng { get; set; }
    }
}
