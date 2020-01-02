using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace avianoise.Web.Dto
{
    public class PointDto
    {
        public int Id { get; set; }

        public int LineId { get; set; }

        public double Lat { get; set; }

        public double Lng { get; set; }
    }
}
