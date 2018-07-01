using Common.CustomFilters;
using RoomM.API.Core.Models.Helper;
using System.Collections.Generic;

namespace RoomM.API.Core.Models
{
    public class RoomFeatures : AuditEntity, ISoftDeleted
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<RoomRoomFeatures> Room { get; set; }
        public bool Deleted { get; set; }
    }
}