using AutoMapper;
using avianoise.Domain;
using avianoise.Web.Dto;

namespace avianoise.Web.Profiles
{
    public class RoleProfile : Profile
    {
        public RoleProfile()
        {
            CreateMap<Role, RoleDto>();
        }
    }
}
