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

        public Zip Create(Zip zip)
            => Execute(context =>
            {
                context.Zips.Add(zip);
                context.SaveChanges();
                return zip;
            });
    }
}
