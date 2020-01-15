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
            {
                var files = context.Files
                     .Where(p => p.AirportId == airportId && (!onlyDecoded || p.IsDecoded)).ToList();

                var lines = context.Lines
                    .Include(l => l.Points)
                    .Where(p => p.File.AirportId == airportId && (!onlyDecoded || p.File.IsDecoded)).ToList();

                foreach (var file in files)
                {
                    file.Lines = lines.Where(p => p.FileId == file.Id).ToList();
                }
                return files;
            });




        public File Get(int fileId)
            => Query(context => context.Files.FirstOrDefault(p => p.Id == fileId));


        public File GetWithLines(int fileId)
            => Query(context =>
                 context.Files
                        .Include(p => p.Lines)
                        .ThenInclude(p => p.Points)
                        .FirstOrDefault(p => p.Id == fileId));

        public File Create(File entry)
            => Execute(context =>
           {
               context.Files.Add(entry);
               context.SaveChanges();
               return entry;
           });


        public File UpdateTypes(File entry)
           => Execute(context =>
           {
               var entity = context.Files.Find(entry.Id);
               if (entity == null)
               {
                   return null;
               }
               entity.NoiseType = entry.NoiseType;
               entity.TimeType = entry.TimeType;
               context.Files.Update(entity);
               context.SaveChanges();

               var newEntry = context.Files.Find(entry.Id);
               return newEntry;
           });

        public void Delete(int fileId)
            => Execute(context =>
            {
                var entry = context.Files.Find(fileId);

                if (entry != null)
                {
                    var lines = context.Lines.Where(p => p.FileId == fileId).ToList();
                    context.Lines.RemoveRange(lines);
                    context.Files.Remove(entry);
                    context.SaveChanges();
                }
            });


        public void ClearLines(int fileId)

            => Execute(context =>
            {
                var entry = context.Files.Find(fileId);

                if (entry != null)
                {
                    var lines = context.Lines.Where(p => p.FileId == fileId).ToList();
                    context.Lines.RemoveRange(lines);
                    entry.IsDecoded = false;
                    context.SaveChanges();
                }
            });


        public File MarkDecodeFile(File fileEntry, bool isDecoded)
             => Execute(context =>
             {
                 var entry = context.Files.Find(fileEntry.Id);
                 if (entry != null)
                 {
                     entry.IsDecoded = isDecoded;
                     context.SaveChanges();
                 }
                 return entry;
             });


    }
}
