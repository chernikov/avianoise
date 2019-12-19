using avianoise.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace avianoise.BL
{
    public interface IFileBL : IBaseBL
    {
        File Create(File entry);
    }
}
