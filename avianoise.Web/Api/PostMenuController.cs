using AutoMapper;
using avianoise.BL;
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
    [Route("api/post-menu")]
    public class PostMenuController : BaseController
    {
        private readonly IPostBL postBL;
        private readonly IMapper mapper;

        public PostMenuController(IPostBL postBL, IMapper mapper)
        {
            this.postBL = postBL;
            this.mapper = mapper;
        }

        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(typeof(List<PostDto>), (int)HttpStatusCode.OK)]
        public IActionResult Get()
        {
            var list = postBL.GetMenu();
            var result = mapper.Map<List<PostDto>>(list);
            return Ok(result);
        }
    }
}
