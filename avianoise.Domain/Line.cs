using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace avianoise.Domain
{
    public class Line
    {
        [Key]
        public int Id { get; set; }

        public int AirportId { get; set; }

        public Airport Airport { get; set; }

        public int FileId { get; set; }

        public File File { get; set; }

        public DateTime AddedDate { get; set; }

        public double Level { get; set; }

        [MaxLength(80)]
        public string Name { get; set; }

        public bool Published { get; set; }

        public ICollection<Point> Points { get; set; }
    }
}
