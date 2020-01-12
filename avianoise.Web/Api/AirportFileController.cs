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
    [Route("api/airport/file")]
    public class AirportFileController : BaseUserController
    {
        private const string FilesDirectory = "files";
        private readonly IFileBL fileBL;
        private readonly IMapper mapper;

        public AirportFileController(IUserBL userBL, IFileBL fileBL, IMapper mapper) : base(userBL)
        {
            this.fileBL = fileBL;
            this.mapper = mapper;
        }

        [HttpGet("{airportId:int}")]
        [Authorize]
        [Produces("application/json")]
        [ProducesResponseType(typeof(List<FileDto>), (int)HttpStatusCode.OK)]
        public IActionResult Get(int airportId, bool onlyDecoded = false)
        {
            var list = fileBL.GetListByAirport(airportId, onlyDecoded);
            var result = mapper.Map<List<Domain.File>, List<FileDto>>(list);
            return Ok(result);
        }


        [HttpPost("{airportId:int}")]
        [Authorize]
        [Produces("application/json")]
        [ProducesResponseType(typeof(List<FileDto>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Post(int airportId)
        {
            var files = Request.Form.Files;
            var list = new List<Domain.File>();

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
                    var entry = new Domain.File()
                    {
                        AirportId = airportId,
                        FullPath = filePath,
                        FileName = fileName,
                        Extension = extension
                    };
                    var newFile = fileBL.Create(entry);
                    list.Add(newFile);
                }
            }
            var result = mapper.Map<List<Domain.File>, List<FileDto>>(list);
            return Ok(result);
        }

    }
}
