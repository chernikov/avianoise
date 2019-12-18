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
        public Zip Create(Zip entry)
        {
            return zipRepository.Create(entry);
        }
    }
}
