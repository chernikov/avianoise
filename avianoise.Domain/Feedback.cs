using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace avianoise.Domain
{
    public class Feedback
    {
        [Key]
        public int Id { get; set; }

        public DateTime AddedDate { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Message { get; set; }

        public List<FeedbackFile> FeedbackFiles { get; set; }
    }
}
