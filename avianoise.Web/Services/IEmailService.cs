using avianoise.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace avianoise.Web.Services
{
    public interface IEmailService
    {
        bool SendFeedback(Feedback feedback);
    }
}
