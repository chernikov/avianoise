using avianoise.DAL;
using avianoise.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace avianoise.BL
{
    public class ZipBL : IZipBL
    {
        private readonly IZipRepository zipRepository;

        public ZipBL(IZipRepository zipRepository)
        {
            this.zipRepository = zipRepository;
        }

        public List<Zip> GetList(int airportId)
        {
            return zipRepository.GetList(airportId);
        }

        public Zip Create(Zip entry)
        {
            return zipRepository.Create(entry);
        }


        public void Delete(int zipId)
        {
            zipRepository.Delete(zipId);
        }
    }
}
