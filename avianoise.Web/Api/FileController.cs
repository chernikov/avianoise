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
    [Route("api/file")]
    public class FileController : BaseUserController
    {
        private readonly IFileBL fileBL;
        private readonly IMapper mapper;

        public FileController(IUserBL userBL, IFileBL fileBL, IMapper mapper) : base(userBL)
        {
            this.fileBL = fileBL;
            this.mapper = mapper;
        }

        [HttpPut]
        [Authorize]
        [Produces("application/json")]
        [ProducesResponseType(typeof(FileDto), (int)HttpStatusCode.OK)]
        public IActionResult Put([FromBody]FileDto file)
        {
            var entry = mapper.Map<File>(file);
            var newEntry = fileBL.UpdateTypes(entry);
            var result = mapper.Map<FileDto>(newEntry);
            return Ok(result);
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
