using System.Collections.Generic;
using Common.CustomFilters;
using RoomM.API.Core.Models.Helper;

namespace RoomM.API.Core.Models.Domain
{
    public class PropertyFeatures: AuditEntity, ISoftDeleted
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<RoomsPropertyFeatures> Rooms { get; set; }
        public bool Deleted { get; set; }
    }
}