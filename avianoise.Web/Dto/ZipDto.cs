using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace avianoise.Web.Dto
{
    public class ZipDto
    {
        public int Id { get; set; }

        public int AirportId { get; set; }

        public DateTime AddedDate { get; set; }

        public string FileName { get; set; }

        public string FilePath { get; set; }
    }
}
