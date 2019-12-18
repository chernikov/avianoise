using avianoise.BL;
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
        public AirportController(IUserBL userBL) : base(userBL)
        {
        }

        [HttpGet]
        [Authorize]
        [Produces("application/json")]
        [ProducesResponseType(typeof(List<AirportDto>), (int)HttpStatusCode.OK)]
        public IActionResult Get()
        {
            throw new NotImplementedException();
        }

        [Authorize]
        [HttpGet("{airportId:int}")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(AirportDto), (int)HttpStatusCode.OK)]
        public IActionResult Get(int airportId)
        {
            throw new NotImplementedException();
        }


        [HttpPost]
        [Authorize]
        [Produces("application/json")]
        [ProducesResponseType(typeof(AirportDto), (int)HttpStatusCode.OK)]
        public IActionResult Post([FromBody]AirportDto airport)
        {
            throw new NotImplementedException();
        }

        [HttpPut]
        [Authorize]
        [Produces("application/json")]
        [ProducesResponseType(typeof(AirportDto), (int)HttpStatusCode.OK)]
        public IActionResult Put([FromBody]AirportDto airport)
        {
            throw new NotImplementedException();
        }

        [Authorize]
        [HttpDelete("{airportId:int}")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.OK)]
        public IActionResult Delete(int airportId)
        {
            throw new NotImplementedException();
        }
    }
}
