using avianoise.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace avianoise.BL
{
    public interface IZipBL : IBaseBL
    {
        Zip Create(Zip entry);

        List<Zip> GetList(int airportId);

        Zip Get(int zipId);

        void Delete(int zipId);
    }
}
