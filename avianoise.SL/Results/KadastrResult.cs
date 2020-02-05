using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace avianoise.SL.Results
{
    public class KadastrResult<T>
    {
        public bool Status { get; set; }

        public List<T> Data { get; set; }
    }
}
