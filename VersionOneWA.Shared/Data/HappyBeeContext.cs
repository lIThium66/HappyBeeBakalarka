using Microsoft.EntityFrameworkCore;
using VersionOneWA.Shared.Classes;
//using VersionOneWA.Components.Pages;

namespace VersionOneWA.Shared.Data
{
    public class HappyBeeContext : DbContext
    {
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Job> Jobs { get; set; } = null!;
        public DbSet<Beehive> Beehives { get; set; } = null!;

        public HappyBeeContext(DbContextOptions<HappyBeeContext> options) : base(options) 
        { 
        
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer();
        }
    }
}
