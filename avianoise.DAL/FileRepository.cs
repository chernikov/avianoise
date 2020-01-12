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
    public class FileRepository : BaseRepository, IFileRepository
    {
        public FileRepository(Func<IAviaNoiseDbContext> getDbContext) : base(getDbContext)
        {
        }

        public List<File> GetListByAirport(int airportId, bool onlyDecoded)
            => Query(context =>
                context.Files
                .Include(p => p.Lines)
                .ThenInclude(l => l.Points)
                .Where(p => p.AirportId == airportId && (!onlyDecoded || p.IsDecoded))
                .ToList());

        public File Get(int fileId)
            => Query(context => context.Files.FirstOrDefault(p => p.Id == fileId));

        public File Create(File entry)
            => Execute(context =>
           {
               context.Files.Add(entry);
               context.SaveChanges();
               return entry;
           });

        public void Delete(int fileId)
            => Execute(context =>
            {
                var entry = context.Files.Find(fileId);
                if (entry != null)
                {
                    context.Files.Remove(entry);
                }
            });

        public File MarkDecodeFile(File fileEntry)
             => Execute(context =>
             {
                 var entry = context.Files.Find(fileEntry.Id);
                 if (entry != null)
                 {
                     entry.IsDecoded = true;
                     context.SaveChanges();
                 }
                 return entry;
             });
    }
}
