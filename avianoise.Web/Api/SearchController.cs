using AutoMapper;
using avianoise.BL;
using avianoise.Domain;
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
    [Route("api/search")]
    public class SearchController : BaseController
    {
        private readonly IAddressBL addressBL;
        private readonly IGoogleMapSL googleMapSL;
        private readonly IKadastrMapSL kadastrMapSL;
        private readonly IMapper mapper;

        public SearchController(IAddressBL addressBL, IGoogleMapSL googleMapSL, IKadastrMapSL kadastrMapSL, IMapper mapper)
        {
            this.addressBL = addressBL;
            this.googleMapSL = googleMapSL;
            this.kadastrMapSL = kadastrMapSL;
            this.mapper = mapper;
        }

        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(typeof(LocationResult), (int)HttpStatusCode.OK)]
        public IActionResult Get(string searchString)
        {
            if (KadastrNumber.TryParse(searchString, out KadastrNumber kadastrNumber))
            {
                var location = kadastrMapSL.GetLocationByNumber(kadastrNumber);
                var result = mapper.Map<LocationResult>(location);
                if (result == null)
                {
                    return BadRequest();
                }
                return Ok(result);
            }
            else
            {
                var cached = addressBL.GetBySearchLine(searchString);

                if (cached != null)
                {
                    var result = new LocationResult()
                    {
                        Lat = cached.Lat,
                        Lng = cached.Lng
                    };
                    return Ok(result);
                }
                var searchLine = searchString.Trim();
                var location = googleMapSL.GetLocationByAddress(searchLine, out string fullTextResult);
                if (location == null)
                {
                    return BadRequest();
                }
                var entry = new Address()
                {
                    Lat = location.Lat,
                    Lng = location.Lng,
                    SearchLine = searchLine,
                    AddressJson = fullTextResult,
                };
                addressBL.Create(entry);
                return Ok(new LocationResult()
                {
                    Lat = location.Lat,
                    Lng = location.Lng
                });
            }
        }
    }
}
