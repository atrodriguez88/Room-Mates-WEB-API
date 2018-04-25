using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RoomM.API.Core;
using RoomM.API.Core.Models;

namespace RoomM.API.Persistent
{
    public class PropertyFeaturesRepository : IPropertyFeature
    {
        private readonly RoomMDbContext context;
        public PropertyFeaturesRepository(RoomMDbContext context)
        {
            this.context = context;

        }
        public Task<List<PropertyFeatures>> GetPropertyFeatures()
        {
            return context.PropertyFeatures.ToListAsync();
        }
    }
}