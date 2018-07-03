using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RoomM.API.Core;
using RoomM.API.Core.Models;
using RoomM.API.Persistent.Entity;

namespace RoomM.API.Persistent
{
    public class RoomRepository : Repository<Room>, IRoomRepository
    {
        private readonly RoomMDbContext context;
        public RoomRepository(RoomMDbContext context) : base(context)
        {
            this.context = context;
        }

        public async Task<Room> GetRoom(int id)
        {
            return await context.Rooms
                                        .Include(r => r.PropertyType)
                                        .Include(r => r.Preference)
                                        .Include(r => r.Rules)
                                             .ThenInclude(rpr => rpr.PropertyRules)
                                        .Include(r => r.PropertyFeatures)
                                            .ThenInclude(rpf => rpf.PropertyFeatures)
                                        .Include(r => r.RoomFeatures)
                                            .ThenInclude(rrf => rrf.RoomFeatures)
                                        .SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Room>> GetRooms()
        {
            return await context.Rooms
                                        .Include(r => r.PropertyType)
                                        .Include(r => r.Preference)
                                        .Include(r => r.Rules)
                                             .ThenInclude(rpr => rpr.PropertyRules)
                                        .Include(r => r.PropertyFeatures)
                                            .ThenInclude(rpf => rpf.PropertyFeatures)
                                        .Include(r => r.RoomFeatures)
                                            .ThenInclude(rrf => rrf.RoomFeatures)
                                        .ToListAsync();
        }
    }
}