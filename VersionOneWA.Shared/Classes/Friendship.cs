using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VersionOneWA.Shared.Classes
{
    public class Friendship
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string UserId1 { get; set; }
        public ApplicationUser User1 { get; set; }

        [Required]
        public string UserId2 { get; set; }
        public ApplicationUser User2 { get; set; }
    }
}
