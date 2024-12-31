using System.ComponentModel.DataAnnotations;

namespace VersionOneWA.Shared.Classes
{
    public class Beehive
    {

        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please give this beehive a name! ")]
        public String Name { get; set; } = null!;

        public int? numberOfBees { get; set; } = 0;

        public double? beehiveWeight { get; set; } = 0;

        public int? QueensAge { get; set; } = 0;
    }
}
