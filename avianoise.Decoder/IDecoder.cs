using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace avianoise.Decoder
{
    public interface IDecoder
    {
        List<Line> Decode(string content);
    }
}
