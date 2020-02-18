using avianoise.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace avianoise.BL
{
    public interface ILogMessageBL : IBaseBL
    {
        LogMessage Create(LogMessage entry);
    }
}
