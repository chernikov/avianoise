using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace avianoise.Domain
{
    public class PostFile
    {
        [Key]
        public int Id { get; set; }

        public string FullPath { get; set; }

        public DateTime AddedDate { get; set; }
    }
}
