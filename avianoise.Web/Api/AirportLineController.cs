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
    [Route("api/airport/line")]
    public class AirportLineController : BaseUserController
    {
        private readonly ILineBL lineBL;
        private readonly IMapper mapper;

        public AirportLineController(IUserBL userBL, ILineBL lineBL, IMapper mapper) : base(userBL)
        {
            this.lineBL = lineBL;
            this.mapper = mapper;
        }


        [HttpGet("{airportId:int}")]
        [Authorize]
        [Produces("application/json")]
        [ProducesResponseType(typeof(List<LineDto>), (int)HttpStatusCode.OK)]
        public IActionResult Get(int airportId)
        {
            var list = lineBL.GetListByAirport(airportId);
            var result = mapper.Map<List<Line>, List<LineDto>>(list);
            return Ok(result);
        }
    }
}
