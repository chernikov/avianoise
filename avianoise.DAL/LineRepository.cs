﻿using avianoise.Data;
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
                    .FirstOrDefault(p => p.Id == entryId));

        public List<Line> GetListByAirport(int airportId)
            => Query(context =>
                context.Lines
                    .Include(p => p.Points)
                    .Where(p => p.AirportId == airportId)
                    .ToList());

        public Line Create(Line entry) =>
          Execute(context =>
          {
              entry.AddedDate = DateTime.Now;
              context.Lines.Add(entry);
              context.SaveChanges();
              return entry;
          });

        public Line Update(Line entry) =>
            Execute(context =>
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
            Execute(context =>
            {
                var savedEntry = context.Lines.Find(lineId);
                if (savedEntry != null)
                {
                    context.Lines.Remove(savedEntry);
                    context.SaveChanges();
                }
            });
    }
}
