using AutoMapper;
using avianoise.BL;
using avianoise.Domain;
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
        private readonly IFileBL fileBL;
        private readonly IMapper mapper;

        public LineController(IUserBL userBL, ILineBL lineBL, IFileBL fileBL, IMapper mapper) : base(userBL)
        {
            this.lineBL = lineBL;
            this.fileBL = fileBL;
            this.mapper = mapper;
        }


        [Authorize]
        [HttpGet("{lineId:int}")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(ExtendedLineDto), (int)HttpStatusCode.OK)]
        public IActionResult Get(int lineId)
        {
            var entry = lineBL.GetById(lineId);
            var result = mapper.Map<ExtendedLineDto>(entry);
            return Ok(result);
        }

        [HttpPut]
        [Authorize]
        [Produces("application/json")]
        [ProducesResponseType(typeof(LineDto), (int)HttpStatusCode.OK)]
        public IActionResult Put([FromBody]LineDto line)
        {
            var entry = mapper.Map<Line>(line);

            var newLine = lineBL.Update(entry);
            var result = mapper.Map<LineDto>(newLine);

            return Ok(result);
        }


        [HttpDelete("{lineId:int}")]
        [Authorize]
        [Produces("application/json")]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.OK)]
        public IActionResult Delete(int lineId)
        {
            var line = lineBL.GetById(lineId);
            var fileId = line.FileId;
            lineBL.Delete(lineId);
            var lines = lineBL.GetByFileId(fileId);
            if (lines.Count == 0)
            {
                var file = fileBL.Get(fileId);
                fileBL.MarkDecodeFile(file, false);
            }
            return Ok();
        }
    }
}
