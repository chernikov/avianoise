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
    [Route("api/line")]
    public class LineController : BaseUserController
    {
        public LineController(IUserBL userBL) : base(userBL)
        {
        }


        [Authorize]
        [HttpGet("{lineId:int}")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(LineDto), (int)HttpStatusCode.OK)]
        public IActionResult Get(int lineId)
        {
            throw new NotImplementedException();
        }

        [HttpPut]
        [Authorize]
        [Produces("application/json")]
        [ProducesResponseType(typeof(LineDto), (int)HttpStatusCode.OK)]
        public IActionResult Put([FromBody]LineDto line)
        {
            throw new NotImplementedException();
        }

    }
}
