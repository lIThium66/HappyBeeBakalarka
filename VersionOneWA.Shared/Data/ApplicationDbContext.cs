using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
using VersionOneWA.Shared.Classes;

namespace VersionOneWA.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
    {
        //public DbSet<User> Users { get; set; } = null!;
        public DbSet<Job> Jobs { get; set; } = null!;
        public DbSet<Beehive> Beehives { get; set; } = null!;
        public DbSet<Status> Status { get; set; } = null!;
        public DbSet<Friends> Friends { get; set; } = null!;
        public DbSet<Friendship> Friendships { get; set; }
        public DbSet<FriendRequest> FriendRequests { get; set; }
        public DbSet<BeehiveBase> BeehiveBases { get; set; }
        public DbSet<BeehiveMember> BeehiveMembers { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<FriendRequest>()
                .HasOne(fr => fr.Sender)
                .WithMany(u => u.SentRequests)
                .HasForeignKey(fr => fr.SenderId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<FriendRequest>()
                .HasOne(fr => fr.Receiver)
                .WithMany(u => u.ReceivedRequests)
                .HasForeignKey(fr => fr.ReceiverId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Friendship>()
                .HasIndex(f => new { f.UserId1, f.UserId2 })
                .IsUnique();


            //pre BEEHIVEBASE zakaz kaskadoveho mazania
            builder.Entity<Beehive>()
                .HasOne(b => b.BeehiveBase)
                .WithMany(bb => bb.Beehives)
                .HasForeignKey(b => b.BeehiveBaseId)
                .OnDelete(DeleteBehavior.Restrict);
          
            builder.Entity<Job>()
                 .HasOne(j => j.BeehiveBase)
                 .WithMany(bb => bb.Jobs)
                 .HasForeignKey(j => j.BeehiveBaseId)
                 .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
