using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RoomM.API.Core;
using RoomM.API.Core.Models;

namespace RoomM.API.Persistent
{
    public class RoomFeatureRepository : IRoomFeature
    {
        private readonly RoomMDbContext context;
        public RoomFeatureRepository(RoomMDbContext context)
        {
            this.context = context;

        }
        public Task<List<RoomFeatures>> GetRoomFeatures()
        {
            return context.RoomFeatures.ToListAsync();
        }
    }
}