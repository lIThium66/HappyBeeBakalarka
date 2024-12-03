using VersionOne.Classes;

namespace VersionOne.Services
{
    public interface IJobServices
    {
        Task<List<Job>> GetAllJobs();
        Task<Job> AddJob(Job job);
    }
}
