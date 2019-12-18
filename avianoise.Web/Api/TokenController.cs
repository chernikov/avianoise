using avianoise.BL;
using avianoise.Web.Dto;
using avianoise.Web.Services;
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
    [Route("api/token")]
    public class TokenController : BaseUserController
    {
        private readonly IIdentityService userService;

        public TokenController(IUserBL userBL, IIdentityService userService) : base(userBL)
        {
            this.userService = userService;
        }



        [Authorize]
        [HttpGet()]
        [Produces("application/json")]
        [ProducesResponseType(typeof(TokenDto), (int)HttpStatusCode.OK)]
        public IActionResult Get()
        {
            if (!CurrentUserId.HasValue)
            {
                return Forbid();
            }
            var token = userService.RenewToken(CurrentUserId.Value);

            if (token == null)
            {
                return Ok(null);
            }

            return Ok(new TokenDto()
            {
                Token = token
            });
        }
    }
}
