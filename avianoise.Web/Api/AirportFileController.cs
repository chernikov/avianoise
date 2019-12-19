using AutoMapper;
using avianoise.BL;
using avianoise.Domain;
using avianoise.Web.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace avianoise.Web.Api
{
    [Route("api/airport/file")]
    public class AirportFileController : BaseUserController
    {
        private readonly IFileBL fileBL;
        private readonly IMapper mapper;

        public AirportFileController(IUserBL userBL, IFileBL fileBL, IMapper mapper) : base(userBL)
        {
            this.fileBL = fileBL;
            this.mapper = mapper;
        }

        [HttpGet("{airportId:int}")]
        [Authorize]
        [Produces("application/json")]
        [ProducesResponseType(typeof(List<FileDto>), (int)HttpStatusCode.OK)]
        public IActionResult Get(int airportId)
        {
            var list = fileBL.GetListByAirport(airportId);
            var result = mapper.Map<List<File>, List<FileDto>>(list);
            return Ok(result);
        }


        [HttpPost("{airportId:int}")]
        [Authorize]
        [Produces("application/json")]
        [ProducesResponseType(typeof(FileDto), (int)HttpStatusCode.OK)]
        public IActionResult Post()
        {
            //TODO: Upload File
            throw new NotImplementedException();
        }

    }
}
