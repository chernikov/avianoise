using avianoise.Data;
using avianoise.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace avianoise.DAL
{
    public class LineRepository : BaseRepository, ILineRepository
    {
        public LineRepository(Func<IAviaNoiseDbContext> getDbContext) : base(getDbContext)
        {
        }

        public Line Create(Line entry) =>
            Execute(context =>
            {
                entry.AddedDate = DateTime.Now;
                context.Lines.Add(entry);
                context.SaveChanges();
                return entry;
            });

        public Line GetById(int entryId)
            => Query(context =>
                context.Lines
                    .Include(p => p.Points)
                    .FirstOrDefault(p => p.Id == entryId));

        public List<Line> GetListByAirport(int airportId)
            => Query(context =>
                context.Lines
                    .Include(p => p.Points)
                    .Where(p => p.AirportId == airportId)
                    .ToList());
    }
}
