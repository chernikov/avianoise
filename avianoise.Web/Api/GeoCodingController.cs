using AutoMapper;
using avianoise.BL;
using avianoise.Domain;
using avianoise.SL;
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
    [Route("api/geocoding")]
    public class GeoCodingController : BaseController
    {
        private readonly IAddressBL addressBL;
        private readonly IGoogleMapSL googleMapSL;
        private readonly IMapper mapper;

        public GeoCodingController(IAddressBL addressBL, IGoogleMapSL googleMapSL, IMapper mapper)
        {
            this.addressBL = addressBL;
            this.googleMapSL = googleMapSL;
            this.mapper = mapper;
        }

        [HttpPost]
        [Produces("application/json")]
        [ProducesResponseType(typeof(AddressDto), (int)HttpStatusCode.OK)]
        public IActionResult Post([FromBody] AddressDto address)
        {
            var entry = mapper.Map<Address>(address);
            var cached = addressBL.GetBySearchLine(entry.SearchLine);

            if (cached != null)
            {
                var result = mapper.Map<Address>(cached);
                return Ok(result);
            }
            var searchLine = entry.SearchLine.Trim();
            var location = googleMapSL.GetLocationByAddress(searchLine, out string fullTextResult);

            entry.Lat = location.Lat;
            entry.Lng = location.Lng;
            entry.AddressJson = fullTextResult;

            var newEntry = addressBL.Create(entry);

            var newResult = mapper.Map<Address>(newEntry);
            return Ok(newResult);
        }
    }
}
