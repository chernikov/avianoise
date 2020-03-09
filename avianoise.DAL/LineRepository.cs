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

        public Line GetById(int entryId)
            => Query(context =>
                context.Lines
                    .Include(p => p.Points)
                    .Include(p => p.File)
                    .FirstOrDefault(p => p.Id == entryId));

        public List<Line> GetListByAirport(int airportId)
            => Query(context =>
                context.Lines
                    .Include(p => p.Points)
                    .Include(p => p.File)
                    .Where(p => p.AirportId == airportId)
                    .ToList());

        public List<Line> GetByFileId(int fileId)
            => Query(context =>
                context.Lines
                    .Include(p => p.Points)
                    .Include(p => p.File)
                    .Where(p => p.FileId == fileId)
                    .ToList());

        public Line Create(Line entry) =>
          Query(context =>
          {
              entry.AddedDate = DateTime.Now;
              context.Lines.Add(entry);
              context.SaveChanges();
              return entry;
          });

        public Line Update(Line entry) =>
            Query(context =>
            {
                var savedEntry = context.Lines.Find(entry.Id);
                if (savedEntry != null)
                {
                    savedEntry.Level = entry.Level;
                    savedEntry.Name = entry.Name;
                    savedEntry.Published = entry.Published;
                    context.Lines.Update(savedEntry);
                    context.SaveChanges();
                    return savedEntry;
                }
                return null;
            });

        public void Delete(int lineId) =>
            Query(context =>
            {
                var savedEntry = context.Lines.Find(lineId);
                if (savedEntry != null)
                {
                    context.Lines.Remove(savedEntry);
                    context.SaveChanges();
                }
            });

        public void CreatePoints(List<Point> points)
            => Query(context =>
            {
                foreach (var point in points)
                {
                    context.Points.Add(point);
                }
                context.SaveChanges();
            });

        public void DeleteLinesByFileId(int fileId)
             => Query(context =>
            {
                var forRemove = context.Lines.Where(p => p.FileId == fileId);
                context.Lines.RemoveRange(forRemove);
                context.SaveChanges();
            });
    }
}
