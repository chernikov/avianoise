using AutoMapper;
using avianoise.SL.Results;
using avianoise.Web.Dto.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace avianoise.Web.Profiles.Results
{
    public class LocationProfile : Profile
    {
        public LocationProfile()
        {
            CreateMap<Location, LocationResult>();
        }
    }
}
