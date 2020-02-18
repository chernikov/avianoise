using AutoMapper;
using avianoise.BL;
using avianoise.Domain;
using avianoise.Web.Dto;
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
    [Route("api/feedback-file")]
    public class FeedbackFileController : BaseController
    {
        private const string FilesDirectory = "feedbackfiles";
        private readonly IFeedbackFileBL feeedbackFileBL;
        private readonly IMapper mapper;

        public FeedbackFileController(IFeedbackFileBL feeedbackFileBL, IMapper mapper)
        {
            this.feeedbackFileBL = feeedbackFileBL;
            this.mapper = mapper;
        }


        [HttpPost]
        [Produces("application/json")]
        [ProducesResponseType(typeof(List<FeedbackFileDto>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Post()
        {
            var files = Request.Form.Files;
            var list = new List<FeedbackFile>();

            foreach (var file in files)
            {
                var fileName = file.FileName;
                var extension = fileName.Substring(fileName.LastIndexOf("."));

                var newFileName = Guid.NewGuid().ToString("N") + extension;
                var directoryPath = Path.Combine("static", FilesDirectory);
                var di = new DirectoryInfo(directoryPath);
                if (!di.Exists) di.Create();
                var filePath = Path.Combine(directoryPath, newFileName);
                using (var fileStream = System.IO.File.Create(filePath))
                {
                    await file.CopyToAsync(fileStream);
                    var entry = new FeedbackFile()
                    {
                        FullPath = filePath,
                        Name = fileName
                    };
                    var newFile = feeedbackFileBL.Create(entry);
                    list.Add(newFile);
                }
            }
            var result = mapper.Map<List<FeedbackFile>, List<FeedbackFileDto>>(list);
            return Ok(result);
        }

    }
}
