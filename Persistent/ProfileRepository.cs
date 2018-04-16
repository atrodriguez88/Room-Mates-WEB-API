using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RoomM.API.Core;
using RoomM.API.Core.Models;

namespace RoomM.API.Persistent
{
    public class ProfileRepository : IProfileRepository
    {
        private readonly RoomMDbContext context;
        public ProfileRepository(RoomMDbContext context)
        {
            this.context = context;

        }
        public async Task AddProfileAsync(Profile profile)
        {
            await context.AddAsync(profile);
        }

        public async Task<Profile> GetProfile(int id, bool? includeRelated = true)
        {
            if (!includeRelated.Value)
            {
                return await context.Profiles.FindAsync(id);
            }
            return await context.Profiles.Include(p => p.Ocupation).SingleOrDefaultAsync(p => p.Id == id);
        }

        public async Task<List<Profile>> GetProfiles()
        {
            return await context.Profiles.Include(p => p.Ocupation).ToListAsync();
        }

        public void Remove(Profile profile)
        {
            context.Remove(profile);
        }
    }
}