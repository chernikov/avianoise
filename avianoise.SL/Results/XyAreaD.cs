using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace avianoise.SL.Results
{
    public class XyAreaD
    {
        public double St_xmin { get; set; }
        public double St_ymin { get; set; }
        public double St_xmax { get; set; }
        public double St_ymax { get; set; }


        public static implicit operator XyAreaD(XyArea xyArea)
        {
            return new XyAreaD()
            {
                St_xmax = double.Parse(xyArea.St_xmax, CultureInfo.InvariantCulture),
                St_xmin = double.Parse(xyArea.St_xmin, CultureInfo.InvariantCulture),
                St_ymax = double.Parse(xyArea.St_ymax, CultureInfo.InvariantCulture),
                St_ymin = double.Parse(xyArea.St_ymin, CultureInfo.InvariantCulture),
            };
        }

        public Point GetCenter()
        {
            return new Point()
            {
                X = (St_xmax + St_xmin) / 2,
                Y = (St_ymax + St_ymin) / 2
            };
        }
    }
}
