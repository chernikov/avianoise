using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace avianoise.Domain
{
    public class Point
    {
        [Key]
        public int Id { get; set; }

        public int LineId { get; set; }

        public Line Line { get; set; }

        public double Lat { get; set; }

        public double Lng { get; set; }
    }
}
