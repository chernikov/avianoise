using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace avianoise.Domain
{
    public class FeedbackFile
    {
        [Key]
        public int Id { get; set; }

        public int? FeedbackId { get; set; }

        public Feedback Feedback { get; set; }

        public string Name { get; set; }

        public string FullPath { get; set; }
    }
}
