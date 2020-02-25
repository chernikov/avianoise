using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace avianoise.Domain
{
    public class Post
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(500)]
        public string Title { get; set; }

        public string Text { get; set; }

        public bool IsPublished { get; set; }


        public DateTime AddedDate { get; set; }
    }
}
