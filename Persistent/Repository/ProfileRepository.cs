using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RoomM.API.Core;
using RoomM.API.Core.Models;
using RoomM.API.Core.Models.Domain;
using RoomM.API.Core.Models.Helper;
using RoomM.API.Persistent.Entity;

namespace RoomM.API.Persistent
{
    public class ProfileRepository : Repository<Profile>, IProfileRepository
    {
        private readonly RoomMDbContext context;
        public ProfileRepository(RoomMDbContext context) : base(context)
        {
            this.context = context;
        }

        public async Task<Profile> GetProfile(int id)
        {
            return await context.Profiles.Include(p => p.Ocupation).SingleOrDefaultAsync(p => p.Id == id && p.Deleted == false);
        }

        public async Task<IEnumerable<Profile>> GetProfiles(FilterProfile filter)
        {
            var query = context.Profiles.Include(p => p.Ocupation)
                                        .Where(p => p.Deleted == false);

            if (filter.Age.HasValue)
            {
                query = query.Where(p => p.Age == filter.Age);
            }
            if (filter.Gender != null)
            {
                query = query.Where(p => p.Gender == filter.Gender);
            }
            if (filter.Ocupation.HasValue)
            {
                query = query.Where(p => p.OcupationId == filter.Ocupation);
            }
            if (filter.Address != null)
            {
                query = query.Where(p => p.Address == filter.Address);
            }
            /*
             All the filter Here    
             */

            return await query.ToListAsync();
        }

        public async Task AddPhoto(int id, Photo photo)
        {
            var profile = await context.Profiles.SingleOrDefaultAsync(p => p.Id == id);
            profile.Photos.Add(photo);
        }
    }
}