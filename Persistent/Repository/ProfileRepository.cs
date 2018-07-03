using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RoomM.API.Core;
using RoomM.API.Core.Models;
using RoomM.API.Persistent.Entity;

namespace RoomM.API.Persistent
{
    public class ProfileRepository : Repository<Profile>, IProfileRepository
    {
        private readonly RoomMDbContext context;
        public ProfileRepository(RoomMDbContext context) : base (context)
        {
            this.context = context;
        }

        public async Task<Profile> GetProfile(int id)
        {
            return await context.Profiles.Include(p => p.Ocupation).SingleOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Profile>> GetProfiles()
        {
            return await context.Profiles.Include(p => p.Ocupation).ToListAsync();
        }
    }
}