using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using VersionOneWA.Shared.Classes;

namespace VersionOneWA.Shared.Services
{
    public class ClientStatusService : IStatusServices
    {
        private readonly HttpClient _httpClient;

        public ClientStatusService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Status> AddStatus(Status status)
        {
            var result = await _httpClient.PostAsJsonAsync("/api/status", status);
            return await result.Content.ReadFromJsonAsync<Status>();
           
        }

        public async Task<bool> DeleteStatus(int id)
        {
            var result = await _httpClient.DeleteAsync($"/api/status/{id}");
            return await result.Content.ReadFromJsonAsync<bool>();
           
        }

        public async Task<Status> EditStatus(int id, Status status)
        {
            var result = await _httpClient.PutAsJsonAsync($"/api/status/{id}", status);
            return await result.Content.ReadFromJsonAsync<Status>();
        }
        public async Task<Status> GetInfoById(int id)
        {
            var result = await _httpClient.GetFromJsonAsync<Status>($"/api/status/{id}");
            return result;
           

        }

        public Task<List<Status>> GetStatuses()
        {
            throw new NotImplementedException();
        }
    }
}
