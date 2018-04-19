using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RoomM.API.Core;
using RoomM.API.Core.Models;

namespace RoomM.API.Persistent
{
    public class RoomRepository : IRoomRepository
    {
        private readonly RoomMDbContext context;
        public RoomRepository(RoomMDbContext context)
        {
            this.context = context;
        }

        public async Task AddRoomAsync(Room room)
        {
            await context.Rooms.AddAsync(room);
        }

        public async Task<Room> GetRoom(int id, bool? includeRelated = true)
        {
            if (!includeRelated.Value)
            {
                return await context.Rooms.FindAsync(id);
            }
            var room = await context.Rooms
             .Include(r => r.Rules)
                 .ThenInclude(rpr => rpr.PropertyRules)
             .Include(r => r.PropertyFeatures)
                 .ThenInclude(rpf => rpf.PropertyFeatures)
             .Include(r => r.RoomFeatures)
                 .ThenInclude(rrf => rrf.RoomFeatures).SingleOrDefaultAsync(r => r.Id == id);

            return room;
        }

        public async Task<List<Room>> GetRooms()
        {
            var rooms = await context.Rooms
             .Include(r => r.Rules)
                 .ThenInclude(rpr => rpr.PropertyRules)
             .Include(r => r.PropertyFeatures)
                 .ThenInclude(rpf => rpf.PropertyFeatures)
             .Include(r => r.RoomFeatures)
                 .ThenInclude(rrf => rrf.RoomFeatures).ToListAsync();

            return rooms;
        }

        public Task<List<Room>> GetRoomsByUserId(int userId)
        {
            return context.Rooms.Where( r => r.UserId == userId)
            .Include(r => r.PropertyFeatures)
                .ThenInclude(rpf => rpf.PropertyFeatures)
            .Include(r => r.Rules)
                .ThenInclude(rpr => rpr.PropertyRules)            
            .Include(r => r.RoomFeatures)
                .ThenInclude(rrf => rrf.RoomFeatures)       
            .ToListAsync();
        }

        public void Remove(Room room)
        {
            context.Remove(room);
        }
    }
}