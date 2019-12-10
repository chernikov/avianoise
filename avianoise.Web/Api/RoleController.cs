using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using avianoise.BL;
using avianoise.Web.Dto;

namespace avianoise.Web.Api
{
    [Route("/api/role")]
    public class RoleController : BaseController
    {

        private readonly IRoleBL roleBL;
        private readonly IMapper mapper;

        public RoleController(IRoleBL roleBL, IMapper mapper)
        {
            this.roleBL = roleBL;
            this.mapper = mapper;
        }

        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(typeof(List<RoleDto>), (int)HttpStatusCode.OK)]
        public IActionResult Get()
        {
            var roles = roleBL.GetList();
            var result = mapper.Map<List<RoleDto>>(roles);
            return Ok(result);
        }


        [HttpGet("{id:int}")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(RoleDto), (int)HttpStatusCode.OK)]
        public IActionResult Get(int id)
        {
            var roles = roleBL.GetList();
            var role = roles.FirstOrDefault(p => p.Id == id);
            var result = mapper.Map<RoleDto>(role);
            return Ok(result);
        }
    }
}
