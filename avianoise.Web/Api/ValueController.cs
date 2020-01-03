using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace avianoise.Web.Api
{
    [Route("api/value")]
    public class ValueController : Controller
    {
        [HttpGet]
        [Produces("application/json")]
        public IActionResult Get()
        {
            var value = new string[] { "value", "value2" };
            return Ok(value);
        }
    }
}
