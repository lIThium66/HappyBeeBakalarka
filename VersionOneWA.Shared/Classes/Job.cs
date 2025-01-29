using System.ComponentModel.DataAnnotations;

namespace VersionOneWA.Shared.Classes
{
    public class Job
    {

        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Please give this task a Name!")]
        public string Name { get; set; } = null!;

        public int Priority { get; set; } = 3;
        [MaxLength(500, ErrorMessage = "Description cannot exceed 500 characters.")]
        public string? Description { get; set; }

        public bool? IsCompleted { get; set; }

        public DateTime? JobDate { get; set; }

    }
}
