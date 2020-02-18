using avianoise.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace avianoise.DAL
{
    public interface IFeedbackRepository : IBaseRepository
    {
        Feedback Create(Feedback feedback);

        List<Feedback> GetByPage(int page, int pageSize, out int total);
    }
}
