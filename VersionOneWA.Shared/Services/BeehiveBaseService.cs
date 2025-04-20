//using Microsoft.EntityFrameworkCore;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using VersionOneWA.Data;
//using VersionOneWA.Shared.Classes;

//namespace VersionOneWA.Shared.Services
//{
//    public class BeehiveBaseService : IBeehiveBaseService
//    {
//        private readonly ApplicationDbContext _context;

//        public BeehiveBaseService(ApplicationDbContext context)
//        {
//            _context = context;
//        }

//        public async Task<BeehiveBase> AddUserToBase(int baseId, string userId)
//        {
//            var bBase = await _context.BeehiveBases
//                .Include(b => b.BeehiveMembers)
//                .FirstOrDefaultAsync(b => b.Id == baseId);

//            if (bBase == null) throw new Exception("Base not found");

//            var user = await _context.Users.FindAsync(userId);
//            if (user == null) throw new Exception("User not found");

//            var newMember = new BeehiveMember
//            {
//                UserId = userId,
//                Name = user.UserName ?? "Unknown",
//                BeehiveBaseId = baseId 
//            };

//            _context.BeehiveMembers.Add(newMember);
//            await _context.SaveChangesAsync();

//            return bBase;
//        }

//        public async Task<bool> DeleteBase(int id)
//        {
//            var bBase = await _context.BeehiveBases.FindAsync(id);
//            if (bBase == null) return false;

//            _context.BeehiveBases.Remove(bBase);
//            await _context.SaveChangesAsync();
//            return true;
//        }

//        public async Task<BeehiveBase> DeleteUserFromBase(int baseId, string userId)
//        {
//            var member = await _context.BeehiveMembers
//                 .FirstOrDefaultAsync(m => m.BeehiveBaseId == baseId && m.UserId == userId);

//            if (member == null) throw new Exception("Member not found");

//            _context.BeehiveMembers.Remove(member);
//            await _context.SaveChangesAsync();

//            var bBase = await _context.BeehiveBases
//                .Include(b => b.BeehiveMembers)
//                .FirstOrDefaultAsync(b => b.Id == baseId);

//            return bBase!;
//        }

//        public async Task<BeehiveBase> EditBase(int baseId, BeehiveBase bBase)
//        {
//            var existing = await _context.BeehiveBases.FindAsync(baseId);
//            if (existing == null) throw new Exception("Base not found");

//            existing.Name = bBase.Name;
//            // ked tak pridam dalsie vlastnosti

//            await _context.SaveChangesAsync();
//            return existing;
//        }

//        public async Task<List<BeehiveBase>> GetAllBases()
//        {
//            return await _context.BeehiveBases
//                .Include(b => b.BeehiveMembers)
//                .Include(b => b.Beehives)
//                .Include(b => b.Jobs)
//                .ToListAsync();
//        }

//        public async Task<BeehiveBase?> GetBaseById(int id)
//        {
//            //return await _context.BeehiveBases
//            //    .Include(b => b.BeehiveMembers)
//            //    .Include(b => b.Beehives)
//            //    .Include(b => b.Jobs)
//            //    .FirstOrDefaultAsync(b => b.Id == id);
//            return await _context.BeehiveBases.FindAsync(id);
//        }

//        public async Task<List<BeehiveBase>> GetUserBases(string userId)
//        {
//            //return await _context.BeehiveBases.Where(j => j.UserId == userId).ToListAsync();

//            throw new NotImplementedException();
//        }
//    }

//}
