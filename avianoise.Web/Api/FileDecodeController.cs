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
    [Route("api/file/decode")]
    public class FileDecodeController : BaseUserController
    {
        public FileDecodeController(IUserBL userBL) : base(userBL)
        {
        }

        [HttpGet("{fileId:int}")]
        [Authorize]
        [Produces("application/json")]
        [ProducesResponseType(typeof(List<LineDto>), (int)HttpStatusCode.OK)]
        public IActionResult Get(int fileId)
        {
            throw new NotImplementedException();
        }
    }
}
