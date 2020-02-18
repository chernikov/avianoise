using avianoise.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace avianoise.BL
{
    public interface IFeedbackFileBL : IBaseBL
    {
        FeedbackFile Create(FeedbackFile entry);
    }
}
