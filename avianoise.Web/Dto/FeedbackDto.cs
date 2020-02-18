using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace avianoise.Web.Dto
{
    public class FeedbackDto
    {
        public int Id { get; set; }

        public DateTime AddedDate { get; set; }

        [Required]
        public string Name { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Message { get; set; }

        public List<FeedbackFileDto> FeedbackFiles { get; set; }

    }
}
