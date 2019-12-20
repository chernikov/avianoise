using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace avianoise.Domain
{
    public class Zip
    {
        [Key]
        public int Id { get; set; }

        public int AirportId { get; set; }

        public Airport Airport { get; set; }

        public DateTime AddedDate { get; set; }

        [MaxLength(100)]
        public string FileName { get; set; }

        [MaxLength(150)]
        public string FilePath { get; set; }
    }
}
