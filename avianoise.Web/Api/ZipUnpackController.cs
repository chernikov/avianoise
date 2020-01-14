using AutoMapper;
using avianoise.BL;
using avianoise.Domain;
using avianoise.Web.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SharpCompress.Archives;
using SharpCompress.Archives.Rar;
using SharpCompress.Archives.Zip;
using SharpCompress.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace avianoise.Web.Api
{
    [Route("api/zip/unpack")]
    public class ZipUnpackController : BaseUserController
    {
        private static readonly string FilesDirectory = "static\\files";
        private readonly IZipBL zipBL;
        private readonly IFileBL fileBL;
        private readonly IMapper mapper;

        public ZipUnpackController(IUserBL userBL, IZipBL zipBL, IFileBL fileBL, IMapper mapper) : base(userBL)
        {
            this.zipBL = zipBL;
            this.fileBL = fileBL;
            this.mapper = mapper;
        }

        [HttpGet("{zipId:int}")]
        [Authorize]
        [Produces("application/json")]
        [ProducesResponseType(typeof(List<FileDto>), (int)HttpStatusCode.OK)]
        public IActionResult Get(int zipId)
        {
            var zipEntry = zipBL.Get(zipId);
            var extension = zipEntry.FilePath.Substring(zipEntry.FilePath.LastIndexOf("."));
            var files = new List<Domain.File>();

            switch (extension)
            {
                case ".zip":
                    files = Unzip(zipEntry.FilePath, zipEntry.AirportId);
                    break;
                case ".rar":
                    files = Unrar(zipEntry.FilePath, zipEntry.AirportId);
                    break;
            }
            var newFiles = SaveFiles(files);
            var result = mapper.Map<List<Domain.File>, List<FileDto>>(newFiles);
            return Ok(result);

        }

        private List<Domain.File> SaveFiles(List<Domain.File> files)
        {
            var list = new List<Domain.File>();
            foreach (var file in files)
            {
                var newEntry = fileBL.Create(file);
                list.Add(newEntry);
            }
            return list;
        }

        private List<Domain.File> Unzip(string zipPath, int airportId)
        {
            using (var archive = ZipArchive.Open(zipPath))
            {
                return Unpack(archive, airportId);
            }
        }

        private List<Domain.File> Unrar(string zipPath, int airportId)
        {
            using (var archive = RarArchive.Open(zipPath))
            {
                return Unpack(archive, airportId);
            }
        }

        private List<Domain.File> Unpack(IArchive archive, int airportId)
        {
            var list = new List<Domain.File>();
            var directory = Path.Combine(FilesDirectory);
            foreach (var entry in archive.Entries.Where(entry => !entry.IsDirectory))
            {
                entry.WriteToDirectory(directory, new ExtractionOptions()
                {
                    ExtractFullPath = true,
                    Overwrite = true
                });
                var filePath = entry.Key;
                var fileIndex = filePath.LastIndexOf("/");
                var fileName = fileIndex > -1 ? filePath.Substring(fileIndex + 1) : filePath;
                var fileExtension = fileName.Substring(fileName.LastIndexOf("."));

                list.Add(new Domain.File()
                {
                    AirportId = airportId,
                    Extension = fileExtension,
                    FileName = fileName,
                    FullPath = Path.Combine(directory, filePath)
                });
            }
            return list;
        }
    }
}
