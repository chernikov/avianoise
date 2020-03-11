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
    [Route("api/practice")]
    public class PracticeController : BaseUserController
    {
        private readonly IPracticeBL practiceBL;
        private readonly IMapper mapper;

        public PracticeController(IUserBL userBL, IPracticeBL practiceBL, IMapper mapper) : base(userBL)
        {
            this.practiceBL = practiceBL;
            this.mapper = mapper;
        }

        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(typeof(List<PracticeDto>), (int)HttpStatusCode.OK)]
        public IActionResult Get(bool isPublished = false)
        {
            var list = isPublished ? practiceBL.GetPublishedMenu() : practiceBL.GetMenu();
            var result = mapper.Map<List<PracticeDto>>(list);
            OrderAll(ref result);
            return Ok(result);
        }

        private void OrderAll(ref List<PracticeDto> list)
        {
            foreach (var item in list)
            {
                if (item.Practices != null && item.Practices.Count > 1)
                {
                    var subList = item.Practices;
                    OrderAll(ref subList);
                    item.Practices = subList;
                }
            }
            list = list.OrderBy(p => p.Order).ToList();
        }

        [HttpGet("{id:int}")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(PracticeDto), (int)HttpStatusCode.OK)]
        public IActionResult Get(int id)
        {
            var item = practiceBL.Get(id);
            if (!item.IsPublished && !CurrentUserId.HasValue)
            {
                return BadRequest();
            }
            var result = mapper.Map<PracticeDto>(item);
            return Ok(result);
        }

        [HttpPost]
        [Authorize]
        [Produces("application/json")]
        [ProducesResponseType(typeof(PracticeDto), (int)HttpStatusCode.OK)]
        public IActionResult Post([FromBody] PracticeDto practice)
        {
            var entry = mapper.Map<Practice>(practice);
            var savedEntry = practiceBL.Create(entry);
            var result = mapper.Map<PracticeDto>(savedEntry);
            return Ok(result);
        }

        [HttpPut]
        [Authorize]
        [Produces("application/json")]
        [ProducesResponseType(typeof(PracticeDto), (int)HttpStatusCode.OK)]
        public IActionResult Put([FromBody] PracticeDto practice)
        {
            var entry = mapper.Map<Practice>(practice);
            var savedEntry = practiceBL.Update(entry);
            var result = mapper.Map<PracticeDto>(savedEntry);
            return Ok(result);
        }

        [HttpDelete("{practiceId:int}")]
        [Authorize]
        [Produces("application/json")]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.OK)]
        public IActionResult Delete(int practiceId)
        {
            practiceBL.Remove(practiceId);
            return Ok();
        }
    }
}
