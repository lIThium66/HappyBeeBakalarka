using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VersionOneWA.Shared.Classes;

namespace VersionOneWA.Shared.Services
{
    public interface IStatusServices
    {
        Task<List<Status>> GetStatuses();
        Task<Status> GetInfoById(int id);
        Task<Status> AddStatus(Status status);
        Task<Status> EditStatus(int id, Status status);
        Task<bool> DeleteStatus(int id);
    }
}
