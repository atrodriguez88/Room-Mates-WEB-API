using RoomM.API.Core;
using RoomM.API.Core.Models.Domain;
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
    }
}