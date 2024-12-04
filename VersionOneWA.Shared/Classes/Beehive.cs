using System.ComponentModel.DataAnnotations;

namespace VersionOneWA.Shared.Classes
{
    public class Beehive
    {

        [Key]
        public int Id { get; set; }

        [Required]
        public String Name { get; set; } = null!;

        public int numberOfBees { get; set; }

        public int QueensAge { get; set; }
    }
}
