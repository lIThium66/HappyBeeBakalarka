using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VersionOneWA.Shared.Classes;

namespace VersionOneWA.Shared.Services
{
    public interface IFriendService
    {   
        Task<bool> SendFriendRequestAsync(string senderId, string receiverId);
        Task<bool> AcceptFriendRequestAsync(int requestId);
        Task<bool> RejectFriendRequestAsync(int requestId);
        Task<List<ApplicationUser>> GetFriendsAsync(string userId);
        Task<List<FriendRequest>> GetPendingRequestsAsync(string userId);
        Task<bool> AreFriends(string userId1, string userId2);
        Task<bool> HasPendingRequest(string userId1, string userId2);
        Task<List<FriendRequest>> GetFriendRequestsAsync(string userId);
    }

}
