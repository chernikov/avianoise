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
    [Route("api/zip")]
    public class ZipController : BaseUserController
    {
        public ZipController(IUserBL userBL) : base(userBL)
        {
        }

        [Authorize]
        [HttpDelete("{zipId:int}")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.OK)]
        public IActionResult Delete(int zipId)
        {
            throw new NotImplementedException();
        }

    }
}
