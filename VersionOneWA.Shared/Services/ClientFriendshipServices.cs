using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using VersionOneWA.Shared.Classes;

namespace VersionOneWA.Shared.Services
{
    public class ClientFriendshipService : IFriendshipService
    {
        private readonly HttpClient _httpClient;

        public ClientFriendshipService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<ApplicationUser>> GetFriendsAsync(string userId)
        {
            return await _httpClient.GetFromJsonAsync<List<ApplicationUser>>($"api/Friendship/list/{userId}") ?? new List<ApplicationUser>();
        }

        public async Task<bool> AddFriendshipAsync(string userId1, string userId2)
        {
            var request = new { UserId1 = userId1, UserId2 = userId2 };
            var response = await _httpClient.PostAsJsonAsync("api/Friendship/add", request);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> RemoveFriendshipAsync(string userId1, string userId2)
        {
            var response = await _httpClient.DeleteAsync($"api/Friendship/remove/{userId1}/{userId2}");
            return response.IsSuccessStatusCode;
        }

        public async Task<List<ApplicationUser>> GetPendingRequestsAsync(string userId)
        {
            return await _httpClient.GetFromJsonAsync<List<ApplicationUser>>($"api/Friendship/pending/{userId}") ?? new List<ApplicationUser>();
        }

        public async Task<bool> ConfirmFriendRequestAsync(string receiverId, string senderId)
        {
            var request = new { ReceiverId = receiverId, SenderId = senderId };
            var response = await _httpClient.PostAsJsonAsync("api/Friendship/confirm", request);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> RemoveFriendRequestAsync(string receiverId, string senderId)
        {
            var response = await _httpClient.DeleteAsync($"api/Friendship/reject/{receiverId}/{senderId}");
            return response.IsSuccessStatusCode;
        }
    }
}
