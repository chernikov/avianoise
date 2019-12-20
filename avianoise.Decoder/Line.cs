using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace avianoise.Decoder
{
    public class Line
    {
        public string Name { get; set; }
        public List<Point> Points { get; set; } = new List<Point>();
    }
}
