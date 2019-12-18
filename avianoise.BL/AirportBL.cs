using avianoise.DAL;
using avianoise.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace avianoise.BL
{
    public class AirportBL : IAirportBL
    {
        private readonly IAirportRepository airportRepository;

        public AirportBL(IAirportRepository airportRepository)
        {
            this.airportRepository = airportRepository;
        }

        public Airport Get(int airportId)
        {
            return airportRepository.Get(airportId);
        }

        public List<Airport> GetList()
        {
            return airportRepository.GetList();
        }

        public Airport Create(Airport entry)
        {
            return airportRepository.Create(entry);
        }

        public Airport Update(Airport entry)
        {
            return airportRepository.Update(entry);
        }

        public void Delete(int airportId)
        {
            airportRepository.Delete(airportId);
        }
    }
}
