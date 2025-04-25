using Microsoft.EntityFrameworkCore;
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
            var editedStatus = await _happyBeeContext.Status.FindAsync(id);
            if (editedStatus != null)
            {
                editedStatus.Name = status.Name;
                editedStatus.Report = status.Report;
                editedStatus.CreatedAt = status.CreatedAt;
                editedStatus.doneTreatment = status.doneTreatment;
                editedStatus.suppliedWater = status.suppliedWater;
                editedStatus.suppliedSugar = status.suppliedSugar;


                await _happyBeeContext.SaveChangesAsync();
                return editedStatus;
            }
            throw new Exception("Task not found.");
        }

        public async Task<Status> GetStatusById(int id)
        {
            return await _happyBeeContext.Status.FindAsync(id);
        }

        public async Task<List<Status>> GetStatuses()
        {
            var statuses = await _happyBeeContext.Status.ToListAsync();
            return statuses;
        }

        public async Task<List<Status>> GetUserStatuses(string userId)
        {
            return await _happyBeeContext.Status.Where(j => j.UserId == userId).ToListAsync();

        }
    }
}
