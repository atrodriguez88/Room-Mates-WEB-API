using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RoomM.API.Core;
using RoomM.API.Core.Models;
using RoomM.API.Persistent.Entity;

namespace RoomM.API.Persistent
{
    public class RuleRepository : Repository<PropertyRules>, IRuleRepository
    {
        private readonly RoomMDbContext context;
        public RuleRepository(RoomMDbContext context) : base(context)
        {
            this.context = context;
        }
    }
}