using avianoise.SL.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace avianoise.SL
{
    public interface IGoogleMapSL : IBaseSL
    {
        Location GetLocationByAddress(string Address, out string fullResult);
    }
}
