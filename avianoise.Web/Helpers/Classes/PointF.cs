using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace avianoise.Web.Helpers.Classes
{
    [DebuggerDisplay("X:{X},Y:{Y}")]
    public class PointF
    {
        public float X { get; set; }

        public float Y { get; set; }


        public PointF(float x, float y)
        {
            X = x;
            Y = y;
        }
    }
}
