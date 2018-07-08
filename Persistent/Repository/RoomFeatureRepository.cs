using RoomM.API.Core;
using RoomM.API.Core.Models.Domain;
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