using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RoomM.API.Core;
using RoomM.API.Core.Models;

namespace RoomM.API.Persistent
{
    public class OcupationRepository : IOcupation
    {
        private readonly RoomMDbContext context;
        public OcupationRepository(RoomMDbContext context)
        {
            this.context = context;

        }
        public Task<List<Ocupation>> GetOcupations()
        {
            return context.Ocupations.ToListAsync();
        }
    }
}