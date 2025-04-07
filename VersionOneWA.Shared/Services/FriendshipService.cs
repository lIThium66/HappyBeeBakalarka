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
    public class FriendshipService : IFriendshipService
    {
        private readonly ApplicationDbContext _context;

        public FriendshipService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> AddFriendshipAsync(string userId1, string userId2)
        {
           
            if (await _context.Friendships.AnyAsync(f =>
                (f.UserId1 == userId1 && f.UserId2 == userId2) ||
                (f.UserId1 == userId2 && f.UserId2 == userId1)))
            {
                return false; 
            }

         
            if (await _context.FriendRequests.AnyAsync(fr =>
                (fr.SenderId == userId1 && fr.ReceiverId == userId2) ||
                (fr.SenderId == userId2 && fr.ReceiverId == userId1)))
            {
                return false; 
            }

            var request = new FriendRequest
            {
                SenderId = userId1,
                ReceiverId = userId2,
                isAccepted = false
            };

            _context.FriendRequests.Add(request);
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

            return friends ?? new List<ApplicationUser>();
        }

        public async Task<bool> RemoveFriendshipAsync(string userId1, string userId2)
        {
            var friendship = await _context.Friendships.FirstOrDefaultAsync(f =>
                (f.UserId1 == userId1 && f.UserId2 == userId2) ||
                (f.UserId1 == userId2 && f.UserId2 == userId1));

            if (friendship == null) return false;

            _context.Friendships.Remove(friendship);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<ApplicationUser>> GetPendingRequestsAsync(string userId)
        {
            
            var pendingRequests = await _context.FriendRequests
                .Where(fr => fr.ReceiverId == userId && !fr.isAccepted)  
                .Include(fr => fr.Sender)  
                .ToListAsync();

            var friendRequests = pendingRequests.Select(r => r.Sender).ToList();

            return friendRequests;
        }

        public async Task<bool> ConfirmFriendRequestAsync(string receiverId, string senderId)
        {
   
            var request = await _context.FriendRequests
               .FirstOrDefaultAsync(fr => fr.SenderId == senderId && fr.ReceiverId == receiverId);

            if (request == null)
                return false; 

            _context.FriendRequests.Remove(request);

         
            var friendship = new Friendship
            {
                UserId1 = senderId,
                UserId2 = receiverId
            };
            _context.Friendships.Add(friendship);

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> RemoveFriendRequestAsync(string receiverId, string senderId)
        {
            var request = await _context.FriendRequests
                .FirstOrDefaultAsync(fr => fr.SenderId == senderId && fr.ReceiverId == receiverId);

            if (request != null)
            {
                _context.FriendRequests.Remove(request);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
