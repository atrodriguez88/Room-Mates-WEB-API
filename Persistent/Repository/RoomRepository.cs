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
    }
}