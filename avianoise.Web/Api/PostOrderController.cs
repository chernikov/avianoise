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
    [Route("api/post-order")]
    public class PostOrderController : BaseUserController
    {
        private readonly IPostBL postBL;
        private readonly IMapper mapper;

        public PostOrderController(IUserBL userBL, IPostBL postBL, IMapper mapper) : base(userBL)
        {
            this.postBL = postBL;
            this.mapper = mapper;
        }

        [HttpPost]
        [Produces("application/json")]
        [ProducesResponseType(typeof(List<PostDto>), (int)HttpStatusCode.OK)]
        public IActionResult Post([FromBody] List<PostDto> posts)
        {
            var list = mapper.Map<List<PostDto>, List<Post>>(posts);
            postBL.SetOrder(list);
            return Ok(posts);
        }
    }
}
