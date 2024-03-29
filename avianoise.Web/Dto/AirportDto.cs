﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace avianoise.Web.Dto
{
    public class AirportDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public double Lat { get; set; }

        public double Lng { get; set; }


        public List<ExtendedFileDto> Files { get; set; }

        public List<LineDto> Lines { get; set; }

        public List<ZipDto> Zips { get; set; }
    }
}
