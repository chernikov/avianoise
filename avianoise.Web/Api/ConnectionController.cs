using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace avianoise.Web.Api
{
    [Route("api/connection")]
    public class ConnectionController : Controller
    {

        [HttpPost]
        public IActionResult Post([FromBody] string connection)
        {
            var options = SqlServerDbContextOptionsExtensions.UseSqlServer(new DbContextOptionsBuilder(), connection).Options;
            var db = new DbContext(options);

            db.Database.OpenConnection();
            db.Database.CloseConnection();

            return Ok("WORKS!");
        }
    }
}
