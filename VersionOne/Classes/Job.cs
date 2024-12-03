using System.ComponentModel.DataAnnotations;

namespace VersionOne.Classes
{
    public class Job
    {

        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = null!;

        public int Priority;

        public string? Description { get; set; }

        public bool? IsCompleted { get; set; }

        

        public Job() {
            
        
        }

        public int SetTaskPriority()
        {
            
            return Priority;
        }


    }
}
