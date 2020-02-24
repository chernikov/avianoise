using avianoise.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace avianoise.DAL
{
    public interface IFeedbackFileRepository : IGenericRepository<FeedbackFile>, IBaseRepository
    {
        void Clear();
    }
}
