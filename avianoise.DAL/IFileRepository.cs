using avianoise.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace avianoise.DAL
{
    public interface IFileRepository : IBaseRepository
    {
        List<File> GetListByAirport(int airportId);
        File Get(int fileId);

        File Create(File entry);

        void Delete(int fileId);
    }
}
