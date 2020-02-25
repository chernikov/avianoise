using avianoise.Data;
using avianoise.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace avianoise.DAL
{
    public class PostFileRepository : GenericRepository<PostFile>, IPostFileRepository, IBaseRepository
    {
        public PostFileRepository(Func<IAviaNoiseDbContext> getDbContext) : base(getDbContext)
        {
        }
    }
}
