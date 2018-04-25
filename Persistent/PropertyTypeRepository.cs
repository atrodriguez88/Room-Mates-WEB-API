using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RoomM.API.Core;
using RoomM.API.Core.Models;

namespace RoomM.API.Persistent
{
    public class PropertyTypeRepository : IPropertyType
    {
        private readonly RoomMDbContext context;
        public PropertyTypeRepository(RoomMDbContext context)
        {
            this.context = context;

        }
        public Task<List<PropertyType>> GetPropertyTypes()
        {
            return context.PropertyTypes.ToListAsync();
        }
    }
}