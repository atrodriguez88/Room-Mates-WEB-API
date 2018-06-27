using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RoomM.API.Core;
using RoomM.API.Core.Models;
using RoomM.API.Persistent.Entity;

namespace RoomM.API.Persistent
{
    public class PropertyTypeRepository : Repository<PropertyType>, IPropertyType
    {
        private readonly RoomMDbContext context;
        public PropertyTypeRepository(RoomMDbContext context) : base(context)
        {
            this.context = context;

        }
        public Task<List<PropertyType>> GetPropertyTypes()
        {
            return context.PropertyTypes.ToListAsync();
        }
    }
}