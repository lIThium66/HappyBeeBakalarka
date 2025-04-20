using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VersionOneWA.Shared.Classes;

namespace VersionOneWA.Shared.Services
{
    public interface IBeehiveBaseService
    {
        Task<List<BeehiveBase>> GetAllBases();
        Task<BeehiveBase?> GetBaseById(int id);
        Task<BeehiveBase> AddUserToBase(int baseId, string userId);
        Task<BeehiveBase> DeleteUserFromBase(int baseId, string userId);
        Task<BeehiveBase> EditBase(int baseId, BeehiveBase bBase);
        Task<bool> DeleteBase(int id);

        Task<List<BeehiveBase>> GetUserBases(string userId);

    }
}
