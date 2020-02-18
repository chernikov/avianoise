using avianoise.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace avianoise.Web.Dto
{
    public class NoiseLineDto
    {
        public int Id { get; set; }

        public int AirportId { get; set; }

        public string Name { get; set; }

        public double Level { get; set; }

        public NoiseTypeEnum NoiseType { get; set; }

        public DayNightTypeEnum DayNightType { get; set; }

    }
}
