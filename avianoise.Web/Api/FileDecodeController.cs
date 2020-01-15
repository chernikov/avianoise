using AutoMapper;
using avianoise.BL;
using avianoise.Decoder;
using avianoise.Web.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;

namespace avianoise.Web.Api
{
    [Route("api/file/decode")]
    public class FileDecodeController : BaseUserController
    {

        private readonly IFileBL fileBL;
        private readonly ILineBL lineBL;
        private readonly IMapper mapper;

        public FileDecodeController(IUserBL userBL, IFileBL fileBL, ILineBL lineBL, IMapper mapper) : base(userBL)
        {
            this.fileBL = fileBL;
            this.lineBL = lineBL;
            this.mapper = mapper;
        }

        [HttpGet("{fileId:int}")]
        [Authorize]
        [Produces("application/json")]
        [ProducesResponseType(typeof(ExtendedFileDto), (int)HttpStatusCode.OK)]
        public IActionResult Get(int fileId, bool force = false)
        {

            var fileEntry = fileBL.Get(fileId);

            if (fileEntry.IsDecoded)
            {
                if (force)
                {
                    lineBL.DeleteLinesByFileId(fileId);
                }
                else
                {
                    var resultLines = lineBL.GetByFileId(fileId);
                    return Ok(mapper.Map<List<Domain.Line>, List<LineDto>>(resultLines));
                }
            }

            IDecoder decoder = null;

            switch (fileEntry.Extension)
            {
                case ".dxf":
                    decoder = new DxfDecoder();
                    break;
                case ".geojson":
                    decoder = new GeoJsonDecoder();
                    break;
                case ".kml":
                    decoder = new KmlDecoder();
                    break;
                case ".dwg":
                    decoder = new DwgDecoder();
                    break;
            }


            if (decoder == null)
            {
                return BadRequest($"Decoded for file with extension {fileEntry.Extension} not found");
            }
            ProcessLines(fileEntry, decoder);
            fileBL.MarkDecodeFile(fileEntry);
            var newFileEntry = fileBL.GetWithLines(fileEntry.Id);
            var result = mapper.Map<ExtendedFileDto>(newFileEntry);
            return Ok(result);

        }

        private void ProcessLines(Domain.File fileEntry, IDecoder decoder)
        {
            var listOfEntries = new List<Domain.Line>();
            var content = System.IO.File.ReadAllText(Path.Combine(fileEntry.FullPath));
            var lines = decoder.Decode(content);
            foreach (var line in lines)
            {
                var lineEntry = new Domain.Line()
                {
                    AirportId = fileEntry.AirportId,
                    FileId = fileEntry.Id,
                    Name = line.Name,
                };
                var createdLine = lineBL.Create(lineEntry);
                var points = line.Points.Select(p => new Domain.Point()
                {
                    Number = p.Index,
                    Lat = p.Lat,
                    Lng = p.Lng,
                    LineId = createdLine.Id
                }).ToList();
                lineBL.CreatePoints(points);
                var newLineEntry = lineBL.GetById(createdLine.Id);
                listOfEntries.Add(newLineEntry);
            }
        }
    }
}
