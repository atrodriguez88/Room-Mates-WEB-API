using RoomM.API.Core;
using RoomM.API.Core.Models.Domain;
using RoomM.API.Persistent.Entity;

namespace RoomM.API.Persistent
{
    public class OcupationRepository : Repository<Ocupation>, IOcupationRepository
    {
        private readonly RoomMDbContext context;
        public OcupationRepository(RoomMDbContext context) : base(context)
        {
            this.context = context;

        }
    }
}