using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace avianoise.Web.Dto
{
    public class ExtendedLineDto : LineDto
    {
        public FileDto File { get; set; }
    }
}
