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
    [Route("api/file/clear")]
    public class FileClearController : BaseUserController
    {
        private readonly IFileBL fileBL;

        private readonly IMapper mapper;

        public FileClearController(IFileBL fileBL, IUserBL userBL, IMapper mapper) : base(userBL)
        {
            this.fileBL = fileBL;
            this.mapper = mapper;
        }



        [HttpGet("{fileId:int}")]
        [Authorize]
        [Produces("application/json")]
        [ProducesResponseType(typeof(FileDto), (int)HttpStatusCode.OK)]
        public IActionResult Get(int fileId)
        {
            fileBL.ClearLines(fileId);
            var fileEntry = fileBL.Get(fileId);
            var result = mapper.Map<FileDto>(fileEntry);
            return Ok(result);
        }
    }
}
