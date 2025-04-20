using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using VersionOneWA.Shared.Classes;

namespace VersionOneWA.Shared.Services
{
    public class ClientJobService : IJobServices
    {
        private readonly HttpClient _httpClient;

        public ClientJobService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Job> AddJob(Job job)
        {
            var result = await _httpClient.PostAsJsonAsync("/api/job", job);
            return await result.Content.ReadFromJsonAsync<Job>();
        }

        public async Task<bool> DeleteJob(int id)
        {
            var result = await _httpClient.DeleteAsync($"/api/job/{id}");
            return await result.Content.ReadFromJsonAsync<bool>();
        }

        public async Task<Job> EditJob(int id, Job job)
        {
            var result = await _httpClient.PutAsJsonAsync($"/api/job/{id}", job);
            return await result.Content.ReadFromJsonAsync<Job>();
        }

        public async Task<List<Job>> GetAllJobs()
        {
            var jobs = await _httpClient.GetFromJsonAsync<List<Job>>("/api/job");
            return jobs;
        }

        public async Task<Job> GetJobById(int id)
        {
            var result = await _httpClient.GetFromJsonAsync<Job>($"/api/job/{id}");
            return result;
        }

        public async Task<List<Job>> GetUserJobs(string userId)
        {
            return await _httpClient.GetFromJsonAsync<List<Job>>($"/api/job/user/{userId}");
        }


    }
}
