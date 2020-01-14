using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace avianoise.Domain
{
    public class File
    {
        [Key]
        public int Id { get; set; }

        public int AirportId { get; set; }

        public Airport Airport { get; set; }

        [MaxLength(1000)]
        public string FullPath { get; set; }

        [MaxLength(100)]
        public string FileName { get; set; }

        [MaxLength(10)]
        public string Extension { get; set; }

        public bool IsDecoded { get; set; }

        public ICollection<Line> Lines { get; set; }
    }
}
