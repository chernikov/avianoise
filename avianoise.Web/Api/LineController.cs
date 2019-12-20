using AutoMapper;
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
        private readonly ILineBL lineBL;
        private readonly IMapper mapper;

        public LineController(IUserBL userBL, ILineBL lineBL, IMapper mapper) : base(userBL)
        {
            this.lineBL = lineBL;
            this.mapper = mapper;
        }


        [Authorize]
        [HttpGet("{lineId:int}")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(LineDto), (int)HttpStatusCode.OK)]
        public IActionResult Get(int lineId)
        {
            var entry = lineBL.GetById(lineId);
            var result = mapper.Map<LineDto>(entry);
            return Ok(result);
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
