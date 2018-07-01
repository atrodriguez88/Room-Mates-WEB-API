using Common.CustomFilters;
using RoomM.API.Core.Models.Helper;
using System.Collections.Generic;

namespace RoomM.API.Core.Models
{
    public class PropertyRules : AuditEntity, ISoftDeleted
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<RoomsPropertyRules> Rooms { get; set; }
        public bool Deleted { get; set; }
    }
}