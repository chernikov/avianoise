using avianoise.Data;
using avianoise.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace avianoise.DAL
{
    public class ZipRepository : BaseRepository, IZipRepository
    {
        public ZipRepository(Func<IAviaNoiseDbContext> getDbContext) : base(getDbContext)
        {
        }

        public List<Zip> GetList(int airportId)
            => Query(context =>
             context.Zips.Where(p => p.AirportId == airportId)
            .ToList());

        public Zip Get(int zipId)
            => Query(context =>
            context.Zips.FirstOrDefault(p => p.Id == zipId));


        public Zip Create(Zip zip)
            => Query(context =>
            {
                context.Zips.Add(zip);
                context.SaveChanges();
                return zip;
            });

        public void Delete(int zipId)
            => Query(context =>
            {
                var entry = context.Zips.Find(zipId);
                if (entry != null)
                {
                    context.Zips.Remove(entry);
                    context.SaveChanges();
                }
            });
    }
}
