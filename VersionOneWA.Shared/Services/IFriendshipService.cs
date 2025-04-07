using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VersionOneWA.Shared.Classes;

namespace VersionOneWA.Shared.Services
{
    public interface IFriendshipService
    {
        Task<bool> AddFriendshipAsync(string userId1, string userId2);
        Task<List<ApplicationUser>> GetFriendsAsync(string userId);
        Task<bool> RemoveFriendshipAsync(string userId1, string userId2);
        Task<List<ApplicationUser>> GetPendingRequestsAsync(string userId);
        Task<bool> ConfirmFriendRequestAsync(string receiverId, string senderId);
        Task<bool> RemoveFriendRequestAsync(string receiverId, string senderId);
    }
}
