using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace avianoise.Decoder
{
    [DebuggerDisplay("X: {X} Y: {Y}")]
    public class Point
    {
        public int Index { get; set; }

        public double X { get; set; }

        public double Y { get; set; }
    }
}
