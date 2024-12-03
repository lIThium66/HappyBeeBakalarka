using Microsoft.EntityFrameworkCore;
using VersionOne.Classes;
using VersionOne.Data;

namespace VersionOne.Services
{
    public class JobServices : IJobServices
    {

        private readonly HappyBeeContext _happyBeeContext;

        public JobServices(HappyBeeContext happyBeeContext)
        {
            _happyBeeContext = happyBeeContext;
        }

        public async Task<Job> AddJob(Job job)
        {
            _happyBeeContext.Jobs.Add(job);
            await _happyBeeContext.SaveChangesAsync();
            return job;
        }

        public async Task<List<Job>> GetAllJobs()
        {
            var jobs = await _happyBeeContext.Jobs.ToListAsync();
            return jobs;
        }
    }
}
