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
        public FileController(IUserBL userBL) : base(userBL)
        {
        }

        [Authorize]
        [HttpDelete("{fileId:int}")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.OK)]
        public IActionResult Delete(int fileId)
        {
            throw new NotImplementedException();
        }

    }
}
