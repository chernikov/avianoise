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
    [Route("api/airport")]
    public class AirportController : BaseUserController
    {
        private readonly IAirportBL airportBL;
        private readonly IMapper mapper;

        public AirportController(IUserBL userBL, IAirportBL airportBL, IMapper mapper) : base(userBL)
        {
            this.airportBL = airportBL;
            this.mapper = mapper;
        }

        [HttpGet]
        [Authorize]
        [Produces("application/json")]
        [ProducesResponseType(typeof(List<AirportDto>), (int)HttpStatusCode.OK)]
        public IActionResult Get()
        {
            var list = airportBL.GetList();
            var result = mapper.Map<List<Airport>, List<AirportDto>>(list);
            return Ok(result);
        }

        [Authorize]
        [HttpGet("{airportId:int}")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(AirportDto), (int)HttpStatusCode.OK)]
        public IActionResult Get(int airportId)
        {
            var item = airportBL.Get(airportId);
            var result = mapper.Map<AirportDto>(item);
            return Ok(result);
        }


        [HttpPost]
        [Authorize]
        [Produces("application/json")]
        [ProducesResponseType(typeof(AirportDto), (int)HttpStatusCode.OK)]
        public IActionResult Post([FromBody]AirportDto airport)
        {
            var entry = mapper.Map<Airport>(airport);
            var newEntry = airportBL.Create(entry);
            var result = mapper.Map<AirportDto>(newEntry);
            return Ok(result);
        }

        [HttpPut]
        [Authorize]
        [Produces("application/json")]
        [ProducesResponseType(typeof(AirportDto), (int)HttpStatusCode.OK)]
        public IActionResult Put([FromBody]AirportDto airport)
        {
            var entry = mapper.Map<Airport>(airport);
            var newEntry = airportBL.Update(entry);
            var result = mapper.Map<AirportDto>(newEntry);
            return Ok(result);
        }

        [Authorize]
        [HttpDelete("{airportId:int}")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.OK)]
        public IActionResult Delete(int airportId)
        {
            airportBL.Delete(airportId);
            return Ok();
        }
    }
}
