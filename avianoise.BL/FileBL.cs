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

        public File Get(int fileId)
        {
            return fileRepository.Get(fileId);
        }

        public File GetWithLines(int fileId)
        {
            return fileRepository.GetWithLines(fileId);
        }

        public List<File> GetListByAirport(int airportId, bool onlyDecoded)
        {
            return fileRepository.GetListByAirport(airportId, onlyDecoded);
        }


        public File Create(File entry)
        {
            return fileRepository.Create(entry);
        }

        public void Delete(int fileId)
        {
            fileRepository.Delete(fileId);
        }

        public void ClearLines(int fileId)
        {
            fileRepository.ClearLines(fileId);
        }

        public File MarkDecodeFile(File fileEntry, bool isDecoded = true)
        {
            return fileRepository.MarkDecodeFile(fileEntry, isDecoded);
        }

        public File UpdateTypes(File fileEntry)
        {
            return fileRepository.UpdateTypes(fileEntry);
        }
    }
}
