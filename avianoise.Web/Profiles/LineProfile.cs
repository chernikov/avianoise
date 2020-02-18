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
            CreateMap<Line, ExtendedLineDto>()
             .ForMember(p => p.Points, opt => opt.MapFrom(r => r.Points.OrderBy(p => p.Number)));

            CreateMap<Line, NoiseLineDto>()
             .ForMember(p => p.NoiseType, opt => opt.MapFrom(r => r.File.NoiseType))
             .ForMember(p => p.DayNightType, opt => opt.MapFrom(r => r.File.DayNightType));

            CreateMap<LineDto, Line>();
        }
    }
}
