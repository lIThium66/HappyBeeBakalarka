using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VersionOneWA.Shared.Classes
{
    public class BeehiveMember
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }


        //public string UserId { get; set; }
        //[ForeignKey("UserId")]
        //public ApplicationUser User { get; set; } = null!;


        //public int BeehiveBaseId { get; set; }
        //[ForeignKey("BeehiveBaseId")]
        //public BeehiveBase BeehiveBase { get; set; } = null!;


    }
}
