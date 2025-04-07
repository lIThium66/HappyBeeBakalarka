using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VersionOneWA.Data;
using VersionOneWA.Shared.Classes;

namespace VersionOneWA.Shared.Services
{
    public class FriendService : IFriendService
    {
        private readonly ApplicationDbContext _context;

        public FriendService(ApplicationDbContext context)
        {
            _context = context;
        }

       public async Task<bool> SendFriendRequestAsync(string senderId, string receiverId)
        {
            if (await _context.FriendRequests.AnyAsync(fr =>
                fr.SenderId == senderId && fr.ReceiverId == receiverId))
                return false;

            var request = new FriendRequest
            {
                SenderId = senderId,
                ReceiverId = receiverId,
                Status = RequestStatus.Pending, 
                SentDate = DateTime.UtcNow
            };

            _context.FriendRequests.Add(request);
            await _context.SaveChangesAsync();
            return true;
        }


        public async Task<bool> AcceptFriendRequestAsync(int requestId)
        {
            var request = await _context.FriendRequests.FindAsync(requestId);
            if (request == null) return false;

            request.isAccepted = true;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> RejectFriendRequestAsync(int requestId)
        {
            var request = await _context.FriendRequests.FindAsync(requestId);
            if (request == null) return false;

            _context.FriendRequests.Remove(request);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<ApplicationUser>> GetFriendsAsync(string userId)
        {
            var friendships = await _context.Friendships
                 .Where(f => f.UserId1 == userId || f.UserId2 == userId)
                 .ToListAsync();

           
            if (!friendships.Any())
            {
                return new List<ApplicationUser>();
            }

            var friendIds = friendships.Select(f => f.UserId1 == userId ? f.UserId2 : f.UserId1).ToList();

            var friends = await _context.Users
                .Where(u => friendIds.Contains(u.Id))
                .ToListAsync();

            return friends;
        }

        public async Task<List<FriendRequest>> GetPendingRequestsAsync(string userId)
        {
            return await _context.FriendRequests
                .Where(fr => fr.ReceiverId == userId && !fr.isAccepted)
                .Include(fr => fr.Sender)
                .ToListAsync();
        }

        public async Task<bool> AreFriends(string userId1, string userId2)
        {
            return await _context.Friendships.AnyAsync(f =>
                (f.UserId1 == userId1 && f.UserId2 == userId2) ||
                (f.UserId1 == userId2 && f.UserId2 == userId1));
        }

        public async Task<List<FriendRequest>> GetFriendRequestsAsync(string userId)
        {
            return await _context.FriendRequests
                .Where(fr => fr.ReceiverId == userId && fr.Status == RequestStatus.Pending)
                .ToListAsync();
        }

        public async Task<bool> HasPendingRequest(string userId1, string userId2)
        {

            var pendingRequest = await _context.FriendRequests
                .Where(r => (r.SenderId == userId1 && r.ReceiverId == userId2) ||
                            (r.SenderId == userId2 && r.ReceiverId == userId1))
                                .FirstOrDefaultAsync();
            return pendingRequest != null;
        }
    }

}
