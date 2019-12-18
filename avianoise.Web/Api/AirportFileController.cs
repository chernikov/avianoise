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
    [Route("api/airport/file")]
    public class AirportFileController : BaseUserController
    {
        public AirportFileController(IUserBL userBL) : base(userBL)
        {
        }

        [HttpGet("{airportId:int}")]
        [Authorize]
        [Produces("application/json")]
        [ProducesResponseType(typeof(List<FileDto>), (int)HttpStatusCode.OK)]
        public IActionResult Get(int airportId)
        {
            throw new NotImplementedException();
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
