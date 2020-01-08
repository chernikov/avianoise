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
    public class LineProfile : Profile
    {
        public LineProfile()
        {
            CreateMap<Line, LineDto>()
                .ForMember(p => p.Points, opt => opt.MapFrom(r => r.Points.OrderBy(p => p.Number)));
            CreateMap<LineDto, Line>();
        }
    }
}
