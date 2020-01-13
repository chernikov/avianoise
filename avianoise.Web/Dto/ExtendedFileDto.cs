using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace avianoise.Web.Dto
{
    public class ExtendedFileDto : FileDto
    {

        public List<LineDto> Lines { get; set; }
    }
}
