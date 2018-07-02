using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RoomM.API.Core;
using RoomM.API.Core.Models;
using RoomM.API.Persistent.Entity;

namespace RoomM.API.Persistent
{
    public class RoomFeatureRepository : Repository<RoomFeatures>, IRoomFeature
    {
        private readonly RoomMDbContext context;
        public RoomFeatureRepository(RoomMDbContext context) : base(context)
        {
            this.context = context;
        }
    }
}