using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using VersionOneWA.Shared.Classes;

namespace VersionOneWA.Shared.Services
{
    public class ClientBeehiveService : IBeehiveService
    {
        private readonly HttpClient _httpClient;
        public ClientBeehiveService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Beehive> AddBeehive(Beehive beehive)
        {
            var result = await _httpClient.PostAsJsonAsync("/api/beehive", beehive);
            return await result.Content.ReadFromJsonAsync<Beehive>();
        }

        public async Task<bool> DeleteBeehive(int id)
        {
            var result = await _httpClient.DeleteAsync($"/api/beehive/{id}");
            return await result.Content.ReadFromJsonAsync<bool>();
        }

        public async Task<Beehive> EditBeehive(int id, Beehive beehive)
        {
            var result = await _httpClient.PutAsJsonAsync($"/api/beehive/{id}", beehive);
            return await result.Content.ReadFromJsonAsync<Beehive>();
        }

        public Task<List<Beehive>> GetAllBeehives()
        {
            throw new NotImplementedException();
        }

        public async Task<Beehive> GetBeehiveById(int id)
        {
            var result = await _httpClient.GetFromJsonAsync<Beehive>($"/api/beehive/{id}");
            return result;
        }
    }
}
