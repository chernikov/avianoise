using AutoMapper;
using avianoise.BL;
using avianoise.Domain;
using avianoise.Web.Dto;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace avianoise.Web.Api
{
    [Route("api/airport/published")]
    public class AirportPublishedController : BaseController
    {
        private readonly IAirportBL airportBL;
        private readonly IMapper mapper;

        public AirportPublishedController(IAirportBL airportBL, IMapper mapper)
        {
            this.airportBL = airportBL;
            this.mapper = mapper;
        }

        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(typeof(List<AirportDto>), (int)HttpStatusCode.OK)]
        public IActionResult Get()
        {
            var list = airportBL.GetPublished();
            var result = mapper.Map<List<Airport>, List<AirportDto>>(list);
            return Ok(result);
        }
    }
}
