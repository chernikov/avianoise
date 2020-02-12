using AutoMapper;
using avianoise.BL;
using avianoise.Domain;
using avianoise.Web.Dto;
using avianoise.Web.Helpers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace avianoise.Web.Api
{
    [Route("api/noise-level")]
    public class NoiseLevelController : BaseController
    {
        private readonly IAirportBL airportBL;
        private readonly IMapper mapper;

        public NoiseLevelController(IAirportBL airportBL, IMapper mapper)
        {
            this.airportBL = airportBL;
            this.mapper = mapper;
        }


        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(typeof(List<LineDto>), (int)HttpStatusCode.OK)]
        public IActionResult Get(double lat, double lng)
        {
            var airports = airportBL.GetPublished();
            var airport = GeoHelper.GetNearestAirport(airports, lat, lng);
            var lines = GeoHelper.GetNoiseLines(airport, lat, lng);
            var result = mapper.Map<List<LineDto>>(lines);
            return Ok(result);
        }
    }
}
