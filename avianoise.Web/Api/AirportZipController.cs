using AutoMapper;
using avianoise.BL;
using avianoise.Domain;
using avianoise.Web.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace avianoise.Web.Api
{
    [Route("api/airport/zip")]
    public class AirportZipController : BaseUserController
    {
        private const string FilesDirectory = "files";
        private readonly IZipBL zipBL;
        private readonly IMapper mapper;

        public AirportZipController(IUserBL userBL, IZipBL zipBL, IMapper mapper) : base(userBL)
        {
            this.zipBL = zipBL;
            this.mapper = mapper;
        }


        [HttpGet("{airportId:int}")]
        [Authorize]
        [Produces("application/json")]
        [ProducesResponseType(typeof(List<ZipDto>), (int)HttpStatusCode.OK)]
        public IActionResult Get(int airportId)
        {
            throw new NotImplementedException();
        }


        [HttpPost("{airportId:int}")]
        [Authorize]
        [Produces("application/json")]
        [ProducesResponseType(typeof(List<ZipDto>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Upload(int airportId)
        {
            var files = Request.Form.Files;
            var list = new List<Zip>();

            foreach (var file in files)
            {
                var fileName = file.FileName;
                var extension = fileName.Substring(fileName.LastIndexOf("."));

                var newFileName = Guid.NewGuid().ToString("N") + extension;
                var directoryPath = Path.Combine("static", FilesDirectory);
                var filePath = Path.Combine(directoryPath, newFileName);
                using (var fileStream = System.IO.File.Create(filePath))
                {
                    await file.CopyToAsync(fileStream);
                    var zip = new Zip()
                    {
                        AddedDate = DateTime.Now,
                        AirportId = airportId,
                        FilePath = filePath
                    };
                    var newZip = zipBL.Create(zip);

                    list.Add(newZip);
                }
            }
            var result = mapper.Map<List<Zip>, List<ZipDto>>(list);
            return Ok(result);
        }
    }
}
