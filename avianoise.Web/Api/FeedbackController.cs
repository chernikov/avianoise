using AutoMapper;
using avianoise.BL;
using avianoise.Domain;
using avianoise.SL;
using avianoise.Web.Dto;
using avianoise.Web.Dto.Results;
using avianoise.Web.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace avianoise.Web.Api
{
    [Route("api/feedback")]
    public class FeedbackController : BaseController
    {
        private static int PageSize = 20;
        private readonly IFeedbackBL feedbackBL;
        private readonly IEmailService emailService;
        private readonly IMapper mapper;

        public FeedbackController(IFeedbackBL feedbackBL, IEmailService emailService, IMapper mapper)
        {
            this.feedbackBL = feedbackBL;
            this.emailService = emailService;
            this.mapper = mapper;
        }

        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(typeof(PagedListResult<FeedbackDto>), (int)HttpStatusCode.OK)]
        public IActionResult Get(int page = 0)
        {
            if (ModelState.IsValid)
            {
                var list = feedbackBL.GetByPage(page, PageSize, out int total);
                var result = mapper.Map<List<FeedbackDto>>(list);
                var pagedList = new PagedListResult<FeedbackDto>()
                {
                    Items = result,
                    TotalPages = total
                };
                return Ok(pagedList);
            }
            return BadRequest();
        }


        [HttpPost]
        [Produces("application/json")]
        [ProducesResponseType(typeof(FeedbackDto), (int)HttpStatusCode.OK)]
        public IActionResult Post([FromBody]FeedbackDto feedback)
        {
            if (ModelState.IsValid)
            {
                var entry = mapper.Map<Feedback>(feedback);
                var newEntry = feedbackBL.Create(entry);
                var result = mapper.Map<FeedbackDto>(newEntry);
                this.emailService.SendFeedback(newEntry);
                return Ok(result);
            }
            return BadRequest();
        }
    }
}
