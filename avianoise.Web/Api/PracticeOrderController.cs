using AutoMapper;
using avianoise.BL;
using avianoise.Domain;
using avianoise.Web.Dto;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace avianoise.Web.Api
{
    [Route("api/practice-order")]
    public class PracticeOrderController : BaseUserController
    {
        private readonly IPracticeBL practiceBL;
        private readonly IMapper mapper;

        public PracticeOrderController(IUserBL userBL, IPracticeBL practiceBL, IMapper mapper) : base(userBL)
        {
            this.practiceBL = practiceBL;
            this.mapper = mapper;
        }

        [HttpPost]
        [Produces("application/json")]
        [ProducesResponseType(typeof(List<PracticeDto>), (int)HttpStatusCode.OK)]
        public IActionResult Post([FromBody] List<PracticeDto> practices)
        {
            var list = mapper.Map<List<PracticeDto>, List<Practice>>(practices);
            practiceBL.SetOrder(list);
            return Ok(practices);
        }
    }
}
