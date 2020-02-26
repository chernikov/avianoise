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
    [Route("/api/post")]
    public class PostController : BaseUserController
    {
        private readonly IPostBL postBL;
        private readonly IMapper mapper;

        public PostController(IUserBL userBL, IPostBL postBL, IMapper mapper) : base(userBL)
        {
            this.postBL = postBL;
            this.mapper = mapper;
        }

        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(typeof(List<PostDto>), (int)HttpStatusCode.OK)]
        public IActionResult Get(bool isPublished = false)
        {
            var list = isPublished ? postBL.GetPublishedMenu() : postBL.GetMenu();
            var result = mapper.Map<List<PostDto>>(list);
            return Ok(result);
        }


        [HttpGet("{id:int}")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(PostDto), (int)HttpStatusCode.OK)]
        public IActionResult Get(int id)
        {
            var item = postBL.Get(id);
            if (!item.IsPublished && !CurrentUserId.HasValue)
            {
                return BadRequest();
            }
            var result = mapper.Map<PostDto>(item);
            return Ok(result);
        }

        [HttpPost]
        [Produces("application/json")]
        [ProducesResponseType(typeof(PostDto), (int)HttpStatusCode.OK)]
        public IActionResult Post([FromBody] PostDto post)
        {
            var entry = mapper.Map<Post>(post);
            var savedEntry = postBL.Create(entry);
            var result = mapper.Map<PostDto>(savedEntry);
            return Ok(result);
        }

        [HttpPut]
        [Produces("application/json")]
        [ProducesResponseType(typeof(PostDto), (int)HttpStatusCode.OK)]
        public IActionResult Put([FromBody] PostDto post)
        {
            var entry = mapper.Map<Post>(post);
            var savedEntry = postBL.Update(entry);
            var result = mapper.Map<PostDto>(savedEntry);
            return Ok(result);
        }

        [HttpDelete("{postId:int}")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.OK)]
        public IActionResult Delete(int postId)
        {
            postBL.Remove(postId);
            return Ok();
        }
    }
}
