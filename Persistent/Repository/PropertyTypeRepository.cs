using RoomM.API.Core.Models.Domain;
using RoomM.API.Core.Repository;
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
    }
}