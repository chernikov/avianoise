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
    [Route("api/zip/unpack")]
    public class ZipUnpackController : BaseUserController
    {
        public ZipUnpackController(IUserBL userBL) : base(userBL)
        {
        }

        [HttpGet("{zipId:int}")]
        [Authorize]
        [Produces("application/json")]
        [ProducesResponseType(typeof(List<FileDto>), (int)HttpStatusCode.OK)]
        public IActionResult Get(int zipId)
        {
            throw new NotImplementedException();
        }
    }
}
