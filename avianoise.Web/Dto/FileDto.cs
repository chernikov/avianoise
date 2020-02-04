using avianoise.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace avianoise.Web.Dto
{
    public class FileDto
    {
        public int Id { get; set; }

        public int AirportId { get; set; }

        public bool IsDecoded { get; set; }

        public string FullPath { get; set; }

        public string FileName { get; set; }

        public string Extension { get; set; }

        public NoiseTypeEnum NoiseType { get; set; }

        public DayNightTypeEnum DayNightType { get; set; }

        public TimeTypeEnum TimeType { get; set; }
    }
}
