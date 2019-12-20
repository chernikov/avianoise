using avianoise.BL;
using avianoise.Web.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net;

namespace avianoise.Web.Api
{
    [Route("api/file/decode")]
    public class FileDecodeController : BaseUserController
    {

        private readonly IFileBL fileBL;

        public FileDecodeController(IUserBL userBL, IFileBL fileBL) : base(userBL)
        {
            this.fileBL = fileBL;
        }

        [HttpGet("{fileId:int}")]
        [Authorize]
        [Produces("application/json")]
        [ProducesResponseType(typeof(List<LineDto>), (int)HttpStatusCode.OK)]
        public IActionResult Get(int fileId)
        {
            var fileEntry = fileBL.Get(fileId);

            switch (fileEntry.Extension)
            {
                case ".dxf":
                    break;
            }
            return Ok();
        }
    }
}
