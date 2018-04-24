using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RoomM.API.Core.Models;

namespace RoomM.API.Persistent
{
    public class RoomMDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<PropertyRules> PropertyRules { get; set; }
        public RoomMDbContext(DbContextOptions<RoomMDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Many to Many
            modelBuilder.Entity<RoomsPropertyRules>()
                .HasKey(rp => new { rp.RoomId, rp.PropertyRulesId });

            modelBuilder.Entity<RoomsPropertyFeatures>()
                .HasKey(rf => new { rf.RoomId, rf.PropertyFeaturesId });

            modelBuilder.Entity<RoomRoomFeatures>()
                .HasKey(rf => new { rf.RoomId, rf.RoomFeaturesId });
        }
    }
}