using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using VersionOneWA.Shared.Classes;
using static System.Net.WebRequestMethods;

namespace VersionOneWA.Shared.Services
{
    public class ClientFriendService : IFriendService
    {
        private readonly HttpClient _httpClient;

        public ClientFriendService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<bool> AcceptFriendRequestAsync(int requestId)
        {
            var response = await _httpClient.PostAsJsonAsync($"/api/friends/accept/{requestId}", "");
            return response.IsSuccessStatusCode;
            
        }

        public Task<bool> AreFriends(string userId1, string userId2)
        {
            throw new NotImplementedException();
        }

        public Task<List<FriendRequest>> GetFriendRequestsAsync(string userId)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ApplicationUser>> GetFriendsAsync(string userId)
        {
            return await _httpClient.GetFromJsonAsync<List<ApplicationUser>>("/api/friends/list");
        }

        public async Task<List<FriendRequest>> GetPendingRequestsAsync(string userId)
        {
            return await _httpClient.GetFromJsonAsync<List<FriendRequest>>("/api/friends/pending"); 
        }

        public Task<bool> HasPendingRequest(string userId1, string userId2)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> RejectFriendRequestAsync(int requestId)
        {
            var response = await _httpClient.PostAsJsonAsync($"/api/friends/reject/{requestId}", "");
            return response.IsSuccessStatusCode;
           
            
        }

        public async Task<bool> SendFriendRequestAsync(string senderId, string receiverId)
        {
            var response = await _httpClient.PostAsJsonAsync($"/api/friends/send/{receiverId}", "");
            return response.IsSuccessStatusCode;
        }
    }
}
