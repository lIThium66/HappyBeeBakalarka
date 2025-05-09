﻿using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata;
using VersionOneWA.Data;
using VersionOneWA.Shared.Classes;

namespace VersionOneWA.Shared.Services
{
    public class JobServices : IJobServices
    {

        private readonly ApplicationDbContext _happyBeeContext;

        public JobServices(ApplicationDbContext happyBeeContext)
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
                editedJob.Priority = job.Priority;
                editedJob.JobDate = job.JobDate;
                editedJob.IsCompleted = job.IsCompleted;

                _happyBeeContext.Jobs.Update(editedJob);
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

        public async Task<List<Job>> GetUserJobs(string userId)
        {
            return await _happyBeeContext.Jobs.Where(j => j.UserId == userId).ToListAsync();
        }


    }
}
