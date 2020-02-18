using avianoise.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace avianoise.BL
{
    public interface IFeedbackBL : IBaseBL
    {
        Feedback Create(Feedback entry);

        List<Feedback> GetByPage(int page, int pageSize, out int total);
    }
}
