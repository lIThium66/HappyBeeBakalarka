using Microsoft.EntityFrameworkCore;
using VersionOne.Classes;
using VersionOne.Components.Pages;

namespace VersionOne.Data
{
    public class HappyBeeContext : DbContext
    {
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Job> Jobs { get; set; } = null!;
        public DbSet<Beehive> Beehives { get; set; } = null!;

        public HappyBeeContext(DbContextOptions options) : base(options) 
        { 
        
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer();
        }
    }
}
