using AutoMapper;
using avianoise.SL;
using avianoise.SL.Results;
using avianoise.Web.Dto.Results;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace avianoise.Web.Api
{
    [Route("api/kadastr")]
    public class KadastrController : BaseController
    {
        private readonly IKadastrMapSL kadastrMapSL;
        private readonly IMapper mapper;

        public KadastrController(IKadastrMapSL kadastrMapSL, IMapper mapper)
        {
            this.kadastrMapSL = kadastrMapSL;
            this.mapper = mapper;
        }

        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(typeof(LocationResult), (int)HttpStatusCode.OK)]
        public IActionResult Get(string number)
        {
            try
            {
                var kadastrNumber = KadastrNumber.Parse(number);
                var location = kadastrMapSL.GetLocationByNumber(kadastrNumber);
                var result = mapper.Map<LocationResult>(location);
                return Ok(result);
            }
            catch
            {
                return BadRequest();
            }

        }
    }
}
