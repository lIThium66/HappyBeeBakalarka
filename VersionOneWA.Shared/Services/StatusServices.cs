using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VersionOneWA.Data;
using VersionOneWA.Shared.Classes;


namespace VersionOneWA.Shared.Services
{
    public class StatusServices : IStatusServices
    {
        private readonly ApplicationDbContext _happyBeeContext;

        public StatusServices(ApplicationDbContext beeContext)
        {
            _happyBeeContext = beeContext;
        }

        public async Task<Status> AddStatus(Status status)
        {
            _happyBeeContext.Status.Add(status);
            await _happyBeeContext.SaveChangesAsync();
            return status;
        }

        public async Task<bool> DeleteStatus(int id)
        {
            var deletedStatus = await _happyBeeContext.Status.FindAsync(id);
            if (deletedStatus != null)
            {
                _happyBeeContext.Remove(deletedStatus);
                await _happyBeeContext.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<Status> EditStatus(int id, Status status)
        {
            var editedJob = await _happyBeeContext.Status.FindAsync(status);
            if (editedJob != null)
            {
                editedJob.Name = status.Name;
                //_happyBeeContext.Status.Update(editedJob);
                await _happyBeeContext.SaveChangesAsync();
                return editedJob;
            }
            throw new Exception("Task not found.");
        }

        public async Task<Status> GetInfoById(int id)
        {
            return await _happyBeeContext.Status.FindAsync(id);
        }

        public async Task<List<Status>> GetStatuses()
        {
            var statuses = await _happyBeeContext.Status.ToListAsync();
            return statuses;
        }
    }
}
