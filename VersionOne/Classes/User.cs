using System.ComponentModel.DataAnnotations;

namespace VersionOne.Classes
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = null!;

        [Required]
        public string Email { get; set; } = null!;

        public string? PhoneNumber { get; set; } 

    }
}
