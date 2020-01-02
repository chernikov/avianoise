using avianoise.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace avianoise.DAL
{
    public interface IZipRepository : IBaseRepository
    {
        List<Zip> GetList(int airportId);

        Zip Get(int zipId);

        Zip Create(Zip zip);

        void Delete(int zipId);


    }
}
