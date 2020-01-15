using avianoise.Data;
using avianoise.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace avianoise.DAL
{
    public class AirportRepository : BaseRepository, IAirportRepository
    {
        public AirportRepository(Func<IAviaNoiseDbContext> getDbContext) : base(getDbContext)
        {
        }

        public List<Airport> GetList() =>
             Query(context => context.Airports.ToList());

        public Airport Get(int airportId) =>
            Query(context => context.Airports.FirstOrDefault(p => p.Id == airportId));


        public Airport Create(Airport entry)
            => Execute(context =>
            {
                context.Airports.Add(entry);
                context.SaveChanges();
                return entry;
            });

        public Airport Update(Airport entry)
             => Execute(context =>
             {
                 context.Airports.Update(entry);
                 context.SaveChanges();
                 return entry;
             });

        public void Delete(int airportId)
            => Execute(context =>
            {
                var entry = context.Airports.Find(airportId);
                if (entry != null)
                {
                    context.Airports.Remove(entry);
                    context.SaveChanges();
                }
            });
    }
}
