using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using avianoise.Domain;

namespace avianoise.BL
{
    public interface IRoleBL : IBaseBL
    {
        IList<Role> GetList();
    }
}
