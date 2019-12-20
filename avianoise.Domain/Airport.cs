using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace avianoise.Domain
{
    public class Airport
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public double Lat { get; set; }

        public double Lng { get; set; }

        public ICollection<File> Files { get; set; }

        public ICollection<Line> Lines { get; set; }

        public ICollection<Zip> Zips { get; set; }
    }
}
