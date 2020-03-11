using AutoMapper;
using avianoise.Domain;
using avianoise.Web.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace avianoise.Web.Profiles
{
    public class PracticeProfile : Profile
    {
        public PracticeProfile()
        {
            CreateMap<Practice, PracticeDto>();
            CreateMap<PracticeDto, Practice>();
        }
    }
}
