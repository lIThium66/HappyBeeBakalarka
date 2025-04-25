using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VersionOneWA.Shared.Classes
{
    public class Status
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Report needs a name!")]
        public string Name { get; set; } = null!;

        [Required(ErrorMessage = "Empty report!")]
        public string Report { get; set; } = null!;

        public DateTime? CreatedAt { get; set; }
        public bool? doneTreatment { get; set; }
        public bool? suppliedWater { get; set; }
        public bool? suppliedSugar { get; set; }

        //user

        public string UserId { get; set; } = null!;

        [ForeignKey("UserId")]
        public ApplicationUser User { get; set; } = null!;
    }
}
