using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using VersionOneWA.Shared.Classes;

namespace VersionOneWA.Shared.Services
{
    public class ClientBeehiveBaseService : IBeehiveBaseService
    {
        private readonly HttpClient _httpClient;

        public ClientBeehiveBaseService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<BeehiveBase> AddUserToBase(int baseId, string userId)
        {
            var response = await _httpClient.PostAsync($"api/BeehiveBase/{baseId}/users/{userId}", null);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<BeehiveBase>() ?? throw new Exception("No content");
        }

        public async Task<bool> DeleteBase(int id)
        {
            var response = await _httpClient.DeleteAsync($"api/BeehiveBase/{id}");
            return response.IsSuccessStatusCode;
        }

        public async Task<BeehiveBase> DeleteUserFromBase(int baseId, string userId)
        {
            var response = await _httpClient.DeleteAsync($"api/BeehiveBase/{baseId}/users/{userId}");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<BeehiveBase>() ?? throw new Exception("No content");
        }

        public async Task<BeehiveBase> EditBase(int baseId, BeehiveBase bBase)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/BeehiveBase/{baseId}", bBase);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<BeehiveBase>() ?? throw new Exception("No content");
        }

        public async Task<List<BeehiveBase>> GetAllBases()
        {
            return await _httpClient.GetFromJsonAsync<List<BeehiveBase>>("api/BeehiveBase") ?? new();
        }

        public async Task<BeehiveBase?> GetBaseById(int id)
        {
            return await _httpClient.GetFromJsonAsync<BeehiveBase>($"api/BeehiveBase/{id}");
        }

        public async Task<List<BeehiveBase>> GetUserBases(string userId)
        {
            return await _httpClient.GetFromJsonAsync<List<BeehiveBase>>($"/api/BeehiveBase/user/{userId}");
        }
    }
}
