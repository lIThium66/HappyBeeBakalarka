using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VersionOneWA.Shared.Classes
{
    public class Status
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Water { get; set; }
        public string? WaterDescription { get; set; }

        public string? Treatment { get; set; }
        public string? TreatmentDescription { get; set; }

        public int Sugar { get; set; }
        public string? SugarDescription { get; set; }


    }
}
