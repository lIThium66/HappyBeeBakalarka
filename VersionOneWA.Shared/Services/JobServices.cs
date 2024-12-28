using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata;
using VersionOneWA.Shared.Classes;
using VersionOneWA.Shared.Data;

namespace VersionOneWA.Shared.Services
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
            var validationContext = new ValidationContext(job);
            Validator.ValidateObject(job, validationContext, validateAllProperties: true);

            if (string.IsNullOrWhiteSpace(job.Name))
            {
                
            }
            _happyBeeContext.Jobs.Add(job);
            await _happyBeeContext.SaveChangesAsync();
            return job;
        }

        public async Task<bool> DeleteJob(int id)
        {
            var deletedJob = await _happyBeeContext.Jobs.FindAsync(id);
            if (deletedJob != null)
            {
                _happyBeeContext.Remove(deletedJob);
                await _happyBeeContext.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<Job> EditJob(int id, Job job)
        {
            var editedJob = await _happyBeeContext.Jobs.FindAsync(id);
            if (editedJob != null) 
            {
                editedJob.Name = job.Name;
                editedJob.Description = job.Description;
                await _happyBeeContext.SaveChangesAsync();
                return editedJob;
            }
            throw new Exception("Task not found.");
        }

        public async Task<List<Job>> GetAllJobs()
        {
            var jobs = await _happyBeeContext.Jobs.ToListAsync();
            return jobs;
        }

        public async Task<Job> GetJobById(int id)
        {
            return await _happyBeeContext.Jobs.FindAsync(id);
        }
    }
}
