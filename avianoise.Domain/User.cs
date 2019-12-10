using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace avianoise.Domain
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(150)]
        public string Name { get; set; }

        [MaxLength(150)]
        public string Email { get; set; }

        [MaxLength(150)]
        public string Password { get; set; }

        public ICollection<UserRole> UserRoles { get; set; }


        public override string ToString()
        {
            return $"{Id} {Name} {Email}";
        }
    }
}
