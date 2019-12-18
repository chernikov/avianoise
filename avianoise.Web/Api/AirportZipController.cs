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
    [Route("api/airport/zip")]
    public class AirportZipController : BaseUserController
    {
        public AirportZipController(IUserBL userBL) : base(userBL)
        {
        }


        [HttpGet("{airportId:int}")]
        [Authorize]
        [Produces("application/json")]
        [ProducesResponseType(typeof(List<ZipDto>), (int)HttpStatusCode.OK)]
        public IActionResult Get(int airportId)
        {
            throw new NotImplementedException();
        }


        [HttpPost("{airportId:int}")]
        [Authorize]
        [Produces("application/json")]
        [ProducesResponseType(typeof(ZipDto), (int)HttpStatusCode.OK)]
        public IActionResult Post()
        {
            //TODO: Upload File
            throw new NotImplementedException();
        }
    }
}
