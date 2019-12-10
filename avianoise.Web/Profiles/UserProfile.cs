using AutoMapper;
using System.Linq;
using avianoise.Domain;
using avianoise.Web.Dto;

namespace avianoise.Web.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDto>()
                .ForMember(p => p.Roles, opt => opt.MapFrom(r => r.UserRoles.Select(ur => ur.Role.Code)));
        }
    }
}
