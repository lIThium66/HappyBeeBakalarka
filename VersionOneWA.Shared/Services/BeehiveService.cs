﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VersionOneWA.Data;
using VersionOneWA.Shared.Classes;

namespace VersionOneWA.Shared.Services
{
    public class BeehiveService : IBeehiveService
    {
        private readonly ApplicationDbContext _happyBeeContext;

        public BeehiveService(ApplicationDbContext happyBeeContext)
        {
            _happyBeeContext = happyBeeContext;
        }

        public async Task<Beehive> AddBeehive(Beehive beehive)
        {
            _happyBeeContext.Beehives.Add(beehive);
            await _happyBeeContext.SaveChangesAsync();
            return beehive;
        }

        public async Task<bool> DeleteBeehive(int id)
        {
            var deletedBeehive = await _happyBeeContext.Beehives.FindAsync(id);
            if (deletedBeehive != null)
            {
                _happyBeeContext.Remove(deletedBeehive);
                await _happyBeeContext.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<Beehive> EditBeehive(int id, Beehive beehive)
        {
            var editedBeehive = await _happyBeeContext.Beehives.FindAsync(id);
            if (editedBeehive != null)
            {
                editedBeehive.Name = beehive.Name;
                editedBeehive.beehiveWeight = beehive.beehiveWeight;
                editedBeehive.numberOfBees = beehive.numberOfBees;
                editedBeehive.QueensAge = beehive.QueensAge;
                await _happyBeeContext.SaveChangesAsync();
                return editedBeehive;
            }
            throw new Exception("Task not found.");
        }


        public async Task<List<Beehive>> GetAllBeehives()
        {
            var beehives = await _happyBeeContext.Beehives.ToListAsync();
            return beehives;
        }

        public async Task<Beehive> GetBeehiveById(int id)
        {
            return await _happyBeeContext.Beehives.FindAsync(id);
        }

        public async Task<List<Beehive>> GetUserBeehives(string userId)
        {
           return await _happyBeeContext.Beehives.Where(j => j.UserId == userId).ToListAsync();
        }



        //
        //public async Task<List<Beehive>> GetBeehivesByBaseId(int baseId)
        //{
        //    return await _happyBeeContext.Beehives
        //        .Where(b => b.BeehiveBaseId == baseId)
        //        .ToListAsync();
        //}
    }
}
