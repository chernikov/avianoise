using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace avianoise.SL
{
    public interface IEmailSenderSL : IBaseSL
    {
        bool SendEmail(string email, string title, string body);
    }
}
