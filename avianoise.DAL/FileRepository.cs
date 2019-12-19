using avianoise.Data;
using avianoise.Domain;
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

        public File Create(File entry) =>
            Execute(context =>
            {
                context.Files.Add(entry);
                context.SaveChanges();
                return entry;
            });
    }
}
