using avianoise.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace avianoise.DAL
{
    public interface IAirportRepository : IBaseRepository
    {
        List<Airport> GetList();

        Airport Get(int airportId);

        Airport Create(Airport entry);

        Airport Update(Airport entry);

        void Delete(int airportId);
    }
}
