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
    public class FileProfile : Profile
    {
        public FileProfile()
        {
            CreateMap<File, FileDto>();
            CreateMap<File, ExtendedFileDto>();
        }
    }
}
