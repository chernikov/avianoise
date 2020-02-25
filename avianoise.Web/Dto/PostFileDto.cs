using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace avianoise.Web.Dto
{
    public class PostFileDto
    {
        public int Id { get; set; }

        public string FullPath { get; set; }

        public DateTime AddedDate { get; set; }
    }
}
