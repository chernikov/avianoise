using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace avianoise.Web.Dto
{
    public class LineDto
    {
        public int Id { get; set; }

        public int AirportId { get; set; }

        public int FileId { get; set; }

        public DateTime AddedDate { get; set; }

        public string Name { get; set; }

        public double Level { get; set; }

        public bool Published { get; set; }

        public List<PointDto> Points { get; set; }
    }
}
