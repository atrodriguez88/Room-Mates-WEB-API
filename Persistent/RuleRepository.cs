using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RoomM.API.Core;
using RoomM.API.Core.Models;

namespace RoomM.API.Persistent
{
    public class RuleRepository : IRuleRepository
    {
        private readonly RoomMDbContext context;
        public RuleRepository(RoomMDbContext context)
        {
            this.context = context;

        }
        public Task<List<PropertyRules>> GetRules()
        {
            return context.PropertyRules.ToListAsync();
        }
    }
}