using VersionOneWA.Shared.Classes;

namespace VersionOneWA.Shared.Services
{
    public interface IJobServices
    {
        Task<List<Job>> GetAllJobs();
        Task<Job> GetJobById(int id);
        Task<Job> AddJob(Job job);

        Task<Job> EditJob(int id, Job job);
        Task<bool> DeleteJob(int id);
    }
}
