using avianoise.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace avianoise.BL
{
    public interface IFileBL : IBaseBL
    {
        File Get(int fileId);

        List<File> GetListByAirport(int airportId);

        File Create(File entry);


        void Delete(int fileId);

    }
}
