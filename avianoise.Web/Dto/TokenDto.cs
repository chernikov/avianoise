using System.ComponentModel.DataAnnotations;

namespace avianoise.Web.Dto
{
    public class TokenDto
    {
        [Required]
        public string Token { get; set; }
    }
}
