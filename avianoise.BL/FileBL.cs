﻿using avianoise.DAL;
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

        public File MarkDecodeFile(File fileEntry)
        {
            return fileRepository.MarkDecodeFile(fileEntry);
        }
    }
}
