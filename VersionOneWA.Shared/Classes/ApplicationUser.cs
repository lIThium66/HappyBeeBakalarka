using Microsoft.AspNetCore.Identity;

namespace VersionOneWA.Shared.Classes
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        public DateOnly? DateOfBirth { get; set; }
        public string Name { get; set; } = null!;
        public string Surname { get; set; } = null!;
        public ICollection<Job> Jobs { get; set; }
        public ICollection<Friends> Friends { get; set; }
        public ICollection<BeehiveBase> BeehiveBases { get; set; }



        //priatelia
        public ICollection<FriendRequest> SentRequests { get; set; }
        public ICollection<FriendRequest> ReceivedRequests { get; set; }
    }
        
}       
