using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace avianoise.Domain
{
    public class Practice
    {
        [Key]
        public int Id { get; set; }

        public int? PracticeId { get; set; }

        [MaxLength(500)]
        public string Title { get; set; }

        public int Order { get; set; }

        public string Text { get; set; }

        public bool IsPublished { get; set; }

        public DateTime AddedDate { get; set; }

        public List<Practice> Practices { get; set; }
    }
}
