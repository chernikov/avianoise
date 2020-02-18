using avianoise.Data;
using avianoise.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace avianoise.DAL
{
    public class FeedbackFileRepository : GenericRepository<FeedbackFile>, IFeedbackFileRepository, IBaseRepository
    {
        public FeedbackFileRepository(Func<IAviaNoiseDbContext> getDbContext) : base(getDbContext)
        {
        }
    }
}
