using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VersionOneWA.Shared.Classes;

namespace VersionOneWA.Shared.Services
{
    public interface IBeehiveService
    {
        Task<List<Beehive>> GetAllBeehives();
        Task<Beehive> GetBeehiveById(int id);
        Task<Beehive> AddBeehive(Beehive beehive);
        Task<Beehive> EditBeehive(int id, Beehive beehive);
        Task<bool> DeleteBeehive(int id);

        Task<List<Beehive>> GetUserBeehives(string userId);

    }
}
