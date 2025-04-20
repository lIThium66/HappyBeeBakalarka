using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

        public bool IsCompleted { get; set; } = false;

        public DateTime? JobDate { get; set; }


        //user

        public string UserId { get; set; } = null!;

        [ForeignKey("UserId")]
        public ApplicationUser User { get; set; } = null!;

        ////beehivebase

        //public int BeehiveBaseId { get; set; }
        //[ForeignKey("BeehiveBaseId")]
        //public BeehiveBase BeehiveBase { get; set; } = null!;


    }
}
