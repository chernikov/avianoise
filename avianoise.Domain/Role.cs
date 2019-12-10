using System.ComponentModel.DataAnnotations;

namespace avianoise.Domain
{
    public class Role
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(10)]
        public string Code { get; set; }

        [MaxLength(150)]
        public string Name { get; set; }

        public override string ToString()
        {
            return $"{Code}";
        }
    }
}
