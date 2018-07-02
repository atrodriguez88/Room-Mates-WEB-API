using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RoomM.API.Core.Models;
using RoomM.API.Core.Models.Auth;
using System.Linq;

namespace RoomM.API.Persistent
{
    public class RoomMDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<ApplicationUser> ApplicationUser { get; set; }
        public DbSet<ApplicationRole> ApplicationRole { get; set; }
        //public DbSet<ApplicationUserRole> ApplicationUserRole { get; set; }

        public DbSet<Room> Rooms { get; set; }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<PropertyRules> PropertyRules { get; set; }
        public DbSet<PropertyType> PropertyTypes { get; set; }
        public DbSet<PropertyFeatures> PropertyFeatures { get; set; }
        public DbSet<RoomFeatures> RoomFeatures { get; set; }
        public DbSet<Ocupation> Ocupations { get; set; }
        public RoomMDbContext(DbContextOptions<RoomMDbContext> options)
            : base(options)
        {
        }

        public RoomMDbContext()
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