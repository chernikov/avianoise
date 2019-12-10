using System.ComponentModel.DataAnnotations;

namespace avianoise.Web.Errors
{
    public class BadRequestMessage
    {
        [Required]
        public string Message { get; set; }
    }
}
