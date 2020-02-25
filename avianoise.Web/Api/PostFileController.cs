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
    [Route("/api/post-file")]
    public class PostFileController : BaseUserController
    {
        private readonly string PostImageDirectory = "post_images";

        private readonly IPostFileBL postFileBL;
        private readonly IMapper mapper;

        public PostFileController(IUserBL userBL, IPostFileBL postFileBL, IMapper mapper) : base(userBL)
        {
            this.postFileBL = postFileBL;
            this.mapper = mapper;
        }

        [HttpGet]
        [Authorize]
        [ProducesResponseType(typeof(List<PostFileDto>), (int)HttpStatusCode.OK)]
        public IActionResult Get()
        {
            var list = postFileBL.GetList();

            var result = mapper.Map<List<PostFileDto>>(list);
            return Ok(result);
        }

        [HttpPost]
        [Authorize]
        [ProducesResponseType(typeof(PostFileDto), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Upload()
        {
            var files = Request.Form.Files;

            if (files.Count <= 0)
            {
                return BadRequest();
            }
            var file = files[0];
            if (file.Length == 0)
            {
                return BadRequest();
            }
            var directoryPath = Path.Combine("static", PostImageDirectory);
            var di = new DirectoryInfo(directoryPath);
            if (!di.Exists)
            {
                di.Create();
            }
            var fileExtension = Path.GetExtension(file.FileName);
            var fileName = Guid.NewGuid().ToString("N") + fileExtension;
            var fullPath = Path.Combine(directoryPath, fileName);
            using (var inputStream = new FileStream(fullPath, FileMode.Create))
            {
                // read file to stream
                await file.CopyToAsync(inputStream);
                // stream to byte array
                byte[] array = new byte[inputStream.Length];
                inputStream.Seek(0, SeekOrigin.Begin);
                inputStream.Read(array, 0, array.Length);
            }
            var entry = new PostFile()
            {
                FullPath = fullPath,
            };
            var savedEntry = postFileBL.Create(entry);
            var result = mapper.Map<PostFileDto>(savedEntry);
            return Ok(result);
        }

        [HttpDelete("{id:int}")]
        [Authorize]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.OK)]
        public IActionResult Delete(int id)
        {
            var entry = postFileBL.Get(id);
            var fi = new FileInfo(entry.FullPath);
            if (fi.Exists)
            {
                fi.Delete();
            }
            postFileBL.Remove(id);
            return Ok();
        }
    }
}
