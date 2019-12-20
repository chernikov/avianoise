using avianoise.BL;
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
    [Route("api/file")]
    public class FileController : BaseUserController
    {
        private readonly IFileBL fileBL;

        public FileController(IUserBL userBL, IFileBL fileBL) : base(userBL)
        {
            this.fileBL = fileBL;
        }

        [Authorize]
        [HttpDelete("{fileId:int}")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.OK)]
        public IActionResult Delete(int fileId)
        {
            fileBL.Delete(fileId);
            return Ok();
        }

    }
}
