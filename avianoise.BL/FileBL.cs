using avianoise.DAL;
using avianoise.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace avianoise.BL
{
    public class FileBL : IFileBL
    {
        private readonly IFileRepository fileRepository;

        public FileBL(IFileRepository fileRepository)
        {
            this.fileRepository = fileRepository;
        }

        public File Create(File entry)
        {
            return fileRepository.Create(entry);
        }
    }
}
