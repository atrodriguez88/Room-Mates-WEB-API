using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RoomM.API.Core;
using RoomM.API.Core.Models;
using RoomM.API.Persistent.Entity;

namespace RoomM.API.Persistent
{
    public class PropertyFeaturesRepository : Repository<PropertyFeatures>, IPropertyFeature
    {
        private readonly RoomMDbContext context;
        public PropertyFeaturesRepository(RoomMDbContext context) : base(context)
        {
            this.context = context;

        }
        public Task<List<PropertyFeatures>> GetPropertyFeatures()
        {
            return context.PropertyFeatures.ToListAsync();
        }
    }
}